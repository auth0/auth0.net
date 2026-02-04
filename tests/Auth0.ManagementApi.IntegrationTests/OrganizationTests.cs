using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.Connections;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Organizations;
using Auth0.ManagementApi.Organizations.Members;
using Auth0.ManagementApi.Roles;
using Auth0.ManagementApi.Users;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class OrganizationTestsFixture : TestBaseFixture
{
    public override async Task DisposeAsync()
    {
        foreach (KeyValuePair<CleanUpType, IList<string>> entry in identifiers)
        {
            await ManagementTestBaseUtils.CleanupAsync(ApiClient, entry.Key, entry.Value);
        }

        ApiClient.Dispose();
    }
}

public class OrganizationTests : IClassFixture<OrganizationTestsFixture>
{
    private OrganizationTestsFixture fixture;

    public OrganizationTests(OrganizationTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Test_organizations_crud_sequence()
    {
        // Get all organizations before
        var organizationsPager = await fixture.ApiClient.Organizations.ListAsync(new ListOrganizationsRequestParameters());
        var organizationsBefore = organizationsPager.CurrentPage.Items.ToList();

        // Create a new organization
        var orgName = $"{TestingConstants.OrganizationPrefix}-{TestBaseUtils.MakeRandomName()}".ToLower();
        var newOrganization = await fixture.ApiClient.Organizations.CreateAsync(new CreateOrganizationRequestContent
        {
            Name = orgName,
            DisplayName = "Test Organization",
            Branding = new OrganizationBranding
            {
                LogoUrl = "https://cdn.auth0.com/website/press/resources/auth0-logo-monotone-black.svg",
                Colors = new OrganizationBrandingColors
                {
                    Primary = "#ff0000",
                    PageBackground = "#ffffff"
                }
            },
            Metadata = new Dictionary<string, string?>
            {
                { "key1", "value1" },
                { "key2", "value2" }
            }
        });

        newOrganization.Should().NotBeNull();
        newOrganization.Id.Should().NotBeNullOrEmpty();
        newOrganization.Name.Should().Be(orgName);
        newOrganization.DisplayName.Should().Be("Test Organization");

        fixture.TrackIdentifier(CleanUpType.Organizations, newOrganization.Id);

        try
        {
            // Get all organizations after creation
            organizationsPager = await fixture.ApiClient.Organizations.ListAsync(new ListOrganizationsRequestParameters());
            var organizationsAfter = organizationsPager.CurrentPage.Items.ToList();
            organizationsAfter.Count.Should().Be(organizationsBefore.Count + 1);

            // Get the specific organization by ID
            var fetchedOrganization = await fixture.ApiClient.Organizations.GetAsync(newOrganization.Id);
            fetchedOrganization.Should().NotBeNull();
            fetchedOrganization.Id.Should().Be(newOrganization.Id);

            // Get the organization by name
            var fetchedByName = await fixture.ApiClient.Organizations.GetByNameAsync(newOrganization.Name);
            fetchedByName.Should().NotBeNull();
            fetchedByName.Id.Should().Be(newOrganization.Id);

            // Update the organization
            var updatedOrganization = await fixture.ApiClient.Organizations.UpdateAsync(newOrganization.Id, new UpdateOrganizationRequestContent
            {
                DisplayName = "Updated Organization Name"
            });
            updatedOrganization.Should().NotBeNull();
            updatedOrganization.DisplayName.Should().Be("Updated Organization Name");
        }
        finally
        {
            // Delete the organization
            await fixture.ApiClient.Organizations.DeleteAsync(newOrganization.Id);
            fixture.UnTrackIdentifier(CleanUpType.Organizations, newOrganization.Id);
        }
    }

    [Fact]
    public async Task Test_organization_enabled_connections()
    {
        // Create a connection
        var connectionName = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}";
        var newConnection = await fixture.ApiClient.Connections.CreateAsync(new CreateConnectionRequestContent
        {
            Name = connectionName,
            Strategy = ConnectionIdentityProviderEnum.Auth0,
            EnabledClients = new[] { TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
        });
        fixture.TrackIdentifier(CleanUpType.Connections, newConnection.Id);

        // Create an organization
        var orgName = $"{TestingConstants.OrganizationPrefix}-{TestBaseUtils.MakeRandomName()}".ToLower();
        var newOrganization = await fixture.ApiClient.Organizations.CreateAsync(new CreateOrganizationRequestContent
        {
            Name = orgName,
            DisplayName = "Test Organization"
        });
        fixture.TrackIdentifier(CleanUpType.Organizations, newOrganization.Id);

        try
        {
            // Add connection to organization
            var orgConnection = await fixture.ApiClient.Organizations.EnabledConnections.AddAsync(
                newOrganization.Id,
                new AddOrganizationConnectionRequestContent
                {
                    ConnectionId = newConnection.Id,
                    AssignMembershipOnLogin = true
                });

            orgConnection.Should().NotBeNull();
            orgConnection.ConnectionId.Should().Be(newConnection.Id);

            // Get enabled connections
            var connectionsPager = await fixture.ApiClient.Organizations.EnabledConnections.ListAsync(
                newOrganization.Id,
                new ListOrganizationConnectionsRequestParameters());
            var connections = connectionsPager.CurrentPage.Items.ToList();
            connections.Should().Contain(c => c.ConnectionId == newConnection.Id);

            // Get specific connection
            var fetchedConnection = await fixture.ApiClient.Organizations.EnabledConnections.GetAsync(
                newOrganization.Id,
                newConnection.Id);
            fetchedConnection.Should().NotBeNull();
            fetchedConnection.ConnectionId.Should().Be(newConnection.Id);

            // Update connection
            var updatedConnection = await fixture.ApiClient.Organizations.EnabledConnections.UpdateAsync(
                newOrganization.Id,
                newConnection.Id,
                new UpdateOrganizationConnectionRequestContent
                {
                    AssignMembershipOnLogin = false
                });
            updatedConnection.Should().NotBeNull();

            // Delete connection from organization
            await fixture.ApiClient.Organizations.EnabledConnections.DeleteAsync(
                newOrganization.Id,
                newConnection.Id);

            // Verify deletion
            connectionsPager = await fixture.ApiClient.Organizations.EnabledConnections.ListAsync(
                newOrganization.Id,
                new ListOrganizationConnectionsRequestParameters());
            connections = connectionsPager.CurrentPage.Items.ToList();
            connections.Should().NotContain(c => c.ConnectionId == newConnection.Id);
        }
        finally
        {
            await fixture.ApiClient.Organizations.DeleteAsync(newOrganization.Id);
            fixture.UnTrackIdentifier(CleanUpType.Organizations, newOrganization.Id);

            await fixture.ApiClient.Connections.DeleteAsync(newConnection.Id);
            fixture.UnTrackIdentifier(CleanUpType.Connections, newConnection.Id);
        }
    }

    [Fact]
    public async Task Test_organization_members()
    {
        // Create a connection
        var connectionName = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}";
        var newConnection = await fixture.ApiClient.Connections.CreateAsync(new CreateConnectionRequestContent
        {
            Name = connectionName,
            Strategy = ConnectionIdentityProviderEnum.Auth0,
            EnabledClients = new[] { TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
        });
        fixture.TrackIdentifier(CleanUpType.Connections, newConnection.Id);

        // Create a user
        var userEmail = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}";
        var newUser = await fixture.ApiClient.Users.CreateAsync(TestBaseUtils.CreateUserRequest(
            connection: newConnection.Name,
            email: userEmail,
            emailVerified: true,
            password: "Test123456!"
        ));
        fixture.TrackIdentifier(CleanUpType.Users, newUser.UserId);

        // Create an organization
        var orgName = $"{TestingConstants.OrganizationPrefix}-{TestBaseUtils.MakeRandomName()}".ToLower();
        var newOrganization = await fixture.ApiClient.Organizations.CreateAsync(new CreateOrganizationRequestContent
        {
            Name = orgName,
            DisplayName = "Test Organization"
        });
        fixture.TrackIdentifier(CleanUpType.Organizations, newOrganization.Id);

        try
        {
            // Add member to organization
            await fixture.ApiClient.Organizations.Members.CreateAsync(
                newOrganization.Id,
                new CreateOrganizationMemberRequestContent
                {
                    Members = new[] { newUser.UserId }
                });

            // Wait for member to be added (eventual consistency)
            await Task.Delay(2000);

            // Get members
            var membersPager = await fixture.ApiClient.Organizations.Members.ListAsync(
                newOrganization.Id,
                new ListOrganizationMembersRequestParameters());
            var members = membersPager.CurrentPage.Items.ToList();
            members.Should().Contain(m => m.UserId == newUser.UserId);

            // Remove member from organization
            await fixture.ApiClient.Organizations.Members.DeleteAsync(
                newOrganization.Id,
                new DeleteOrganizationMembersRequestContent
                {
                    Members = new[] { newUser.UserId }
                });

            // Verify removal
            membersPager = await fixture.ApiClient.Organizations.Members.ListAsync(
                newOrganization.Id,
                new ListOrganizationMembersRequestParameters());
            members = membersPager.CurrentPage.Items.ToList();
            members.Should().NotContain(m => m.UserId == newUser.UserId);
        }
        finally
        {
            await fixture.ApiClient.Organizations.DeleteAsync(newOrganization.Id);
            fixture.UnTrackIdentifier(CleanUpType.Organizations, newOrganization.Id);

            await fixture.ApiClient.Users.DeleteAsync(newUser.UserId);
            fixture.UnTrackIdentifier(CleanUpType.Users, newUser.UserId);

            await fixture.ApiClient.Connections.DeleteAsync(newConnection.Id);
            fixture.UnTrackIdentifier(CleanUpType.Connections, newConnection.Id);
        }
    }

