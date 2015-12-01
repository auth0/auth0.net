using System;
using System.Threading.Tasks;
using Auth0.Core;
using FluentAssertions;
using NUnit.Framework;
using Auth0.ManagementApi.Client.Models;

namespace Auth0.ManagementApi.Client.IntegrationTests
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
            apiClient = new ManagementApiClient(GetVariable("AUTH0_TOKEN_TICKETS"), new Uri(GetVariable("AUTH0_API_URL")));

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