using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.Connections;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Jobs;
using Auth0.ManagementApi.Users;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class JobsTestFixture : TestBaseFixture
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

public class JobsTests : IClassFixture<JobsTestFixture>
{
    private JobsTestFixture fixture;

    public JobsTests(JobsTestFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Test_jobs_send_verification_email()
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

        // Create a user
        var userEmail = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}";
        var newUser = await fixture.ApiClient.Users.CreateAsync(TestBaseUtils.CreateUserRequest(
            connection: newConnection.Name,
            email: userEmail,
            emailVerified: false,
            password: "Test123456!"
        ));
        fixture.TrackIdentifier(CleanUpType.Users, newUser.UserId);

        try
        {
            // Send verification email
            var job = await fixture.ApiClient.Jobs.VerificationEmail.CreateAsync(
                TestBaseUtils.CreateVerificationEmailJobRequest(
                    userId: newUser.UserId,
                    clientId: TestBaseUtils.GetVariable("AUTH0_CLIENT_ID")
                ));

            job.Should().NotBeNull();
            job.Id.Should().NotBeNullOrEmpty();
            job.Type.Should().Be("verification_email");
        }
        finally
        {
            await fixture.ApiClient.Users.DeleteAsync(newUser.UserId);
            fixture.UnTrackIdentifier(CleanUpType.Users, newUser.UserId);

            await fixture.ApiClient.Connections.DeleteAsync(newConnection.Id);
            fixture.UnTrackIdentifier(CleanUpType.Connections, newConnection.Id);
        }
    }

    [Fact]
    public async Task Test_jobs_send_verification_email_with_identity()
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

        // Create a user
        var userEmail = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}";
        var newUser = await fixture.ApiClient.Users.CreateAsync(TestBaseUtils.CreateUserRequest(
            connection: newConnection.Name,
            email: userEmail,
            emailVerified: false,
            password: "Test123456!"
        ));
        fixture.TrackIdentifier(CleanUpType.Users, newUser.UserId);

        try
        {
            // Send verification email with identity
            var job = await fixture.ApiClient.Jobs.VerificationEmail.CreateAsync(
                TestBaseUtils.CreateVerificationEmailJobRequest(
                    userId: newUser.UserId,
                    clientId: TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
                    identity: new Identity
                    {
                        UserId = newUser.UserId.Replace("auth0|", ""),
                        Provider = IdentityProviderEnum.Auth0
                    }
                ));

            job.Should().NotBeNull();
            job.Id.Should().NotBeNullOrEmpty();
        }
        finally
        {
            await fixture.ApiClient.Users.DeleteAsync(newUser.UserId);
            fixture.UnTrackIdentifier(CleanUpType.Users, newUser.UserId);

            await fixture.ApiClient.Connections.DeleteAsync(newConnection.Id);
            fixture.UnTrackIdentifier(CleanUpType.Connections, newConnection.Id);
        }
    }

    [Fact]
    public async Task Test_jobs_get_status()
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

        // Create a user
        var userEmail = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}";
        var newUser = await fixture.ApiClient.Users.CreateAsync(TestBaseUtils.CreateUserRequest(
            connection: newConnection.Name,
            email: userEmail,
            emailVerified: false,
            password: "Test123456!"
        ));
        fixture.TrackIdentifier(CleanUpType.Users, newUser.UserId);

        try
        {
            // Send verification email
            var job = await fixture.ApiClient.Jobs.VerificationEmail.CreateAsync(
                TestBaseUtils.CreateVerificationEmailJobRequest(
                    userId: newUser.UserId,
                    clientId: TestBaseUtils.GetVariable("AUTH0_CLIENT_ID")
                ));

            // Get job status
            var jobStatus = await fixture.ApiClient.Jobs.GetAsync(job.Id);
            jobStatus.Should().NotBeNull();
            jobStatus.Id.Should().Be(job.Id);
            jobStatus.Type.Should().Be("verification_email");
            jobStatus.Status.Should().NotBeNullOrEmpty();
        }
        finally
        {
            await fixture.ApiClient.Users.DeleteAsync(newUser.UserId);
            fixture.UnTrackIdentifier(CleanUpType.Users, newUser.UserId);

            await fixture.ApiClient.Connections.DeleteAsync(newConnection.Id);
            fixture.UnTrackIdentifier(CleanUpType.Connections, newConnection.Id);
        }
    }

    [Fact]
    public async Task Test_jobs_import_users()
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
            // Create import file content
            var users = new[]
            {
                new { email = $"import-user-1-{Guid.NewGuid():N}@example.com", email_verified = true },
                new { email = $"import-user-2-{Guid.NewGuid():N}@example.com", email_verified = true }
            };
            var usersJson = JsonSerializer.Serialize(users);
            var usersBytes = Encoding.UTF8.GetBytes(usersJson);
            using var usersStream = new MemoryStream(usersBytes);

            // Import users
            var job = await fixture.ApiClient.Jobs.UsersImports.CreateAsync(new CreateImportUsersRequestContent
            {
                ConnectionId = newConnection.Id,
                Users = new FileParameter { Stream = usersStream, FileName = "users.json", ContentType = "application/json" },
                Upsert = false,
                SendCompletionEmail = false
            });

            job.Should().NotBeNull();
            job.Id.Should().NotBeNullOrEmpty();
            job.Type.Should().Be("users_import");
        }
        finally
        {
            await fixture.ApiClient.Connections.DeleteAsync(newConnection.Id);
            fixture.UnTrackIdentifier(CleanUpType.Connections, newConnection.Id);
        }
    }

    [Fact]
    public async Task Test_jobs_export_users()
    {
        // Create an export job
        var job = await fixture.ApiClient.Jobs.UsersExports.CreateAsync(new CreateExportUsersRequestContent
        {
            ConnectionId = null, // Clear SDK default to export all users
            Format = JobFileFormatEnum.Json,
            Limit = 5,
            Fields = new List<CreateExportUsersFields>
            {
                new CreateExportUsersFields { Name = "user_id" },
                new CreateExportUsersFields { Name = "email" },
                new CreateExportUsersFields { Name = "name" }
            }
        });

        job.Should().NotBeNull();
        job.Id.Should().NotBeNullOrEmpty();
        job.Type.Should().Be("users_export");
    }

    [Fact(Skip = "Requires a failed job ID to test")]
    public async Task Test_jobs_get_error_details()
    {
        // Note: This test requires a failed job ID which we don't have in normal tests
        // The API call would be:
        // var errors = await fixture.ApiClient.Jobs.Errors.GetAsync("job_id");
        // errors.Should().NotBeNull();

        await Task.CompletedTask;
    }
}
