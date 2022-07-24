using System;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;
using Auth0.ManagementApi.Paging;
using System.Collections.Generic;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class ConnectionTestsFixture : TestBaseFixture
    {
        public override async Task DisposeAsync()
        {
            await ManagementTestBaseUtils.CleanupAndDisposeAsync(ApiClient, new List<CleanUpType> { CleanUpType.Connections });
        }
    }

    public class ConnectionTests : IClassFixture<ConnectionTestsFixture>
    {
        ConnectionTestsFixture fixture;

        public ConnectionTests(ConnectionTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task Test_database_connection_crud_sequence()
        {
            // Get all connections before
            var connectionsBefore = await fixture.ApiClient.Connections.GetAllAsync(new GetConnectionsRequest
            {
                Strategy = new[] { "auth0" }
            }, new PaginationInfo());

            // Create a new connection
            var name = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}";
            var displayName = "displayname";
            var newConnectionRequest = new ConnectionCreateRequest
            {
                Name = name,
                Strategy = "auth0",
                DisplayName = displayName,
                Realms = new[] { name }
            };
            var newConnectionResponse = await fixture.ApiClient.Connections.CreateAsync(newConnectionRequest);
            newConnectionResponse.Should().NotBeNull();
            newConnectionResponse.Name.Should().Be(newConnectionRequest.Name);
            newConnectionResponse.Strategy.Should().Be(newConnectionRequest.Strategy);
            newConnectionResponse.Realms.Should().BeEquivalentTo(newConnectionRequest.Realms);
            newConnectionResponse.IsDomainConnection.Should().BeFalse();
            newConnectionResponse.DisplayName.Should().Be(newConnectionRequest.DisplayName);

            // Get all connections again
            var connectionsAfter = await fixture.ApiClient.Connections.GetAllAsync(new GetConnectionsRequest
            {
                Strategy = new[] { "auth0" }
            }, new PaginationInfo());
            connectionsAfter.Count.Should().Be(connectionsBefore.Count + 1);

            // Update a connection
            var newName = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}";
            var newDisplayName = "newdisplayname";
            var updateConnectionRequest = new ConnectionUpdateRequest
            {
                Options = new
                {
                    a = "123"
                },
                Metadata = new
                {
                    b = "456"
                },
                Realms = new[] { newName },
                DisplayName = newDisplayName
            };
            var updateConnectionResponse = await fixture.ApiClient.Connections.UpdateAsync(newConnectionResponse.Id, updateConnectionRequest);
            string a = updateConnectionResponse.Options.a;
            a.Should().Be("123");
            string b = updateConnectionResponse.Metadata.b;
            b.Should().Be("456");
            updateConnectionRequest.Realms.Should().BeEquivalentTo(new[] { newName });
            updateConnectionRequest.DisplayName.Should().BeEquivalentTo(newDisplayName);

            // Get a single connection
            var connection = await fixture.ApiClient.Connections.GetAsync(newConnectionResponse.Id);
            connection.Should().NotBeNull();

            // Delete the connection and ensure we get exception when trying to get connection again
            await fixture.ApiClient.Connections.DeleteAsync(newConnectionResponse.Id);
            Func<Task> getFunc = async () => await fixture.ApiClient.Connections.GetAsync(newConnectionResponse.Id);
            getFunc.Should().Throw<ErrorApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_connection");
        }

        [Fact]
        public async Task Test_connection_crud_sequence()
        {
            // Get all connections before
            var connectionsBefore = await fixture.ApiClient.Connections.GetAllAsync(new GetConnectionsRequest
            {
                Strategy = new[] {"github"}
            }, new PaginationInfo());

            // Create a new connection
            var newConnectionRequest = new ConnectionCreateRequest
            {
                Name = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}",
                Strategy = "github",
                DisplayName = "displayname"
            };
            var newConnectionResponse = await fixture.ApiClient.Connections.CreateAsync(newConnectionRequest);
            newConnectionResponse.Should().NotBeNull();
            newConnectionResponse.Name.Should().Be(newConnectionRequest.Name);
            newConnectionResponse.Strategy.Should().Be(newConnectionRequest.Strategy);
            newConnectionResponse.DisplayName.Should().Be(newConnectionRequest.DisplayName);

            // Get all connections again
            var connectionsAfter = await fixture.ApiClient.Connections.GetAllAsync(new GetConnectionsRequest
            {
                Strategy = new[] {"github"}
            }, new PaginationInfo());
            connectionsAfter.Count.Should().Be(connectionsBefore.Count + 1);

            // Update a connection
            var newDisplayName = "newdisplayname";
            var updateConnectionRequest = new ConnectionUpdateRequest
            {
                Options = new
                {
                    a = "123"
                },
                Metadata = new
                {
                    b = "456"
                },
                DisplayName = newDisplayName
            };
            var updateConnectionResponse = await fixture.ApiClient.Connections.UpdateAsync(newConnectionResponse.Id, updateConnectionRequest);
            string a = updateConnectionResponse.Options.a;
            a.Should().Be("123");
            string b = updateConnectionResponse.Metadata.b;
            b.Should().Be("456");
            newDisplayName.Should().BeEquivalentTo(updateConnectionResponse.DisplayName);

            // Get a single connection
            var connection = await fixture.ApiClient.Connections.GetAsync(newConnectionResponse.Id);
            connection.Should().NotBeNull();

            // Delete the connection and ensure we get exception when trying to get connection again
            await fixture.ApiClient.Connections.DeleteAsync(newConnectionResponse.Id);
            Func<Task> getFunc = async () => await fixture.ApiClient.Connections.GetAsync(newConnectionResponse.Id);
            getFunc.Should().Throw<ErrorApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_connection");
        }

        [Fact]
        public async Task Test_when_paging_not_specified_does_not_include_totals()
        {
            // Act
            var connections = await fixture.ApiClient.Connections.GetAllAsync(new GetConnectionsRequest(), new PaginationInfo());

            // Assert
            Assert.Null(connections.Paging);
        }

        [Fact]
        public async Task Test_paging_does_not_include_totals()
        {
            // Act
            var connections = await fixture.ApiClient.Connections.GetAllAsync(new GetConnectionsRequest(), new PaginationInfo(0, 50, false));

            // Assert
            Assert.Null(connections.Paging);
        }

        [Fact]
        public async Task Test_paging_includes_totals()
        {
            // Act
            var connections = await fixture.ApiClient.Connections.GetAllAsync(new GetConnectionsRequest(), new PaginationInfo(0, 50, true));

            // Assert
            Assert.NotNull(connections.Paging);
        }

        [Fact]
        public async Task Test_multiple_strategies()
        {
            // Act
            var connections = await fixture.ApiClient.Connections.GetAllAsync(new GetConnectionsRequest
            {
                Strategy = new[] { "google-oauth2", "auth0" }
            }, new PaginationInfo());

            // Assert
            Assert.NotNull(connections);
        }
    }
}
