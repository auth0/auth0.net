using System;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class ConnectionTests : TestBase, IAsyncLifetime
    {
        private ManagementApiClient _apiClient;

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            _apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async Task Test_connection_crud_sequence()
        {
            // Get all connections before
            var connectionsBefore = await _apiClient.Connections.GetAllAsync(new GetConnectionsRequest
            {
                Strategy = new[] {"github"}
            });

            // Create a new connection
            var newConnectionRequest = new ConnectionCreateRequest
            {
                Name = Guid.NewGuid().ToString("N"),
                Strategy = "github"
            };
            var newConnectionResponse = await _apiClient.Connections.CreateAsync(newConnectionRequest);
            newConnectionResponse.Should().NotBeNull();
            newConnectionResponse.Name.Should().Be(newConnectionRequest.Name);
            newConnectionResponse.Strategy.Should().Be(newConnectionRequest.Strategy);

            // Get all connections again
            var connectionsAfter = await _apiClient.Connections.GetAllAsync(new GetConnectionsRequest
            {
                Strategy = new[] {"github"}
            });
            connectionsAfter.Count.Should().Be(connectionsBefore.Count + 1);

            // Update a connection
            var updateConnectionRequest = new ConnectionUpdateRequest
            {
                Options = new
                {
                    a = "123"
                },
                Metadata = new
                {
                    b = "456"
                }
            };
            var updateConnectionResponse = await _apiClient.Connections.UpdateAsync(newConnectionResponse.Id, updateConnectionRequest);
            string a = updateConnectionResponse.Options.a;
            a.Should().Be("123");
            string b = updateConnectionResponse.Metadata.b;
            b.Should().Be("456");

            // Get a single connection
            var connection = await _apiClient.Connections.GetAsync(newConnectionResponse.Id);
            connection.Should().NotBeNull();

            // Delete the connection and ensure we get exception when trying to get connection again
            await _apiClient.Connections.DeleteAsync(newConnectionResponse.Id);
            Func<Task> getFunc = async () => await _apiClient.Connections.GetAsync(newConnectionResponse.Id);
            getFunc.ShouldThrow<ApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_connection");
        }
        
        [Fact]
        public async Task Test_when_paging_not_specified_does_not_include_totals()
        {
            // Act
            var connections = await _apiClient.Connections.GetAllAsync(new GetConnectionsRequest());
            
            // Assert
            Assert.Null(connections.Paging);
        }

        [Fact]
        public async Task Test_paging_does_not_include_totals()
        {
            // Act
            var connections = await _apiClient.Connections.GetAllAsync(new GetConnectionsRequest(), new PaginationInfo(0, 50, false));
            
            // Assert
            Assert.Null(connections.Paging);
        }

        [Fact]
        public async Task Test_paging_includes_totals()
        {
            // Act
            var connections = await _apiClient.Connections.GetAllAsync(new GetConnectionsRequest(), new PaginationInfo(0, 50, true));
            
            // Assert
            Assert.NotNull(connections.Paging);
        }
    }
}
