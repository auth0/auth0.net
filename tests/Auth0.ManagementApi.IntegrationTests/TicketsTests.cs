using System;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;
using System.Collections.Generic;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class TicketsTests : ManagementTestBase, IAsyncLifetime
    {
        private Connection _authConnection;
        private Connection _emailConnection;
        private User _auth0User;
        private User _emailUser;
        private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            ApiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 }));

            _authConnection = await ApiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = $"{TestingConstants.ConnectionPrefix}-{MakeRandomName()}",
                Strategy = "auth0",
                EnabledClients = new[] { GetVariable("AUTH0_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
            });

            _emailConnection = await ApiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = $"{TestingConstants.ConnectionPrefix}-{MakeRandomName()}",
                Strategy = "email",
                EnabledClients = new[] { GetVariable("AUTH0_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
            });

            _auth0User = await ApiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = _authConnection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            });

            _emailUser = await ApiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = _emailConnection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
            });
        }

        public override async Task DisposeAsync()
        {
            await ApiClient.Users.DeleteAsync(_auth0User.UserId);
            await ApiClient.Connections.DeleteAsync(_authConnection.Id);

            await ApiClient.Users.DeleteAsync(_emailUser.UserId);
            await ApiClient.Connections.DeleteAsync(_emailConnection.Id);

            await CleanupAndDisposeAsync();
        }

        [Fact]
        public async Task Test_tickets_sequence()
        {
            var existingOrganizationId = "org_Jif6mLeWXT5ec0nu";

            await ApiClient.Organizations.AddMembersAsync(existingOrganizationId, new OrganizationAddMembersRequest
            {
                Members = new List<string> { _auth0User.UserId }
            });

            // Send email verification ticket
            var verificationTicketRequest = new EmailVerificationTicketRequest
            {
                UserId = _auth0User.UserId,
                OrganizationId = "org_Jif6mLeWXT5ec0nu"
            };
            var verificationTicketResponse = await ApiClient.Tickets.CreateEmailVerificationTicketAsync(verificationTicketRequest);
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
            var changeTicketRsponse = await ApiClient.Tickets.CreatePasswordChangeTicketAsync(changeTicketRequest);
            changeTicketRsponse.Should().NotBeNull();
            changeTicketRsponse.Value.Should().NotBeNull();

            await ApiClient.Organizations.DeleteMemberAsync(existingOrganizationId, new OrganizationDeleteMembersRequest
            {
                Members = new List<string> { _auth0User.UserId }
            });
        }

        [Fact]
        public async Task Can_send_verification_email_with_identity()
        {
            var verificationTicketResponse = await ApiClient.Tickets.CreateEmailVerificationTicketAsync(new EmailVerificationTicketRequest
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