using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class ResourceServerTests : TestBase
    {
        [Fact]
        public async Task Test_resource_server_crud_sequence()
        {
            string token = await GenerateManagementApiToken();

            var apiClient = new ManagementApiClient(token, new Uri(GetVariable("AUTH0_MANAGEMENT_API_URL")));

            // Get all the resource servers
            var resourceServersBefore = await apiClient.ResourceServers.GetAllAsync();

            // Add a new resource server
            var identifier = Guid.NewGuid();
            var newResourceServerRequest = new ResourceServerCreateRequest()
            {
                Identifier = identifier.ToString("N"),
                Name = $"Integration testing {identifier:N}",
                TokenLifetime = 1,
                SigningAlgorithm = SigningAlgorithm.HS256,
                SigningSecret = "thisismysecret0123456789",
                Scopes = new List<ResourceServerScope>
                {
                    new ResourceServerScope
                    {
                        Value = "scope1",
                        Description = "Scope number 1"
                    }
                }
            };
            var newResourceServerResponse = await apiClient.ResourceServers.CreateAsync(newResourceServerRequest);
            newResourceServerResponse.ShouldBeEquivalentTo(newResourceServerRequest, options => options.Excluding(rs => rs.Id));

            // Get all the resource servers again. Verify we now have one more
            var resourceServersAfter = await apiClient.ResourceServers.GetAllAsync();
            resourceServersAfter.Count.Should().Be(resourceServersBefore.Count + 1);

            // Update the resource server
            var resourceServerRequest = new ResourceServerUpdateRequest()
            {
                Name = $"Integration testing {Guid.NewGuid():N}",
                TokenLifetime = 1,
                SigningAlgorithm = SigningAlgorithm.HS256,
                SigningSecret = "thisismysecret0123456789",
                Scopes = new List<ResourceServerScope>
                {
                    new ResourceServerScope
                    {
                        Value = "scope1",
                        Description = "Scope number 1"
                    },
                    new ResourceServerScope
                    {
                        Value = "scope2",
                        Description = "Scope number 2"
                    }
                }
            };
            var updateResourceServerResponse = await apiClient.ResourceServers.UpdateAsync(newResourceServerResponse.Id, resourceServerRequest);
            updateResourceServerResponse.ShouldBeEquivalentTo(resourceServerRequest, options => options.ExcludingMissingMembers());

            // Get a single client
            var resourceServer = await apiClient.ResourceServers.GetAsync(newResourceServerResponse.Id);
            resourceServer.ShouldBeEquivalentTo(resourceServerRequest, options => options.ExcludingMissingMembers());

            // Delete the client, and ensure we get exception when trying to fetch client again
            await apiClient.ResourceServers.DeleteAsync(resourceServer.Id);
            Func<Task> getFunc = async () => await apiClient.ResourceServers.GetAsync(resourceServer.Id);
            getFunc.ShouldThrow<ApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_resource_server");
        }
    }
}