    [Fact]
    public async Task Test_organization_member_roles()
    {
        // Create a connection
        var connectionName = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}";
        var newConnection = await fixture.ApiClient.Connections.CreateAsync(new CreateConnectionRequestContent
        {
            Name = connectionName,
            Strategy = ConnectionIdentityProviderEnum.Auth0,
            EnabledClients = new[] { TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
        });
        fixture.TrackIdentifier(CleanUpType.Connections, newConnection.Id);

        // Create a user
        var userEmail = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}";
        var newUser = await fixture.ApiClient.Users.CreateAsync(TestBaseUtils.CreateUserRequest(
            connection: newConnection.Name,
            email: userEmail,
            emailVerified: true,
            password: "Test123456!"
        ));
        fixture.TrackIdentifier(CleanUpType.Users, newUser.UserId);

        // Create a role
        var newRole = await fixture.ApiClient.Roles.CreateAsync(new CreateRoleRequestContent
        {
            Name = $"{TestingConstants.RolePrefix}-{TestBaseUtils.MakeRandomName()}",
            Description = "Test role for organization"
        });
        fixture.TrackIdentifier(CleanUpType.Roles, newRole.Id);

        // Create an organization
        var orgName = $"{TestingConstants.OrganizationPrefix}-{TestBaseUtils.MakeRandomName()}".ToLower();
        var newOrganization = await fixture.ApiClient.Organizations.CreateAsync(new CreateOrganizationRequestContent
        {
            Name = orgName,
            DisplayName = "Test Organization"
        });
        fixture.TrackIdentifier(CleanUpType.Organizations, newOrganization.Id);

