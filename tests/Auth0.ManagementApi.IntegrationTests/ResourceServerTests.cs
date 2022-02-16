using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class ResourceServerTests : ManagementTestBase, IAsyncLifetime
    {
        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            ApiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 }));
        }

        public override Task DisposeAsync()
        {
            return CleanupAndDisposeAsync();
        }

        [Fact]
        public async Task Test_resource_server_crud_sequence()
        {
            // Add a new resource server
            var identifier = Guid.NewGuid();
            var createResourceServerRequest = new ResourceServerCreateRequest()
            {
                Identifier = identifier.ToString("N"),
                Name = $"{TestingConstants.ResourceServerPrefix} {identifier:N}",
                TokenLifetime = 1,
                TokenLifetimeForWeb = 1,
                SigningAlgorithm = SigningAlgorithm.HS256,
                SigningSecret = "thisismysecret0123456789",
                Scopes = new List<ResourceServerScope>
                {
                    new ResourceServerScope
                    {
                        Value = "scope1",
                        Description = "Scope number 1"
                    }
                },
                AllowOfflineAccess = true,
                VerificationLocation = "https://abc.auth0.com/def",
                SkipConsentForVerifiableFirstPartyClients = true,
            };

            var newResourceServerResponse = await ApiClient.ResourceServers.CreateAsync(createResourceServerRequest);
            newResourceServerResponse.Should().BeEquivalentTo(createResourceServerRequest, options => options.Excluding(rs => rs.Id));

            // Update the resource server
            var updateResourceServerRequest = new ResourceServerUpdateRequest()
            {
                Name = $"{TestingConstants.ResourceServerPrefix} {Guid.NewGuid():N}",
                TokenLifetime = 2,
                TokenLifetimeForWeb = 1,
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
                },
                AllowOfflineAccess = false,
                EnforcePolicies = false,
                TokenDialect = TokenDialect.AccessToken,
                VerificationLocation = "",
                SkipConsentForVerifiableFirstPartyClients = false,
            };
            var updateResourceServerResponse = await ApiClient.ResourceServers.UpdateAsync(newResourceServerResponse.Id, updateResourceServerRequest);
            updateResourceServerResponse.Should().BeEquivalentTo(updateResourceServerRequest, options => options.ExcludingMissingMembers());

            // Get a single resource server
            var resourceServer = await ApiClient.ResourceServers.GetAsync(newResourceServerResponse.Id);
            resourceServer.Should().BeEquivalentTo(updateResourceServerRequest, options => options.ExcludingMissingMembers());

            // Delete the client, and ensure we get exception when trying to fetch client again
            await ApiClient.ResourceServers.DeleteAsync(resourceServer.Id);
            Func<Task> getFunc = async () => await ApiClient.ResourceServers.GetAsync(resourceServer.Id);
            getFunc.Should().Throw<ErrorApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_resource_server");
        }

        [Fact]
        public async Task Test_get_resource_server_by_identifier()
        {
            string identifier = GetVariable("AUTH0_MANAGEMENT_API_AUDIENCE");
            var resourceServers = await ApiClient.ResourceServers.GetAsync(identifier);

            Assert.Equal(resourceServers.Identifier, identifier);
        }

        [Fact]
        public async Task Test_paging_does_not_include_totals()
        {
            // Act
            var resourceServers = await ApiClient.ResourceServers.GetAllAsync(new PaginationInfo(0, 50, false));

            // Assert
            Assert.Null(resourceServers.Paging);
        }

        [Fact]
        public async Task Test_paging_includes_totals()
        {
            // Act
            var resourceServers = await ApiClient.ResourceServers.GetAllAsync(new PaginationInfo(0, 50, true));

            // Assert
            Assert.NotNull(resourceServers.Paging);
        }

        [Fact]
        public async Task Test_without_paging()
        {
            // Act
            var resourceServers = await ApiClient.ResourceServers.GetAllAsync();

            // Assert
            resourceServers.Paging.Should().BeNull();
            resourceServers.Count.Should().BeGreaterThan(0);
        }
    }
}