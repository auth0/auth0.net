using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class OrganizationTests : TestBase, IAsyncLifetime
    {
        private ManagementApiClient _apiClient;
        private const string ExistingOrganizationId = "org_Jif6mLeWXT5ec0nu";
        private const string ExistingConnectionId = "con_vKey1CGOPTJClWrB";
        private const string ExistingRoleId = "rol_gOsYvLA232E0vg7p";
        private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            _apiClient = new TestManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async Task Test_organizations_crud_sequence()
        {
            var initialOrganizations = await _apiClient.Organizations.GetAllAsync(new Paging.PaginationInfo());
            var initialOrganizationsCheckpoint = await _apiClient.Organizations.GetAllAsync(new Paging.CheckpointPaginationInfo());

            var createRequest = new OrganizationCreateRequest
            {
                Name = ($"integration-testing-" + MakeRandomName()).ToLower(),
                DisplayName = "Integration testing",
                Branding = new OrganizationBranding
                {
                    LogoUrl = "https://cdn.auth0.com/manhattan/versions/1.2800.0/assets/./badge.png",
                    Colors = new BrandingColors
                    {
                        Primary = "#ff0000",
                        PageBackground = "#00ff00"
                    }
                }
            };
            var createResponse = await _apiClient.Organizations.CreateAsync(createRequest);
            createResponse.Should().NotBeNull();
            createResponse.Name.Should().Be(createRequest.Name);
            createResponse.Branding.LogoUrl.Should().Be(createRequest.Branding.LogoUrl);
            createResponse.Branding.Colors.Primary.Should().Be("#ff0000");
            createResponse.Branding.Colors.PageBackground.Should().Be("#00ff00");

            var updateRequest = new OrganizationUpdateRequest
            {
                DisplayName = $"Integration testing 123",
            };
            var updateResponse = await _apiClient.Organizations.UpdateAsync(createResponse.Id, updateRequest);
            updateResponse.Should().NotBeNull();
            updateResponse.DisplayName.Should().Be(updateRequest.DisplayName);

            var organization = await _apiClient.Organizations.GetAsync(createResponse.Id);
            organization.Should().NotBeNull();
            organization.DisplayName.Should().Be(updateResponse.DisplayName);

            var organizationByName = await _apiClient.Organizations.GetByNameAsync(organization.Name);
            organizationByName.Should().NotBeNull();
            organizationByName.DisplayName.Should().Be(updateResponse.DisplayName);

            var organizations = await _apiClient.Organizations.GetAllAsync(new Paging.PaginationInfo());
            organizations.Count.Should().Be(initialOrganizations.Count + 1);

            var organizationsCheckpoint = await _apiClient.Organizations.GetAllAsync(new Paging.CheckpointPaginationInfo());
            organizationsCheckpoint.Count.Should().Be(initialOrganizationsCheckpoint.Count + 1);

            await _apiClient.Organizations.DeleteAsync(updateResponse.Id);
            Func<Task> getFunc = async () => await _apiClient.Organizations.GetAsync(organization.Id);
            getFunc.Should().Throw<ErrorApiException>().And.Message.Should().Be("No organization found by that id or name");
        }

        [Fact]
        public async Task Test_organization_connections_crud_sequence()
        {
            var initialConnections = await _apiClient.Organizations.GetAllConnectionsAsync(ExistingOrganizationId, new Paging.PaginationInfo());

            var createConnectionResponse = await _apiClient.Organizations.CreateConnectionAsync(ExistingOrganizationId, new OrganizationConnectionCreateRequest
            {
                ConnectionId = ExistingConnectionId,
                AssignMembershipOnLogin = true
            });

            createConnectionResponse.Should().NotBeNull();
            createConnectionResponse.AssignMembershipOnLogin.Should().Be(true);

            var updateConnectionResponse = await _apiClient.Organizations.UpdateConnectionAsync(ExistingOrganizationId, ExistingConnectionId, new OrganizationConnectionUpdateRequest
            {
                AssignMembershipOnLogin = false
            });

            updateConnectionResponse.Should().NotBeNull();
            updateConnectionResponse.AssignMembershipOnLogin.Should().Be(false);

            var connection = await _apiClient.Organizations.GetConnectionAsync(ExistingOrganizationId, ExistingConnectionId);

            connection.Should().NotBeNull();
            connection.AssignMembershipOnLogin.Should().Be(false);

            var connections = await _apiClient.Organizations.GetAllConnectionsAsync(ExistingOrganizationId, new Paging.PaginationInfo());
            connections.Count.Should().Be(initialConnections.Count + 1);

            await _apiClient.Organizations.DeleteConnectionAsync(ExistingOrganizationId, ExistingConnectionId);

            Func<Task> getFunc = async () => await _apiClient.Organizations.GetConnectionAsync(ExistingOrganizationId, ExistingConnectionId);
            getFunc.Should().Throw<ErrorApiException>().And.Message.Should().Be("No connection found by that id");

            // Unlink Connection
            await _apiClient.Organizations.DeleteConnectionAsync(ExistingOrganizationId, ExistingConnectionId);
        }

        [Fact]
        public async Task Test_organization_members_crud_sequence()
        {
            var user = await _apiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = "Username-Password-Authentication",
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            });

            var user2 = await _apiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = "Username-Password-Authentication",
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            });

            await _apiClient.Organizations.AddMembersAsync(ExistingOrganizationId, new OrganizationAddMembersRequest
            {
                Members = new List<string> { user.UserId, user2.UserId }
            });

            var members = await _apiClient.Organizations.GetAllMembersAsync(ExistingOrganizationId, new Paging.PaginationInfo());

            members.Count.Should().Be(2);

            await _apiClient.Organizations.DeleteMemberAsync(ExistingOrganizationId, new OrganizationDeleteMembersRequest
            {
                Members = new List<string> { user2.UserId }
            });

            var updatedMembers = await _apiClient.Organizations.GetAllMembersAsync(ExistingOrganizationId, new Paging.PaginationInfo());

            updatedMembers.Count.Should().Be(1);

            await _apiClient.Users.DeleteAsync(user.UserId);
            await _apiClient.Users.DeleteAsync(user2.UserId);
        }

        [Fact]
        public async Task Test_organization_member_roles_crud_sequence()
        {
            var user = await _apiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = "Username-Password-Authentication",
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            });

            await _apiClient.Organizations.AddMembersAsync(ExistingOrganizationId, new OrganizationAddMembersRequest
            {
                Members = new List<string> { user.UserId }
            });

            // Create
            await _apiClient.Organizations.AddMemberRolesAsync(ExistingOrganizationId, user.UserId, new OrganizationAddMemberRolesRequest
            {
                Roles = new List<string> { ExistingRoleId }
            });

            var roles = await _apiClient.Organizations.GetAllMemberRolesAsync(ExistingOrganizationId, user.UserId, new Paging.PaginationInfo());

            roles.Should().NotBeNull();
            roles.Count.Should().Be(1);

            await _apiClient.Organizations.DeleteMemberRolesAsync(ExistingOrganizationId, user.UserId, new OrganizationDeleteMemberRolesRequest
            {
                Roles = new List<string> { ExistingRoleId }
            });

            roles = await _apiClient.Organizations.GetAllMemberRolesAsync(ExistingOrganizationId, user.UserId, new Paging.PaginationInfo());

            roles.Should().NotBeNull();
            roles.Count.Should().Be(0);

            await _apiClient.Users.DeleteAsync(user.UserId);
        }

        [Fact]
        public async Task Test_organization_invitations_crud_sequence()
        {
            // Link Connection
            await _apiClient.Organizations.CreateConnectionAsync(ExistingOrganizationId, new OrganizationConnectionCreateRequest
            {
                ConnectionId = ExistingConnectionId,
                AssignMembershipOnLogin = true
            });

            var createdInvitation = await _apiClient.Organizations.CreateInvitationAsync(ExistingOrganizationId, new OrganizationCreateInvitationRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                ConnectionId = ExistingConnectionId,
                Inviter = new OrganizationInvitationInviter
                {
                    Name = "John Doe"
                },
                Invitee = new OrganizationInvitationInvitee
                {
                    Email = "jane.doe@auth0.com"
                },
                TimeToLive = 360,
                SendInvitationEmail = false
            });

            createdInvitation.Should().NotBeNull();
            createdInvitation.InvitationUrl.Should().NotBeNull();

            var invitations = await _apiClient.Organizations.GetAllInvitationsAsync(ExistingOrganizationId, new OrganizationGetAllInvitationsRequest(), new Paging.PaginationInfo());

            invitations.Should().NotBeNull();
            invitations.Count.Should().Be(1);

            var invitation = await _apiClient.Organizations.GetInvitationAsync(ExistingOrganizationId, createdInvitation.Id, new OrganizationGetInvitationRequest());

            invitation.Should().NotBeNull();
            invitation.Id.Should().Be(createdInvitation.Id);
            invitation.InvitationUrl.Should().NotBeNull();

            await _apiClient.Organizations.DeleteInvitationAsync(ExistingOrganizationId, createdInvitation.Id);

            invitations = await _apiClient.Organizations.GetAllInvitationsAsync(ExistingOrganizationId, new OrganizationGetAllInvitationsRequest(), new Paging.PaginationInfo());

            invitations.Should().NotBeNull();
            invitations.Count.Should().Be(0);

            // Unlink Connection
            await _apiClient.Organizations.DeleteConnectionAsync(ExistingOrganizationId, ExistingConnectionId);
        }
    }
}
