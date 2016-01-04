using System;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using NUnit.Framework;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    [TestFixture]
    public class TicketsTests : TestBase
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
                    actions = new string[] { "create", "delete" }
                },
                connections = new
                {
                    actions = new string[] { "create", "delete" }
                },
                user_tickets = new
                {
                    actions = new string[] { "create" }
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
        public async Task Test_tickets_sequence()
        {
            // Send email verification ticket
            var verificationTicketRequest = new EmailVerificationTicketRequest
            {
                UserId = user.UserId,
                ResultUrl = "http://www.nonexistingdomain.aaa/success"
            };
            var verificationTicketResponse = await apiClient.Tickets.CreateEmailVerificationTicket(verificationTicketRequest);
            verificationTicketResponse.Should().NotBeNull();
            verificationTicketResponse.Value.Should().NotBeNull();

            // Send password change ticket
            var changeTicketRequest = new PasswordChangeTicketRequest
            {
                UserId = user.UserId,
                ResultUrl = "http://www.nonexistingdomain.aaa/success",
                NewPassword = "password"
            };
            var changeTicketRsponse = await apiClient.Tickets.CreatePasswordChangeTicket(changeTicketRequest);
            changeTicketRsponse.Should().NotBeNull();
            changeTicketRsponse.Value.Should().NotBeNull();
        }
    }
}