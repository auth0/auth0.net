using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class ClientGrantTests : TestBase, IAsyncLifetime
    {
        private ManagementApiClient apiClient;
        private Client client;
        private ResourceServer resourceServer;

        public async Task InitializeAsync()
        {
            var token = await GenerateManagementApiToken();

            apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));

            // We need a client in order to create client grants
            client = await apiClient.Clients.CreateAsync(new ClientCreateRequest
            {
                Name = $"Integration testing {Guid.NewGuid().ToString("N")}"
            });

            // We also need to create a resource server
            var identifier = Guid.NewGuid();
            resourceServer = await apiClient.ResourceServers.CreateAsync(new ResourceServerCreateRequest
            {
                Identifier = "urn:" + identifier,
                Name = $"Integration testing {identifier:N}",
                TokenLifetime = 1,
                SigningAlgorithm = SigningAlgorithm.RS256,
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
                    },
                    new ResourceServerScope
                    {
                        Value = "scope3",
                        Description = "Scope number 3"
                    }
                }
            });
        }

        public async Task DisposeAsync()
        {
            if (client != null)
                await apiClient.Clients.DeleteAsync(client.ClientId);

            if (resourceServer != null)
                await apiClient.ResourceServers.DeleteAsync(resourceServer.Id);
        }

        [Fact]
        public async Task Test_client_credentials_crud_sequence()
        {
            // Get all the current client grants
            var clientGrantsBefore = await apiClient.ClientGrants.GetAllAsync();

            // Add a new client grant
            var newClientGrantRequest = new ClientGrantCreateRequest
            {
                ClientId = client.ClientId,
                Audience = resourceServer.Identifier,
                Scope = new List<string>
                {
                    "scope1",
                    "scope2"
                }
            };
            var newClientGrantResponse = await apiClient.ClientGrants.CreateAsync(newClientGrantRequest);
            newClientGrantResponse.Should().NotBeNull();
            newClientGrantResponse.ShouldBeEquivalentTo(newClientGrantRequest,
                options => options.Excluding(cg => cg.Id));

            // Get all the client grants again, and verify we have one more
            var clientGrantsAfter = await apiClient.ClientGrants.GetAllAsync();
            clientGrantsAfter.Count.Should().Be(clientGrantsBefore.Count + 1);

            // Update the client grant
            var updateClientGrantRequest = new ClientGrantUpdateRequest
            {
                Scope = new List<string>
                {
                    "scope3"
                }
            };
            var updateClientGrantResponse =
                await apiClient.ClientGrants.UpdateAsync(newClientGrantResponse.Id, updateClientGrantRequest);
            updateClientGrantResponse.Should().NotBeNull();
            updateClientGrantResponse.Scope.Count.Should().Be(1);
            updateClientGrantResponse.Scope[0].Should().Be("scope3");

            // Delete the client grant
            await apiClient.ClientGrants.DeleteAsync(newClientGrantResponse.Id);
        }
    }
}