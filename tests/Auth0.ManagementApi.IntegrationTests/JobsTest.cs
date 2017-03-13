using System;
using System.IO;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class JobsTest : TestBase, IAsyncLifetime
    {
        private ManagementApiClient apiClient;
        private Connection connection;
        private User user;

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            apiClient = new ManagementApiClient(token, new Uri(GetVariable("AUTH0_MANAGEMENT_API_URL")));

            // Create a connection
            connection = await apiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = Guid.NewGuid().ToString("N"),
                Strategy = "auth0",
                EnabledClients = new[] { GetVariable("AUTH0_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
            });

            // Create a user
            user = await apiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = connection.Name,
                Email = $"{Guid.NewGuid().ToString("N")}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = "password"
            });
        }

        public async Task DisposeAsync()
        {
            await apiClient.Users.DeleteAsync(user.UserId);
            await apiClient.Connections.DeleteAsync(connection.Id);
        }

        [Fact]
        public async Task Test_jobs_sequence()
        {

            // Send an email verification request
            var emailRequest = new VerifyEmailJobRequest
            {
                UserId = user.UserId
            };
            var emailRequestResponse = await apiClient.Jobs.SendVerificationEmailAsync(emailRequest);
            emailRequestResponse.Should().NotBeNull();
            emailRequestResponse.Id.Should().NotBeNull();

            // Check to see whether we can get the exact same job again
            var job = await apiClient.Jobs.GetAsync(emailRequestResponse.Id);
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