using System;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using System.Collections.Generic;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class TicketsTestsFixture : TestBaseFixture
    {

        public Connection AuthConnection;
        public Connection EmailConnection;
        public User Auth0User;
        public User EmailUser;
        public const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            AuthConnection = await ApiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}",
                Strategy = "auth0",
                EnabledClients = new[] { TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
            });

            TrackIdentifier(CleanUpType.Connections, AuthConnection.Id);

            EmailConnection = await ApiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}",
                Strategy = "email",
                EnabledClients = new[] { TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
            });

            TrackIdentifier(CleanUpType.Connections, EmailConnection.Id);

            Auth0User = await ApiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = AuthConnection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            });

            TrackIdentifier(CleanUpType.Users, Auth0User.UserId);

            EmailUser = await ApiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = EmailConnection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
            });

            TrackIdentifier(CleanUpType.Users, EmailUser.UserId);
        }


        public override async Task DisposeAsync()
        {
            foreach (KeyValuePair<CleanUpType, IList<string>> entry in identifiers)
            {
                await ManagementTestBaseUtils.CleanupAsync(ApiClient, entry.Key, entry.Value);
            }

            ApiClient.Dispose();
        }
    }

    public class TicketsTests : IClassFixture<TicketsTestsFixture>
    {

        TicketsTestsFixture fixture;

        public TicketsTests(TicketsTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task Test_tickets_sequence()
        {
            var existingOrganizationId = "org_V6ojENVd1ERs5YY1";

            await fixture.ApiClient.Organizations.AddMembersAsync(existingOrganizationId, new OrganizationAddMembersRequest
            {
                Members = new List<string> { fixture.Auth0User.UserId }
            });

            // Send email verification ticket
            var verificationTicketRequest = new EmailVerificationTicketRequest
            {
                UserId = fixture.Auth0User.UserId,
                OrganizationId = "org_V6ojENVd1ERs5YY1"
            };
            var verificationTicketResponse = await fixture.ApiClient.Tickets.CreateEmailVerificationTicketAsync(verificationTicketRequest);
            verificationTicketResponse.Should().NotBeNull();
            verificationTicketResponse.Value.Should().NotBeNull();

            // Send password change ticket
            var changeTicketRequest = new PasswordChangeTicketRequest
            {
                UserId = fixture.Auth0User.UserId,
                ResultUrl = "http://www.nonexistingdomain.aaa/success",
                MarkEmailAsVerified = true,
                IncludeEmailInRedirect = true,
            };
            var changeTicketRsponse = await fixture.ApiClient.Tickets.CreatePasswordChangeTicketAsync(changeTicketRequest);
            changeTicketRsponse.Should().NotBeNull();
            changeTicketRsponse.Value.Should().NotBeNull();

            await fixture.ApiClient.Organizations.DeleteMemberAsync(existingOrganizationId, new OrganizationDeleteMembersRequest
            {
                Members = new List<string> { fixture.Auth0User.UserId }
            });
        }

        [Fact]
        public async Task Can_send_verification_email_with_identity()
        {
            var verificationTicketResponse = await fixture.ApiClient.Tickets.CreateEmailVerificationTicketAsync(new EmailVerificationTicketRequest
            {
                UserId = fixture.EmailUser.UserId,
                ResultUrl = "http://www.nonexistingdomain.aaa/success",
                Identity = new EmailVerificationIdentity
                {
                    Provider = "email",
                    UserId = fixture.EmailUser.UserId.Replace("email|", "")
                }
            });
            verificationTicketResponse.Should().NotBeNull();
            verificationTicketResponse.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Can_send_verification_email_with_client_id()
        {
            var verificationTicketResponse = await fixture.ApiClient.Tickets.CreateEmailVerificationTicketAsync(new EmailVerificationTicketRequest
            {
                UserId = fixture.Auth0User.UserId,
                ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID")
            });
            verificationTicketResponse.Should().NotBeNull();
            verificationTicketResponse.Value.Should().NotBeNull();
        }
    }
}