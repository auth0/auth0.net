using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class JobsTest : TestBase, IAsyncLifetime
    {
        private ManagementApiClient _apiClient;
        private Connection _connection;
        private User _user;
        private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            _apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));

            // Create a connection
            _connection = await _apiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = "Temp-Int-Test-" + MakeRandomName(),
                Strategy = "auth0",
                EnabledClients = new[] { GetVariable("AUTH0_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
            });

            // Create a user
            _user = await _apiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            });
        }

        public async Task DisposeAsync()
        {
            await _apiClient.Users.DeleteAsync(_user.UserId);
            await _apiClient.Connections.DeleteAsync(_connection.Id);
            _apiClient.Dispose();
        }

        [Fact]
        public async Task Can_send_verification_email()
        {
            var sendVerification = await _apiClient.Jobs.SendVerificationEmailAsync(new VerifyEmailJobRequest
            {
                UserId = _user.UserId,
                ClientId = GetVariable("AUTH0_CLIENT_ID")
            });
            sendVerification.Should().NotBeNull();
            sendVerification.Id.Should().NotBeNull();

            // Check to see whether we can get the same job again
            var job = await _apiClient.Jobs.GetAsync(sendVerification.Id);
            job.Should().NotBeNull();
            job.Id.Should().Be(sendVerification.Id);
            job.Type.Should().Be("verification_email");
            job.Status.Should().Be("pending");
            job.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromMinutes(5));
        }

        [Fact]
        public async Task Can_import_users()
        {
            // Send a user import request
            using (var stream = GetType().Assembly.GetManifestResourceStream("Auth0.ManagementApi.IntegrationTests.user-import-test.json"))
            {
                var importUsers = await _apiClient.Jobs.ImportUsersAsync(_connection.Id, "user-import-test.json", stream, sendCompletionEmail: false);
                importUsers.Should().NotBeNull();
                importUsers.Id.Should().NotBeNull();
                importUsers.Type.Should().Be("users_import");
                importUsers.Status.Should().Be("pending");
                importUsers.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromMinutes(5));
                importUsers.ConnectionId.Should().Be(_connection.Id);
                importUsers.Connection.Should().Be(_connection.Name);
            }
        }
    }
}