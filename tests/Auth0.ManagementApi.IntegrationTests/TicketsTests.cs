using System;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;
using System.Collections.Generic;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class TicketsTests : TestBase, IAsyncLifetime
    {
        private ManagementApiClient _apiClient;
        private Connection _authConnection;
        private Connection _emailConnection;
        private User _auth0User;
        private User _emailUser;
        private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            _apiClient = new TestManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));

            _authConnection = await _apiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = "Temp-Int-Test-" + MakeRandomName(),
                Strategy = "auth0",
                EnabledClients = new[] { GetVariable("AUTH0_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
            });

            _emailConnection = await _apiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = "Temp-Int-Test-" + MakeRandomName(),
                Strategy = "email",
                EnabledClients = new[] { GetVariable("AUTH0_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
            });

            _auth0User = await _apiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = _authConnection.Name,
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            });

            _emailUser = await _apiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = _emailConnection.Name,
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
            });
        }

        public async Task DisposeAsync()
        {
            await _apiClient.Users.DeleteAsync(_auth0User.UserId);
            await _apiClient.Connections.DeleteAsync(_authConnection.Id);

            await _apiClient.Users.DeleteAsync(_emailUser.UserId);
            await _apiClient.Connections.DeleteAsync(_emailConnection.Id);
            _apiClient.Dispose();
        }

        [Fact]
        public async Task Test_tickets_sequence()
        {
            var existingOrganizationId = "org_Jif6mLeWXT5ec0nu";

            await _apiClient.Organizations.AddMembersAsync(existingOrganizationId, new OrganizationAddMembersRequest
            {
                Members = new List<string> { _auth0User.UserId }
            });

            // Send email verification ticket
            var verificationTicketRequest = new EmailVerificationTicketRequest
            {
                UserId = _auth0User.UserId,
                OrganizationId = "org_Jif6mLeWXT5ec0nu"
            };
            var verificationTicketResponse = await _apiClient.Tickets.CreateEmailVerificationTicketAsync(verificationTicketRequest);
            verificationTicketResponse.Should().NotBeNull();
            verificationTicketResponse.Value.Should().NotBeNull();

            // Send password change ticket
            var changeTicketRequest = new PasswordChangeTicketRequest
            {
                UserId = _auth0User.UserId,
                ResultUrl = "http://www.nonexistingdomain.aaa/success",
                MarkEmailAsVerified = true,
                IncludeEmailInRedirect = true,
            };
            var changeTicketRsponse = await _apiClient.Tickets.CreatePasswordChangeTicketAsync(changeTicketRequest);
            changeTicketRsponse.Should().NotBeNull();
            changeTicketRsponse.Value.Should().NotBeNull();

            await _apiClient.Organizations.DeleteMemberAsync(existingOrganizationId, new OrganizationDeleteMembersRequest
            {
                Members = new List<string> { _auth0User.UserId }
            });
        }

        [Fact]
        public async Task Can_send_verification_email_with_identity()
        {
            var verificationTicketResponse = await _apiClient.Tickets.CreateEmailVerificationTicketAsync(new EmailVerificationTicketRequest
            {
                UserId = _emailUser.UserId,
                ResultUrl = "http://www.nonexistingdomain.aaa/success",
                Identity = new EmailVerificationIdentity
                {
                    Provider = "email",
                    UserId = _emailUser.UserId.Replace("email|", "")
                }
            });
            verificationTicketResponse.Should().NotBeNull();
            verificationTicketResponse.Value.Should().NotBeNull();
        }
    }
}