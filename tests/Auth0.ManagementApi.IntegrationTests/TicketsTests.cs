using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using System.Collections.Generic;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Organizations;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests;

public class TicketsTestsFixture : TestBaseFixture
{
    public CreateConnectionResponseContent AuthConnection;
    public CreateConnectionResponseContent EmailConnection;
    public CreateUserResponseContent Auth0User;
    public CreateUserResponseContent EmailUser;
    public const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

    public override async Task InitializeAsync()
    {
        await base.InitializeAsync();

        AuthConnection = await ApiClient.Connections.CreateAsync(new CreateConnectionRequestContent
        {
            Name = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}",
            Strategy = ConnectionIdentityProviderEnum.Auth0,
            EnabledClients = new[] { TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
        });

        TrackIdentifier(CleanUpType.Connections, AuthConnection.Id);

        EmailConnection = await ApiClient.Connections.CreateAsync(new CreateConnectionRequestContent
        {
            Name = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}",
            Strategy = ConnectionIdentityProviderEnum.Email,
            EnabledClients = new[] { TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
        });

        TrackIdentifier(CleanUpType.Connections, EmailConnection.Id);

        Auth0User = await ApiClient.Users.CreateAsync(TestBaseUtils.CreateUserRequest(
            connection: AuthConnection.Name,
            email: $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
            emailVerified: true,
            password: Password
        ));

        TrackIdentifier(CleanUpType.Users, Auth0User.UserId);

        EmailUser = await ApiClient.Users.CreateAsync(TestBaseUtils.CreateUserRequest(
            connection: EmailConnection.Name,
            email: $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
            emailVerified: true
        ));

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
    private TicketsTestsFixture fixture;

    public TicketsTests(TicketsTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Test_tickets_sequence()
    {
        var existingOrganizationId = "org_x2j4mAL75v96wKkt";

        await fixture.ApiClient.Organizations.Members.CreateAsync(existingOrganizationId, new CreateOrganizationMemberRequestContent
        {
            Members = new List<string> { fixture.Auth0User.UserId }
        });

        // Send email verification ticket
        var verifyRequest = TestBaseUtils.CreateVerifyEmailTicketRequest(
            userId: fixture.Auth0User.UserId
        );
        verifyRequest.OrganizationId = existingOrganizationId;
        var verificationTicketResponse = await fixture.ApiClient.Tickets.VerifyEmailAsync(verifyRequest);
        verificationTicketResponse.Should().NotBeNull();
        verificationTicketResponse.Ticket.Should().NotBeNull();

        // Send password change ticket
        var changeRequest = TestBaseUtils.CreateChangePasswordTicketRequest(
            userId: fixture.Auth0User.UserId
        );
        changeRequest.ResultUrl = "http://www.nonexistingdomain.aaa/success";
        changeRequest.MarkEmailAsVerified = true;
        changeRequest.IncludeEmailInRedirect = true;
        var changeTicketResponse = await fixture.ApiClient.Tickets.ChangePasswordAsync(changeRequest);
        changeTicketResponse.Should().NotBeNull();
        changeTicketResponse.Ticket.Should().NotBeNull();

        await fixture.ApiClient.Organizations.Members.DeleteAsync(existingOrganizationId, new DeleteOrganizationMembersRequestContent
        {
            Members = new List<string> { fixture.Auth0User.UserId }
        });
    }

    [Fact]
    public async Task Can_send_verification_email_with_identity()
    {
        var verifyRequest = TestBaseUtils.CreateVerifyEmailTicketRequest(
            userId: fixture.EmailUser.UserId
        );
        verifyRequest.ResultUrl = "http://www.nonexistingdomain.aaa/success";
        verifyRequest.Identity = new Identity
        {
            Provider = (IdentityProviderEnum)"email",
            UserId = fixture.EmailUser.UserId.Replace("email|", "")
        };
        var verificationTicketResponse = await fixture.ApiClient.Tickets.VerifyEmailAsync(verifyRequest);
        verificationTicketResponse.Should().NotBeNull();
        verificationTicketResponse.Ticket.Should().NotBeNull();
    }

    [Fact]
    public async Task Can_send_verification_email_with_client_id()
    {
        var verifyRequest = TestBaseUtils.CreateVerifyEmailTicketRequest(
            userId: fixture.Auth0User.UserId,
            clientId: TestBaseUtils.GetVariable("AUTH0_CLIENT_ID")
        );
        var verificationTicketResponse = await fixture.ApiClient.Tickets.VerifyEmailAsync(verifyRequest);
        verificationTicketResponse.Should().NotBeNull();
        verificationTicketResponse.Ticket.Should().NotBeNull();
    }
}
