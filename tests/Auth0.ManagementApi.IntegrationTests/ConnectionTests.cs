using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.Connections;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class ConnectionTestsFixture : TestBaseFixture
{
    public override async Task DisposeAsync()
    {
        foreach (KeyValuePair<CleanUpType, IList<string>> entry in identifiers)
        {
            await ManagementTestBaseUtils.CleanupAsync(ApiClient, entry.Key, entry.Value);
        }

        ApiClient.Dispose();
    }
}

public class ConnectionTests : IClassFixture<ConnectionTestsFixture>
{
    private ConnectionTestsFixture fixture;

    public ConnectionTests(ConnectionTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Test_connection_crud_sequence()
    {
        // Get all connections before
        var connectionsPager = await fixture.ApiClient.Connections.ListAsync(new ListConnectionsQueryParameters());
        var connectionsBefore = connectionsPager.CurrentPage.Items.ToList();

        // Create a new connection
        var connectionName = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}";
        var newConnection = await fixture.ApiClient.Connections.CreateAsync(new CreateConnectionRequestContent
        {
            Name = connectionName,
            Strategy = ConnectionIdentityProviderEnum.Auth0,
            EnabledClients = new[] { TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
        });
        newConnection.Should().NotBeNull();
        newConnection.Id.Should().NotBeNull();
        newConnection.Name.Should().Be(connectionName);

        fixture.TrackIdentifier(CleanUpType.Connections, newConnection.Id);

        // Get the specific connection
        var fetchedConnection = await fixture.ApiClient.Connections.GetAsync(newConnection.Id, new GetConnectionRequestParameters());
        fetchedConnection.Should().NotBeNull();
        fetchedConnection.Id.Should().Be(newConnection.Id);
        fetchedConnection.Name.Should().Be(newConnection.Name);

        // Update the connection
        var updateRequest = new UpdateConnectionRequestContent
        {
            DisplayName = "Updated Display Name"
        };
        var updatedConnection = await fixture.ApiClient.Connections.UpdateAsync(newConnection.Id, updateRequest);
        updatedConnection.Should().NotBeNull();
        updatedConnection.DisplayName.Should().Be(updateRequest.DisplayName);

        // Delete the connection
        await fixture.ApiClient.Connections.DeleteAsync(newConnection.Id);
        fixture.UnTrackIdentifier(CleanUpType.Connections, newConnection.Id);

        // Verify deletion
        connectionsPager = await fixture.ApiClient.Connections.ListAsync(new ListConnectionsQueryParameters());
        var connectionsAfterDelete = connectionsPager.CurrentPage.Items.ToList();
        connectionsAfterDelete.Should().NotContain(c => c.Id == newConnection.Id);
    }

    [Fact]
    public async Task Test_connection_list_by_strategy()
    {
        // Get all Auth0 connections
        var connectionsPager = await fixture.ApiClient.Connections.ListAsync(new ListConnectionsQueryParameters
        {
            Strategy = new ConnectionStrategyEnum?[] { ConnectionStrategyEnum.Auth0 }
        });

        connectionsPager.Should().NotBeNull();
        var connections = connectionsPager.CurrentPage.Items.ToList();
        connections.Should().NotBeNull();
        if (connections.Any())
        {
            connections.Should().OnlyContain(c => c.Strategy == ConnectionStrategyEnum.Auth0.Value);
        }
    }

    [Fact]
    public async Task Test_connection_check_status()
    {
        // Create a new connection
        var connectionName = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}";
        var newConnection = await fixture.ApiClient.Connections.CreateAsync(new CreateConnectionRequestContent
        {
            Name = connectionName,
            Strategy = ConnectionIdentityProviderEnum.Auth0,
            EnabledClients = new[] { TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
        });

        fixture.TrackIdentifier(CleanUpType.Connections, newConnection.Id);

        try
        {
            // Note: CheckStatus only works for AD/LDAP connections
            // For Auth0 database connections, this will throw an error
            // (BadRequestError for auth0 db connections, NotFoundError for non-existent)
            Func<Task> act = async () => await fixture.ApiClient.Connections.CheckStatusAsync(newConnection.Id);
            await act.Should().ThrowAsync<ManagementApiException>();
        }
        finally
        {
            await fixture.ApiClient.Connections.DeleteAsync(newConnection.Id);
            fixture.UnTrackIdentifier(CleanUpType.Connections, newConnection.Id);
        }
    }

    [Fact]
    public async Task Test_connection_with_options()
    {
        // Create a connection with options
        var connectionName = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}";
        var newConnection = await fixture.ApiClient.Connections.CreateAsync(new CreateConnectionRequestContent
        {
            Name = connectionName,
            Strategy = ConnectionIdentityProviderEnum.Auth0,
            EnabledClients = new[] { TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") },
            Options = new ConnectionPropertiesOptions
            {
                PasswordPolicy = ConnectionPasswordPolicyEnum.Good,
                EnableScriptContext = false,
                DisableSelfServiceChangePassword = false
            }
        });

        fixture.TrackIdentifier(CleanUpType.Connections, newConnection.Id);

        try
        {
            newConnection.Should().NotBeNull();
            newConnection.Options.Should().NotBeNull();
            // Options is returned as Dictionary<string, object?>, so we check it contains expected keys
            newConnection.Options.Should().ContainKey("passwordPolicy");
        }
        finally
        {
            await fixture.ApiClient.Connections.DeleteAsync(newConnection.Id);
            fixture.UnTrackIdentifier(CleanUpType.Connections, newConnection.Id);
        }
    }

    [Fact]
    public async Task Test_connection_with_metadata()
    {
        // Create a connection with metadata
        var connectionName = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}";
        var newConnection = await fixture.ApiClient.Connections.CreateAsync(new CreateConnectionRequestContent
        {
            Name = connectionName,
            Strategy = ConnectionIdentityProviderEnum.Auth0,
            EnabledClients = new[] { TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") },
            Metadata = new Dictionary<string, string?>
            {
                { "key1", "value1" },
                { "key2", "value2" }
            }
        });

        fixture.TrackIdentifier(CleanUpType.Connections, newConnection.Id);

        try
        {
            newConnection.Should().NotBeNull();
            newConnection.Metadata.Should().NotBeNull();
            newConnection.Metadata.Should().ContainKey("key1");
        }
        finally
        {
            await fixture.ApiClient.Connections.DeleteAsync(newConnection.Id);
            fixture.UnTrackIdentifier(CleanUpType.Connections, newConnection.Id);
        }
    }

    [Fact]
    public async Task Test_connection_users_delete_by_email()
    {
        // Create a connection
        var connectionName = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}";
        var newConnection = await fixture.ApiClient.Connections.CreateAsync(new CreateConnectionRequestContent
        {
            Name = connectionName,
            Strategy = ConnectionIdentityProviderEnum.Auth0,
            EnabledClients = new[] { TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
        });

        fixture.TrackIdentifier(CleanUpType.Connections, newConnection.Id);

        // Create a user in this connection
        var userEmail = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}";
        var newUser = await fixture.ApiClient.Users.CreateAsync(TestBaseUtils.CreateUserRequest(
            connection: newConnection.Name,
            email: userEmail,
            emailVerified: true,
            password: "Test123456!"
        ));

        fixture.TrackIdentifier(CleanUpType.Users, newUser.UserId);

        try
        {
            // Delete user by email
            await fixture.ApiClient.Connections.Users.DeleteByEmailAsync(newConnection.Id, new DeleteConnectionUsersByEmailQueryParameters
            {
                Email = userEmail
            });

            // The user should be deleted
            Func<Task> act = async () => await fixture.ApiClient.Users.GetAsync(newUser.UserId, new GetUserRequestParameters());
            await act.Should().ThrowAsync<NotFoundError>();

            fixture.UnTrackIdentifier(CleanUpType.Users, newUser.UserId);
        }
        catch
        {
            // Clean up user if test fails
            try
            {
                await fixture.ApiClient.Users.DeleteAsync(newUser.UserId);
                fixture.UnTrackIdentifier(CleanUpType.Users, newUser.UserId);
            }
            catch { }
            throw;
        }
        finally
        {
            await fixture.ApiClient.Connections.DeleteAsync(newConnection.Id);
            fixture.UnTrackIdentifier(CleanUpType.Connections, newConnection.Id);
        }
    }
}
