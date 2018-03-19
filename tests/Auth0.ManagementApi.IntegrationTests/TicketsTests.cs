using System;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class TicketsTests : TestBase, IAsyncLifetime
    {
        private ManagementApiClient apiClient;
        private Connection connection;
        private User user;
        private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));

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
                Password = Password
            });
        }

        public async Task DisposeAsync()
        {
            await apiClient.Users.DeleteAsync(user.UserId);
            await apiClient.Connections.DeleteAsync(connection.Id);
        }

        [Fact]
        public async Task Test_tickets_sequence()
        {
            // Send email verification ticket
            var verificationTicketRequest = new EmailVerificationTicketRequest
            {
                UserId = user.UserId,
                ResultUrl = "http://www.nonexistingdomain.aaa/success"
            };
            var verificationTicketResponse = await apiClient.Tickets.CreateEmailVerificationTicketAsync(verificationTicketRequest);
            verificationTicketResponse.Should().NotBeNull();
            verificationTicketResponse.Value.Should().NotBeNull();

            // Send password change ticket
            var changeTicketRequest = new PasswordChangeTicketRequest
            {
                UserId = user.UserId,
                ResultUrl = "http://www.nonexistingdomain.aaa/success",
                NewPassword = Password
            };
            var changeTicketRsponse = await apiClient.Tickets.CreatePasswordChangeTicketAsync(changeTicketRequest);
            changeTicketRsponse.Should().NotBeNull();
            changeTicketRsponse.Value.Should().NotBeNull();
        }
    }
}