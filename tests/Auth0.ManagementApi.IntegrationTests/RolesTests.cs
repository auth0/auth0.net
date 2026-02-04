using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;
using System.Collections.Generic;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Connections;
using Auth0.ManagementApi.Roles;
using Auth0.ManagementApi.Users;

namespace Auth0.ManagementApi.IntegrationTests;

public class RolesTestsFixture : TestBaseFixture
{
    public CreateConnectionResponseContent Connection { get; private set; }

    public override async Task InitializeAsync()
    {
        await base.InitializeAsync();

        Connection = await ApiClient.Connections.CreateAsync(new CreateConnectionRequestContent
        {
            Name = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}",
            Strategy = ConnectionIdentityProviderEnum.Auth0,
            EnabledClients = new[] { TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
        });

        TrackIdentifier(CleanUpType.Connections, Connection.Id);
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

public class RolesTests : IClassFixture<RolesTestsFixture>
{
    private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

    private RolesTestsFixture fixture;

    public RolesTests(RolesTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Test_roles_crud_sequence()
    {
        // Add a new role
        var newRoleRequest = new CreateRoleRequestContent
        {
            Name = $"{Guid.NewGuid():N}role",
            Description = $"{Guid.NewGuid():N}description",
        };
        var newRoleResponse = await fixture.ApiClient.Roles.CreateAsync(newRoleRequest);

        fixture.TrackIdentifier(CleanUpType.Roles, newRoleResponse.Id);

        newRoleResponse.Should().NotBeNull();
        newRoleResponse.Name.Should().Be(newRoleRequest.Name);
        newRoleResponse.Description.Should().Be(newRoleRequest.Description);

        // Update the role
        var updateRoleRequest = new UpdateRoleRequestContent
        {
            Name = $"{Guid.NewGuid():N}role",
        };
        var updateRoleResponse = await fixture.ApiClient.Roles.UpdateAsync(newRoleResponse.Id, updateRoleRequest);
        updateRoleResponse.Should().NotBeNull();
        updateRoleResponse.Name.Should().Be(updateRoleRequest.Name);

        // Get a single role
        var role = await fixture.ApiClient.Roles.GetAsync(newRoleResponse.Id);
        role.Should().NotBeNull();
        role.Name.Should().Be(updateRoleResponse.Name);

        // Create a user
        var newUserRequest = TestBaseUtils.CreateUserRequest(
            connection: fixture.Connection.Name,
            email: $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
            emailVerified: true,
            password: Password
        );

        var user = await fixture.ApiClient.Users.CreateAsync(newUserRequest);
        fixture.TrackIdentifier(CleanUpType.Users, user.UserId);

        // Assign a user to the role
        await fixture.ApiClient.Roles.Users.AssignAsync(role.Id, new AssignRoleUsersRequestContent
        {
            Users = new[] { user.UserId }
        });

        // Ensure the user is assigned to the role
        var assignedUsersPager = await fixture.ApiClient.Roles.Users.ListAsync(role.Id, new ListRoleUsersRequestParameters());
        var assignedUsers = assignedUsersPager.CurrentPage.Items.ToList();
        assignedUsers.Should().NotBeNull();
        assignedUsers.First().UserId.Should().Be(user.UserId);

        // Ensure the Role is assigned to user
        var assignedRolesPager = await fixture.ApiClient.Users.Roles.ListAsync(user.UserId, new ListUserRolesRequestParameters());
        var assignedRoles = assignedRolesPager.CurrentPage.Items.ToList();
        assignedRoles.Should().NotBeNull();
        assignedRoles.First().Id.Should().Be(role.Id);

        // Delete the role and ensure we get an exception when trying to fetch them again
        await fixture.ApiClient.Roles.DeleteAsync(role.Id);
        Func<Task> getFunc = async () => await fixture.ApiClient.Roles.GetAsync(role.Id);
        await getFunc.Should().ThrowAsync<NotFoundError>();

        fixture.UnTrackIdentifier(CleanUpType.Roles, newRoleResponse.Id);

        // Delete the user
        await fixture.ApiClient.Users.DeleteAsync(user.UserId);
        fixture.UnTrackIdentifier(CleanUpType.Users, user.UserId);
    }

    [Fact]
    public async Task Test_roles_assign_user_to_role()
    {
        // Add a new role
        var newRoleRequest = new CreateRoleRequestContent
        {
            Name = $"{Guid.NewGuid():N}role",
            Description = $"{Guid.NewGuid():N}description",
        };
        var role = await fixture.ApiClient.Roles.CreateAsync(newRoleRequest);

        fixture.TrackIdentifier(CleanUpType.Roles, role.Id);

        role.Should().NotBeNull();
        role.Name.Should().Be(newRoleRequest.Name);
        role.Description.Should().Be(newRoleRequest.Description);

        // Create a user
        var newUserRequest = TestBaseUtils.CreateUserRequest(
            connection: fixture.Connection.Name,
            email: $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
            emailVerified: true,
            password: Password
        );
        var user = await fixture.ApiClient.Users.CreateAsync(newUserRequest);

        fixture.TrackIdentifier(CleanUpType.Users, user.UserId);

        // Assign a user to the role
        await fixture.ApiClient.Roles.Users.AssignAsync(role.Id, new AssignRoleUsersRequestContent
        {
            Users = new[] { user.UserId }
        });

        // Ensure the user is assigned to the role
        var assignedUsersPager = await fixture.ApiClient.Roles.Users.ListAsync(role.Id, new ListRoleUsersRequestParameters());
        var assignedUsers = assignedUsersPager.CurrentPage.Items.ToList();
        assignedUsers.Should().NotBeNull();
        assignedUsers.First().UserId.Should().Be(user.UserId);

        // Clean Up
        await fixture.ApiClient.Roles.DeleteAsync(role.Id);
        fixture.UnTrackIdentifier(CleanUpType.Roles, role.Id);
        await fixture.ApiClient.Users.DeleteAsync(user.UserId);
        fixture.UnTrackIdentifier(CleanUpType.Users, user.UserId);
    }

    [Fact]
    public async Task Test_roles_assign_role_to_user()
    {
        // Add a new role
        var newRoleRequest = new CreateRoleRequestContent
        {
            Name = $"{Guid.NewGuid():N}role",
            Description = $"{Guid.NewGuid():N}description",
        };
        var role = await fixture.ApiClient.Roles.CreateAsync(newRoleRequest);

        fixture.TrackIdentifier(CleanUpType.Roles, role.Id);

        role.Should().NotBeNull();
        role.Name.Should().Be(newRoleRequest.Name);
        role.Description.Should().Be(newRoleRequest.Description);

        // Create a user
        var newUserRequest = TestBaseUtils.CreateUserRequest(
            connection: fixture.Connection.Name,
            email: $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
            emailVerified: true,
            password: Password
        );
        var user = await fixture.ApiClient.Users.CreateAsync(newUserRequest);

        fixture.TrackIdentifier(CleanUpType.Users, user.UserId);

        // Assign role to the user
        await fixture.ApiClient.Users.Roles.AssignAsync(user.UserId, new AssignUserRolesRequestContent
        {
            Roles = new[] { role.Id }
        });

        // Ensure the Role is assigned to user
        var assignedRolesPager = await fixture.ApiClient.Users.Roles.ListAsync(user.UserId, new ListUserRolesRequestParameters());
        var assignedRoles = assignedRolesPager.CurrentPage.Items.ToList();
        assignedRoles.Should().NotBeNull();
        assignedRoles.Should().HaveCount(1);
        assignedRoles.First().Id.Should().Be(role.Id);

        // Remove role from user
        await fixture.ApiClient.Users.Roles.DeleteAsync(user.UserId, new DeleteUserRolesRequestContent
        {
            Roles = new[] { role.Id }
        });

        // Ensure the Role has been removed from user
        var removedRolesPager = await fixture.ApiClient.Users.Roles.ListAsync(user.UserId, new ListUserRolesRequestParameters());
        var removedRoles = removedRolesPager.CurrentPage.Items.ToList();
        removedRoles.Should().NotBeNull();
        removedRoles.Should().HaveCount(0);

        // Clean Up
        await fixture.ApiClient.Roles.DeleteAsync(role.Id);
        fixture.UnTrackIdentifier(CleanUpType.Roles, role.Id);
        await fixture.ApiClient.Users.DeleteAsync(user.UserId);
        fixture.UnTrackIdentifier(CleanUpType.Users, user.UserId);
    }

    [Fact]
    public async Task Test_roles_assign_unassign_permission_to_role()
    {
        // Add a new role
        var newRoleRequest = new CreateRoleRequestContent
        {
            Name = $"{Guid.NewGuid():N}role",
            Description = $"{Guid.NewGuid():N}description",
        };
        var role = await fixture.ApiClient.Roles.CreateAsync(newRoleRequest);

        fixture.TrackIdentifier(CleanUpType.Roles, role.Id);

        role.Should().NotBeNull();
        role.Name.Should().Be(newRoleRequest.Name);
        role.Description.Should().Be(newRoleRequest.Description);

        // Get a resource server
        var resourceServer = await fixture.ApiClient.ResourceServers.GetAsync("dotnet-testing", new GetResourceServerRequestParameters());
        var originalScopes = resourceServer.Scopes != null ? resourceServer.Scopes.ToList() : new List<ResourceServerScope>();

        // Create a permission/scope
        var newScope = new ResourceServerScope { Value = $"{Guid.NewGuid():N}scope", Description = "Integration test" };

        // Update resource server with new scope
        var updatedResourceServer = await fixture.ApiClient.ResourceServers.UpdateAsync(resourceServer.Id, new UpdateResourceServerRequestContent
        {
            Scopes = originalScopes.Concat(new[] { newScope }).ToList(),
        });

        // Associate a permission with the role
        await fixture.ApiClient.Roles.Permissions.AddAsync(role.Id, new AddRolePermissionsRequestContent
        {
            Permissions = new[] { new PermissionRequestPayload { ResourceServerIdentifier = updatedResourceServer.Identifier, PermissionName = newScope.Value } }
        });

        // Ensure the permission is associated with the role
        var associatedPermissionsPager = await fixture.ApiClient.Roles.Permissions.ListAsync(role.Id, new ListRolePermissionsRequestParameters());
        var associatedPermissions = associatedPermissionsPager.CurrentPage.Items.ToList();
        associatedPermissions.Should().NotBeNull();
        associatedPermissions.Should().HaveCount(1);
        associatedPermissions.First().ResourceServerIdentifier.Should().Be(updatedResourceServer.Identifier);
        associatedPermissions.First().PermissionName.Should().Be(newScope.Value);

        // Unassociate a permission with the role
        await fixture.ApiClient.Roles.Permissions.DeleteAsync(role.Id, new DeleteRolePermissionsRequestContent
        {
            Permissions = new[] { new PermissionRequestPayload { ResourceServerIdentifier = updatedResourceServer.Identifier, PermissionName = newScope.Value } }
        });

        // Ensure the permission is unassociated with the role
        associatedPermissionsPager = await fixture.ApiClient.Roles.Permissions.ListAsync(role.Id, new ListRolePermissionsRequestParameters());
        associatedPermissions = associatedPermissionsPager.CurrentPage.Items.ToList();
        associatedPermissions.Should().NotBeNull();
        associatedPermissions.Should().HaveCount(0);

        // Clean Up - Remove the permission from the resource server
        await fixture.ApiClient.ResourceServers.UpdateAsync(resourceServer.Id, new UpdateResourceServerRequestContent
        {
            Scopes = originalScopes
        });

        // Clean Up - Remove the role
        await fixture.ApiClient.Roles.DeleteAsync(role.Id);
        fixture.UnTrackIdentifier(CleanUpType.Roles, role.Id);
    }

    [Fact]
    public async Task Test_when_paging_not_specified_does_not_include_totals()
    {
        // Act
        var rolesPager = await fixture.ApiClient.Roles.ListAsync(new ListRolesRequestParameters());

        // Assert
        rolesPager.CurrentPage.Items.Should().NotBeNull();
    }

    [Fact]
    public async Task Test_paging_with_totals()
    {
        // Act
        var rolesPager = await fixture.ApiClient.Roles.ListAsync(new ListRolesRequestParameters
        {
            Page = 0,
            PerPage = 50,
            IncludeTotals = true
        });

        // Assert
        rolesPager.CurrentPage.Items.Should().NotBeNull();
    }

    [Fact]
    public async Task Test_paging_includes_totals()
    {
        // Act
        var rolesPager = await fixture.ApiClient.Roles.ListAsync(new ListRolesRequestParameters
        {
            Page = 0,
            PerPage = 50,
            IncludeTotals = true
        });

        // Assert
        rolesPager.CurrentPage.Items.Should().NotBeNull();
    }

    [Fact]
    public async Task Test_permissions_can_be_retrieved()
    {
        var newRoleRequest = new CreateRoleRequestContent
        {
            Name = $"{Guid.NewGuid():N}role",
            Description = $"{Guid.NewGuid():N}description",
        };
        var role = await fixture.ApiClient.Roles.CreateAsync(newRoleRequest);
        fixture.TrackIdentifier(CleanUpType.Roles, role.Id);

        await fixture.ApiClient.Roles.Permissions.AddAsync(role.Id, new AddRolePermissionsRequestContent
        {
            Permissions = new List<PermissionRequestPayload>
            {
                new() { PermissionName = "dotnet:testing", ResourceServerIdentifier = "dotnet-testing" }
            }
        });

        var userPermissionsPager = await fixture.ApiClient.Roles.Permissions.ListAsync(role.Id, new ListRolePermissionsRequestParameters
        {
            Page = 0,
            PerPage = 50,
            IncludeTotals = true
        });

        Assert.Equal(1, userPermissionsPager.CurrentPage.Items.Count());

        await fixture.ApiClient.Roles.Permissions.DeleteAsync(role.Id, new DeleteRolePermissionsRequestContent
        {
            Permissions = new List<PermissionRequestPayload>
            {
                new() { PermissionName = "dotnet:testing", ResourceServerIdentifier = "dotnet-testing" }
            }
        });
        await fixture.ApiClient.Roles.DeleteAsync(role.Id);
        fixture.UnTrackIdentifier(CleanUpType.Roles, role.Id);
    }
}
