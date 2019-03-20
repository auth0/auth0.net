using System;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class TicketsTests : TestBase, IAsyncLifetime
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
                Name = Guid.NewGuid().ToString("N"),
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
        }

        [Fact]
        public async Task Test_tickets_sequence()
        {
            // Send email verification ticket
            var verificationTicketRequest = new EmailVerificationTicketRequest
            {
                UserId = _user.UserId,
                ResultUrl = "http://www.nonexistingdomain.aaa/success"
            };
            var verificationTicketResponse = await _apiClient.Tickets.CreateEmailVerificationTicketAsync(verificationTicketRequest);
            verificationTicketResponse.Should().NotBeNull();
            verificationTicketResponse.Value.Should().NotBeNull();

            // Send password change ticket
            var changeTicketRequest = new PasswordChangeTicketRequest
            {
                UserId = _user.UserId,
                ResultUrl = "http://www.nonexistingdomain.aaa/success",
                MarkEmailAsVerified = true
            };
            var changeTicketRsponse = await _apiClient.Tickets.CreatePasswordChangeTicketAsync(changeTicketRequest);
            changeTicketRsponse.Should().NotBeNull();
            changeTicketRsponse.Value.Should().NotBeNull();
        }
    }
}