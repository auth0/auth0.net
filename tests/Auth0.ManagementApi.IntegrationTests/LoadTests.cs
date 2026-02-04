using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.Connections;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Users;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class LoadTestsFixture : TestBaseFixture
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

public class LoadTests : IClassFixture<LoadTestsFixture>
{
    private LoadTestsFixture fixture;

    public LoadTests(LoadTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact(Skip = "Load test - run manually")]
    public async Task Test_create_many_users()
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

        try
        {
            // Create multiple users in parallel
            var tasks = Enumerable.Range(0, 100).Select(async i =>
            {
                var user = await fixture.ApiClient.Users.CreateAsync(TestBaseUtils.CreateUserRequest(
                    connection: newConnection.Name,
                    email: $"test-user-{i}-{Guid.NewGuid():N}@example.com",
                    emailVerified: true,
                    password: "Test123456!"
                ));
                fixture.TrackIdentifier(CleanUpType.Users, user.UserId);
                return user;
            }).ToList();

            var users = await Task.WhenAll(tasks);
            users.Length.Should().Be(100);
        }
        finally
        {
            await fixture.ApiClient.Connections.DeleteAsync(newConnection.Id);
            fixture.UnTrackIdentifier(CleanUpType.Connections, newConnection.Id);
        }
    }
}