        try
        {
            // Add member to organization
            await fixture.ApiClient.Organizations.Members.CreateAsync(
                newOrganization.Id,
                new CreateOrganizationMemberRequestContent
                {
                    Members = new[] { newUser.UserId }
                });

            // Assign role to member
            await fixture.ApiClient.Organizations.Members.Roles.AssignAsync(
                newOrganization.Id,
                newUser.UserId,
                new AssignOrganizationMemberRolesRequestContent
                {
                    Roles = new[] { newRole.Id }
                });

            // Get member roles
            var rolesPager = await fixture.ApiClient.Organizations.Members.Roles.ListAsync(
                newOrganization.Id,
                newUser.UserId,
                new ListOrganizationMemberRolesRequestParameters());
            var roles = rolesPager.CurrentPage.Items.ToList();
            roles.Should().Contain(r => r.Id == newRole.Id);

            // Remove role from member
            await fixture.ApiClient.Organizations.Members.Roles.DeleteAsync(
                newOrganization.Id,
                newUser.UserId,
                new DeleteOrganizationMemberRolesRequestContent
                {
                    Roles = new[] { newRole.Id }
                });

            // Verify removal
            rolesPager = await fixture.ApiClient.Organizations.Members.Roles.ListAsync(
                newOrganization.Id,
                newUser.UserId,
                new ListOrganizationMemberRolesRequestParameters());
            roles = rolesPager.CurrentPage.Items.ToList();
            roles.Should().NotContain(r => r.Id == newRole.Id);
        }
        finally
        {
            await fixture.ApiClient.Organizations.DeleteAsync(newOrganization.Id);
            fixture.UnTrackIdentifier(CleanUpType.Organizations, newOrganization.Id);

            await fixture.ApiClient.Roles.DeleteAsync(newRole.Id);
            fixture.UnTrackIdentifier(CleanUpType.Roles, newRole.Id);

            await fixture.ApiClient.Users.DeleteAsync(newUser.UserId);
            fixture.UnTrackIdentifier(CleanUpType.Users, newUser.UserId);

            await fixture.ApiClient.Connections.DeleteAsync(newConnection.Id);
            fixture.UnTrackIdentifier(CleanUpType.Connections, newConnection.Id);
        }
    }

    [Fact(Skip = "Requires client configured for organization invitations")]
    public async Task Test_organization_invitations()
    {
        // Create an organization
        var orgName = $"{TestingConstants.OrganizationPrefix}-{TestBaseUtils.MakeRandomName()}".ToLower();
        var newOrganization = await fixture.ApiClient.Organizations.CreateAsync(new CreateOrganizationRequestContent
        {
            Name = orgName,
            DisplayName = "Test Organization"
        });
        fixture.TrackIdentifier(CleanUpType.Organizations, newOrganization.Id);

        try
        {
            // Create an invitation
            var inviteeEmail = $"invitee-{Guid.NewGuid():N}@example.com";
            var newInvitation = await fixture.ApiClient.Organizations.Invitations.CreateAsync(
                newOrganization.Id,
                TestBaseUtils.CreateOrganizationInvitationRequest(
                    inviter: new OrganizationInvitationInviter { Name = "Test Inviter" },
                    invitee: new OrganizationInvitationInvitee { Email = inviteeEmail },
                    clientId: TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
                    sendInvitationEmail: false
                ));

            newInvitation.Should().NotBeNull();
            newInvitation.Id.Should().NotBeNullOrEmpty();

            // Get invitations
            var invitationsPager = await fixture.ApiClient.Organizations.Invitations.ListAsync(
                newOrganization.Id,
                new ListOrganizationInvitationsRequestParameters());
            var invitations = invitationsPager.CurrentPage.Items.ToList();
            invitations.Should().Contain(i => i.Id == newInvitation.Id);

            // Get specific invitation
            var fetchedInvitation = await fixture.ApiClient.Organizations.Invitations.GetAsync(
                newOrganization.Id,
                newInvitation.Id,
                new GetOrganizationInvitationRequestParameters());
            fetchedInvitation.Should().NotBeNull();
            fetchedInvitation.Id.Should().Be(newInvitation.Id);

            // Delete invitation
            await fixture.ApiClient.Organizations.Invitations.DeleteAsync(
                newOrganization.Id,
                newInvitation.Id);

            // Verify deletion
            invitationsPager = await fixture.ApiClient.Organizations.Invitations.ListAsync(
                newOrganization.Id,
                new ListOrganizationInvitationsRequestParameters());
            invitations = invitationsPager.CurrentPage.Items.ToList();
            invitations.Should().NotContain(i => i.Id == newInvitation.Id);
        }
        finally
        {
            await fixture.ApiClient.Organizations.DeleteAsync(newOrganization.Id);
            fixture.UnTrackIdentifier(CleanUpType.Organizations, newOrganization.Id);
        }
    }

    [Fact]
    public async Task Test_organization_list_with_pagination()
    {
        // Create two organizations
        var orgName1 = $"{TestingConstants.OrganizationPrefix}-{TestBaseUtils.MakeRandomName()}".ToLower();
        var org1 = await fixture.ApiClient.Organizations.CreateAsync(new CreateOrganizationRequestContent
        {
            Name = orgName1,
            DisplayName = "Test Organization 1"
        });
        fixture.TrackIdentifier(CleanUpType.Organizations, org1.Id);

        var orgName2 = $"{TestingConstants.OrganizationPrefix}-{TestBaseUtils.MakeRandomName()}".ToLower();
        var org2 = await fixture.ApiClient.Organizations.CreateAsync(new CreateOrganizationRequestContent
        {
            Name = orgName2,
            DisplayName = "Test Organization 2"
        });
        fixture.TrackIdentifier(CleanUpType.Organizations, org2.Id);

        try
        {
            // List with pagination
            var organizationsPager = await fixture.ApiClient.Organizations.ListAsync(
                new ListOrganizationsRequestParameters
                {
                    Take = 1
                });

            var firstPage = organizationsPager.CurrentPage.Items.ToList();
            firstPage.Should().NotBeEmpty();
        }
        finally
        {
            await fixture.ApiClient.Organizations.DeleteAsync(org1.Id);
            fixture.UnTrackIdentifier(CleanUpType.Organizations, org1.Id);

            await fixture.ApiClient.Organizations.DeleteAsync(org2.Id);
            fixture.UnTrackIdentifier(CleanUpType.Organizations, org2.Id);
        }
    }
}
