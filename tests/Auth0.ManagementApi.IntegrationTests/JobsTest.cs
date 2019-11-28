using System;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;

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
        public async Task Test_jobs_sequence()
        {

            // Send an email verification request
            var emailRequest = new VerifyEmailJobRequest
            {
                UserId = _user.UserId,
                ClientId = GetVariable("AUTH0_CLIENT_ID")
            };
            var emailRequestResponse = await _apiClient.Jobs.SendVerificationEmailAsync(emailRequest);
            emailRequestResponse.Should().NotBeNull();
            emailRequestResponse.Id.Should().NotBeNull();

            // Check to see whether we can get the exact same job again
            var job = await _apiClient.Jobs.GetAsync(emailRequestResponse.Id);
            job.Should().NotBeNull();
            job.Id.Should().Be(emailRequestResponse.Id);

            // Send a user import request
            //using (Stream stream = this.GetType().Assembly.GetManifestResourceStream("Auth0.ManagementApi.IntegrationTests.user-import-test.json"))
            //{
            //    var importUsersResponse = await apiClient.Jobs.ImportUsers(connection.Id, "user-import-test.json", stream);
            //    importUsersResponse.Should().NotBeNull();
            //    importUsersResponse.Id.Should().NotBeNull();
            //}
        }
    }
}