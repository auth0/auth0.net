using System;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class ConnectionTests : TestBase
    {
        [Fact]
        public async Task Test_connection_crud_sequence()
        {
            string token = await GenerateManagementApiToken();

            var apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));

            // Get all connections before
            var connectionsBefore = await apiClient.Connections.GetAllAsync("github");

            // Create a new connection
            var newConnectionRequest = new ConnectionCreateRequest
            {
                Name = Guid.NewGuid().ToString("N"),
                Strategy = "github"
            };
            var newConnectionResponse = await apiClient.Connections.CreateAsync(newConnectionRequest);
            newConnectionResponse.Should().NotBeNull();
            newConnectionResponse.Name.Should().Be(newConnectionRequest.Name);
            newConnectionResponse.Strategy.Should().Be(newConnectionRequest.Strategy);

            // Get all connections again
            var connectionsAfter = await apiClient.Connections.GetAllAsync("github");
            connectionsAfter.Count.Should().Be(connectionsBefore.Count + 1);

            // Update a connection
            var updateConnectionRequest = new ConnectionUpdateRequest
            {
                Options = new
                {
                    a = "123"
                }
            };
            var updateConnectionResponse = await apiClient.Connections.UpdateAsync(newConnectionResponse.Id, updateConnectionRequest);
            //updateConnectionResponse.Name.Should().Be(updateConnectionRequest.Name);

            // Get a single connection
            var connection = await apiClient.Connections.GetAsync(newConnectionResponse.Id);
            connection.Should().NotBeNull();
            //connection.Name.Should().Be(updateConnectionResponse.Name);

            // Delete the connection and ensure we get exception when trying to get connection again
            await apiClient.Connections.DeleteAsync(newConnectionResponse.Id);
            Func<Task> getFunc = async () => await apiClient.Connections.GetAsync(newConnectionResponse.Id);
            getFunc.ShouldThrow<ApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_connection");
        }
    }
}
