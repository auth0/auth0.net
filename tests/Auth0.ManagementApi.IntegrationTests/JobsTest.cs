using System;
using System.IO;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using NUnit.Framework;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    [TestFixture]
    public class JobsTest : TestBase
    {
        private ManagementApiClient apiClient;
        private Connection connection;
        private User user;

        [SetUp]
        public async Task SetUp()
        {
            var scopes = new
            {
                users = new
                {
                    actions = new string[] { "create", "delete", "update" }
                },
                connections = new
                {
                    actions = new string[] { "create", "delete" }
                }
            };
            string token = GenerateToken(scopes);

            apiClient = new ManagementApiClient(token, new Uri(GetVariable("AUTH0_MANAGEMENT_API_URL")));

            // Create a connection
            connection = await apiClient.Connections.Create(new ConnectionCreateRequest
            {
                Name = Guid.NewGuid().ToString("N"),
                Strategy = "auth0",
                EnabledClients = new[] { "rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW" }
            });

            // Create a user
            user = await apiClient.Users.Create(new UserCreateRequest
            {
                Connection = connection.Name,
                Email = $"{Guid.NewGuid().ToString("N")}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = "password"
            });
        }

        [TearDown]
        public async Task TearDown()
        {
            await apiClient.Users.Delete(user.UserId);
            await apiClient.Connections.Delete(connection.Id);
        }

        [Test]
        public async Task Test_jobs_sequence()
        {

            // Send an email verification request
            var emailRequest = new VerifyEmailJobRequest
            {
                UserId = user.UserId
            };
            var emailRequestResponse = await apiClient.Jobs.SendVerificationEmail(emailRequest);
            emailRequestResponse.Should().NotBeNull();
            emailRequestResponse.Id.Should().NotBeNull();

            // Check to see whether we can get the exact same job again
            var job = await apiClient.Jobs.Get(emailRequestResponse.Id);
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