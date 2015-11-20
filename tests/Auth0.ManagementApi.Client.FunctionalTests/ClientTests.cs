using System;
using System.Configuration;
using System.Threading.Tasks;
using Auth0.Core.Models;
using Auth0.ManagementApi.Client.Exceptions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Auth0.ManagementApi.Client.FunctionalTests
{
    [TestClass]
    public class ClientTests : TestBase
    {
        [TestMethod]
        public async Task Test_client_crud_sequence()
        {
            var apiClient = new ManagementApiClient(GetVariable("AUTH0_TOKEN_CLIENTS"), new Uri(GetVariable("AUTH0_API_URL")));

            // Get all clients
            var clientsBefore = await apiClient.Clients.GetAll();

            // Add a new client
            var newClientRequest = new ClientCreateRequest
            {
                Name = "Integration testing client"
            };
            var newClientResponse = await apiClient.Clients.Create(newClientRequest);
            newClientResponse.Should().NotBeNull();
            newClientResponse.Name.Should().Be(newClientRequest.Name);

            // Get all clients again, and ensure we have one client more
            var clientsAfter = await apiClient.Clients.GetAll();
            clientsAfter.Count.Should().Be(clientsBefore.Count + 1);

            // Update the client
            var updateClientRequest = new ClientUpdateRequest
            {
                Name = "Integration testing client - Updated"
            };
            var updateClientResponse = await apiClient.Clients.Update(newClientResponse.ClientId, updateClientRequest);
            updateClientResponse.Should().NotBeNull();
            updateClientResponse.Name.Should().Be(updateClientRequest.Name);

            // Get a single client
            var client = await apiClient.Clients.Get(newClientResponse.ClientId);
            client.Should().NotBeNull();
            client.Name.Should().Be(updateClientResponse.Name);

            // Delete the client, and ensure we get exception when trying to fetch client again
            await apiClient.Clients.Delete(client.ClientId);
            Func<Task> getFunc = async () => await apiClient.Clients.Get(newClientResponse.ClientId);
            getFunc.ShouldThrow<ApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_client");
        }
    }
}
