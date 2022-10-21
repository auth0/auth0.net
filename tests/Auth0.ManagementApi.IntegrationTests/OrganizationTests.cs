﻿using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class OrganizationTestsFixture : TestBaseFixture
    {
        public override async Task DisposeAsync()
        {
            await ManagementTestBaseUtils.CleanupAndDisposeAsync(ApiClient, new List<CleanUpType> { CleanUpType.Organizations });
        }
    }

    public class OrganizationTests : IClassFixture<OrganizationTestsFixture>
    {
        private const string ExistingOrganizationId = "org_V6ojENVd1ERs5YY1";
        private const string ExistingConnectionId = "con_vKey1CGOPTJClWrB";
        private const string ExistingRoleId = "rol_gOsYvLA232E0vg7p";
        private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        OrganizationTestsFixture fixture;

        public OrganizationTests(OrganizationTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task Test_organizations_crud_sequence()
        {
            var initialOrganizations = await fixture.ApiClient.Organizations.GetAllAsync(new Paging.PaginationInfo());

            var createRequest = new OrganizationCreateRequest
            {
                Name = ($"{TestingConstants.OrganizationPrefix}-{TestBaseUtils.MakeRandomName()}").ToLower(),
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
            var createResponse = await fixture.ApiClient.Organizations.CreateAsync(createRequest);
            createResponse.Should().NotBeNull();
            createResponse.Name.Should().Be(createRequest.Name);
            createResponse.Branding.LogoUrl.Should().Be(createRequest.Branding.LogoUrl);
            createResponse.Branding.Colors.Primary.Should().Be("#ff0000");
            createResponse.Branding.Colors.PageBackground.Should().Be("#00ff00");

            var updateRequest = new OrganizationUpdateRequest
            {
                DisplayName = $"Integration testing 123",
            };
            var updateResponse = await fixture.ApiClient.Organizations.UpdateAsync(createResponse.Id, updateRequest);
            updateResponse.Should().NotBeNull();
            updateResponse.DisplayName.Should().Be(updateRequest.DisplayName);

            var organization = await fixture.ApiClient.Organizations.GetAsync(createResponse.Id);
            organization.Should().NotBeNull();
            organization.DisplayName.Should().Be(updateResponse.DisplayName);

            var organizationByName = await fixture.ApiClient.Organizations.GetByNameAsync(organization.Name);
            organizationByName.Should().NotBeNull();
            organizationByName.DisplayName.Should().Be(updateResponse.DisplayName);

            var organizations = await fixture.ApiClient.Organizations.GetAllAsync(new Paging.PaginationInfo());
            organizations.Count.Should().Be(initialOrganizations.Count + 1);

            await fixture.ApiClient.Organizations.DeleteAsync(updateResponse.Id);
            Func<Task> getFunc = async () => await fixture.ApiClient.Organizations.GetAsync(organization.Id);
            getFunc.Should().Throw<ErrorApiException>().And.Message.Should().Be("No organization found by that id or name");
        }

        [Fact]
        public async Task Test_organizations_checkpoint_pagination()
        {
            var organization1 = new OrganizationCreateRequest
            {
                Name = ($"{TestingConstants.OrganizationPrefix}-{TestBaseUtils.MakeRandomName()}").ToLower(),
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
            var createResponse1 = await fixture.ApiClient.Organizations.CreateAsync(organization1);

            var organization2 = new OrganizationCreateRequest
            {
                Name = ($"{TestingConstants.OrganizationPrefix}-" + TestBaseUtils.MakeRandomName()).ToLower(),
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
            var createResponse2 = await fixture.ApiClient.Organizations.CreateAsync(organization2);

            var firstCheckPointPaginationRequest = await fixture.ApiClient.Organizations.GetAllAsync(new Paging.CheckpointPaginationInfo(1));
            var secondCheckPointPaginationRequest = await fixture.ApiClient.Organizations.GetAllAsync(new Paging.CheckpointPaginationInfo(1, firstCheckPointPaginationRequest.Paging.Next));

            secondCheckPointPaginationRequest.Count.Should().Be(1);
            secondCheckPointPaginationRequest.Paging.Next.Should().NotBeNullOrEmpty();

            await fixture.ApiClient.Organizations.DeleteAsync(createResponse1.Id);
            await fixture.ApiClient.Organizations.DeleteAsync(createResponse2.Id);
        }

        [Fact]
        public async Task Test_organization_connections_crud_sequence()
        {
            var initialConnections = await fixture.ApiClient.Organizations.GetAllConnectionsAsync(ExistingOrganizationId, new Paging.PaginationInfo());

            var createConnectionResponse = await fixture.ApiClient.Organizations.CreateConnectionAsync(ExistingOrganizationId, new OrganizationConnectionCreateRequest
            {
                ConnectionId = ExistingConnectionId,
                AssignMembershipOnLogin = true
            });

            createConnectionResponse.Should().NotBeNull();
            createConnectionResponse.AssignMembershipOnLogin.Should().Be(true);

            var updateConnectionResponse = await fixture.ApiClient.Organizations.UpdateConnectionAsync(ExistingOrganizationId, ExistingConnectionId, new OrganizationConnectionUpdateRequest
            {
                AssignMembershipOnLogin = false
            });

            updateConnectionResponse.Should().NotBeNull();
            updateConnectionResponse.AssignMembershipOnLogin.Should().Be(false);

            var connection = await fixture.ApiClient.Organizations.GetConnectionAsync(ExistingOrganizationId, ExistingConnectionId);

            connection.Should().NotBeNull();
            connection.AssignMembershipOnLogin.Should().Be(false);

            var connections = await fixture.ApiClient.Organizations.GetAllConnectionsAsync(ExistingOrganizationId, new Paging.PaginationInfo());
            connections.Count.Should().Be(initialConnections.Count + 1);

            await fixture.ApiClient.Organizations.DeleteConnectionAsync(ExistingOrganizationId, ExistingConnectionId);

            Func<Task> getFunc = async () => await fixture.ApiClient.Organizations.GetConnectionAsync(ExistingOrganizationId, ExistingConnectionId);
            getFunc.Should().Throw<ErrorApiException>().And.Message.Should().Be("No connection found by that id");

            // Unlink Connection
            await fixture.ApiClient.Organizations.DeleteConnectionAsync(ExistingOrganizationId, ExistingConnectionId);
        }

        [Fact]
        public async Task Test_organization_members_crud_sequence()
        {
            var user = await fixture.ApiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = "Username-Password-Authentication",
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            });

            var user2 = await fixture.ApiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = "Username-Password-Authentication",
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            });

            await fixture.ApiClient.Organizations.AddMembersAsync(ExistingOrganizationId, new OrganizationAddMembersRequest
            {
                Members = new List<string> { user.UserId, user2.UserId }
            });

            var members = await fixture.ApiClient.Organizations.GetAllMembersAsync(ExistingOrganizationId, new Paging.PaginationInfo());

            members.Count.Should().Be(2);

            await fixture.ApiClient.Organizations.DeleteMemberAsync(ExistingOrganizationId, new OrganizationDeleteMembersRequest
            {
                Members = new List<string> { user2.UserId }
            });

            var updatedMembers = await fixture.ApiClient.Organizations.GetAllMembersAsync(ExistingOrganizationId, new Paging.PaginationInfo());

            updatedMembers.Count.Should().Be(1);

            await fixture.ApiClient.Users.DeleteAsync(user.UserId);
            await fixture.ApiClient.Users.DeleteAsync(user2.UserId);
        }

        [Fact]
        public async Task Test_organization_members_checkpoint_pagination()
        {
            User user = null;
            User user2 = null;
            try
            {
                user = await fixture.ApiClient.Users.CreateAsync(new UserCreateRequest
                {
                    Connection = "Username-Password-Authentication",
                    Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                    EmailVerified = true,
                    Password = Password
                });

                user2 = await fixture.ApiClient.Users.CreateAsync(new UserCreateRequest
                {
                    Connection = "Username-Password-Authentication",
                    Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                    EmailVerified = true,
                    Password = Password
                });

                await fixture.ApiClient.Organizations.AddMembersAsync(ExistingOrganizationId, new OrganizationAddMembersRequest
                {
                    Members = new List<string> { user.UserId, user2.UserId }
                });


                var firstCheckPointPaginationRequest = await fixture.ApiClient.Organizations.GetAllMembersAsync(ExistingOrganizationId, new Paging.CheckpointPaginationInfo(1));
                var secondCheckPointPaginationRequest = await fixture.ApiClient.Organizations.GetAllMembersAsync(ExistingOrganizationId, new Paging.CheckpointPaginationInfo(1, firstCheckPointPaginationRequest.Paging.Next));

                secondCheckPointPaginationRequest.Count.Should().Be(1);
                secondCheckPointPaginationRequest.Paging.Next.Should().NotBeNullOrEmpty();

            }
            finally
            {
                if (user != null && user2 != null) {
                    await fixture.ApiClient.Organizations.DeleteMemberAsync(ExistingOrganizationId, new OrganizationDeleteMembersRequest { Members = new List<string> { user.UserId, user2.UserId } });

                    await fixture.ApiClient.Users.DeleteAsync(user.UserId);
                    await fixture.ApiClient.Users.DeleteAsync(user2.UserId);
                }
            }
        }

        [Fact]
        public async Task Test_organization_member_roles_crud_sequence()
        {
            var user = await fixture.ApiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = "Username-Password-Authentication",
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            });

            await fixture.ApiClient.Organizations.AddMembersAsync(ExistingOrganizationId, new OrganizationAddMembersRequest
            {
                Members = new List<string> { user.UserId }
            });

            // Create
            await fixture.ApiClient.Organizations.AddMemberRolesAsync(ExistingOrganizationId, user.UserId, new OrganizationAddMemberRolesRequest
            {
                Roles = new List<string> { ExistingRoleId }
            });

            var roles = await fixture.ApiClient.Organizations.GetAllMemberRolesAsync(ExistingOrganizationId, user.UserId, new Paging.PaginationInfo());

            roles.Should().NotBeNull();
            roles.Count.Should().Be(1);
            roles[0].Name.Should().Be("Admin");

            await fixture.ApiClient.Organizations.DeleteMemberRolesAsync(ExistingOrganizationId, user.UserId, new OrganizationDeleteMemberRolesRequest
            {
                Roles = new List<string> { ExistingRoleId }
            });

            roles = await fixture.ApiClient.Organizations.GetAllMemberRolesAsync(ExistingOrganizationId, user.UserId, new Paging.PaginationInfo());

            roles.Should().NotBeNull();
            roles.Count.Should().Be(0);

            await fixture.ApiClient.Users.DeleteAsync(user.UserId);
        }

        [Fact]
        public async Task Test_organization_invitations_crud_sequence()
        {
            // Link Connection
            await fixture.ApiClient.Organizations.CreateConnectionAsync(ExistingOrganizationId, new OrganizationConnectionCreateRequest
            {
                ConnectionId = ExistingConnectionId,
                AssignMembershipOnLogin = true
            });

            var createdInvitation = await fixture.ApiClient.Organizations.CreateInvitationAsync(ExistingOrganizationId, new OrganizationCreateInvitationRequest
            {
                ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
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

            var invitations = await fixture.ApiClient.Organizations.GetAllInvitationsAsync(ExistingOrganizationId, new OrganizationGetAllInvitationsRequest(), new Paging.PaginationInfo());

            invitations.Should().NotBeNull();
            invitations.Count.Should().Be(1);

            var invitation = await fixture.ApiClient.Organizations.GetInvitationAsync(ExistingOrganizationId, createdInvitation.Id, new OrganizationGetInvitationRequest());

            invitation.Should().NotBeNull();
            invitation.Id.Should().Be(createdInvitation.Id);
            invitation.InvitationUrl.Should().NotBeNull();

            await fixture.ApiClient.Organizations.DeleteInvitationAsync(ExistingOrganizationId, createdInvitation.Id);

            invitations = await fixture.ApiClient.Organizations.GetAllInvitationsAsync(ExistingOrganizationId, new OrganizationGetAllInvitationsRequest(), new Paging.PaginationInfo());

            invitations.Should().NotBeNull();
            invitations.Count.Should().Be(0);

            // Unlink Connection
            await fixture.ApiClient.Organizations.DeleteConnectionAsync(ExistingOrganizationId, ExistingConnectionId);
        }
    }
}
