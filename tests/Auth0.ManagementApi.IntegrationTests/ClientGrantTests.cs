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

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            apiClient = new ManagementApiClient(token, new Uri(GetVariable("AUTH0_MANAGEMENT_API_URL")));

            // We need a client in order to create client grants
            client = await apiClient.Clients.CreateAsync(new ClientCreateRequest
            {
                Name = $"Integration testing {Guid.NewGuid().ToString("N")}"
            });
        }

        public async Task DisposeAsync()
        {
            await apiClient.Clients.DeleteAsync(client.ClientId);
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
                Audience = Guid.NewGuid().ToString(),
                Scope = new List<string>()
                {
                    "Scope 1",
                    "Scope 2"
                }
            };
            var newClientGrantResponse = await apiClient.ClientGrants.CreateAsync(newClientGrantRequest);
            newClientGrantResponse.Should().NotBeNull();
            newClientGrantResponse.ShouldBeEquivalentTo(newClientGrantRequest, options => options.Excluding(cg => cg.Id));

            // Get all the client grants again, and verify we have one more
            var clientGrantsAfter = await apiClient.ClientGrants.GetAllAsync();
            clientGrantsAfter.Count.Should().Be(clientGrantsBefore.Count + 1);

            // Update the client grant
            var updateClientGrantRequest = new ClientGrantUpdateRequest
            {
                Scope = new List<string>
                {
                    "Scope 3"
                }
            };
            var updateClientGrantResponse = await apiClient.ClientGrants.UpdateAsync(newClientGrantResponse.Id, updateClientGrantRequest);
            updateClientGrantResponse.Should().NotBeNull();
            updateClientGrantResponse.Scope.Count.Should().Be(1);
            updateClientGrantResponse.Scope[0].Should().Be("Scope 3");

            // Delete the client grant
            await apiClient.ClientGrants.DeleteAsync(newClientGrantResponse.Id);
        }
    }
}