using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class RolesTests : TestBase, IAsyncLifetime
    {
        private ManagementApiClient _apiClient;
        private Connection _connection;
        private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            _apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));

            // We will need a connection to add the roles to...
            _connection = await _apiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = Guid.NewGuid().ToString("N"),
                Strategy = "auth0",
                EnabledClients = new[] {GetVariable("AUTH0_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID")}
            });
        }

        public async Task DisposeAsync()
        {
            await _apiClient.Connections.DeleteAsync(_connection.Id);
        }

        [Fact]
        public async Task Test_roles_crud_sequence()
        {
            // Add a new role
            var newRoleRequest = new RoleCreateRequest
            {
                Name = $"{Guid.NewGuid():N}role",
                Description = $"{Guid.NewGuid():N}description",
            };
            var newRoleResponse = await _apiClient.Roles.CreateAsync(newRoleRequest);
            newRoleResponse.Should().NotBeNull();
            newRoleResponse.Name.Should().Be(newRoleRequest.Name);
            newRoleResponse.Description.Should().Be(newRoleRequest.Description);

            // Update the role
            var updateRoleRequest = new RoleUpdateRequest
            {
                Name = $"{Guid.NewGuid():N}role",
            };
            var updateRoleResponse = await _apiClient.Roles.UpdateAsync(newRoleResponse.Id, updateRoleRequest);
            updateRoleResponse.Should().NotBeNull();
            updateRoleResponse.Name.Should().Be(updateRoleRequest.Name);

            // Get a single role
            var role = await _apiClient.Roles.GetAsync(newRoleResponse.Id);
            role.Should().NotBeNull();
            role.Name.Should().Be(updateRoleResponse.Name);

            // Create a user
            var newUserRequest = new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            };
            var user = await _apiClient.Users.CreateAsync(newUserRequest);

            // Assign a user to the role
            var assignUsersRequest = new AssignUsersRequest
            {
                Users = new[]
                {
                    user.UserId
                }
            };
            await _apiClient.Roles.AssignUsersAsync(role.Id, assignUsersRequest);

            // Ensure the user is assigned to the role
            var assignedUsers = await _apiClient.Roles.GetUsersAsync(role.Id);
            assignedUsers.Should().NotBeNull();
            assignedUsers.First().UserId.Should().Be(user.UserId);

            // Ensure the Role is assigned to user
            var assignedRoles = await _apiClient.Users.GetRolesAsync(user.UserId, new PaginationInfo());
            assignedRoles.Should().NotBeNull();
            assignedRoles.First().Id.Should().Be(role.Id);

            // Delete the role and ensure we get an exception when trying to fetch them again
            await _apiClient.Roles.DeleteAsync(role.Id);
            Func<Task> getFunc = async () => await _apiClient.Roles.GetAsync(role.Id);
            getFunc.Should().Throw<ErrorApiException>().And.ApiError.Error.Should().Be("Not Found");

            // Delete the user
            await _apiClient.Users.DeleteAsync(user.UserId);
        }

        [Fact]
        public async Task Test_roles_assign_user_to_role()
        {
            // Add a new role
            var newRoleRequest = new RoleCreateRequest
            {
                Name = $"{Guid.NewGuid():N}role",
                Description = $"{Guid.NewGuid():N}description",
            };
            var role = await _apiClient.Roles.CreateAsync(newRoleRequest);
            role.Should().NotBeNull();
            role.Name.Should().Be(newRoleRequest.Name);
            role.Description.Should().Be(newRoleRequest.Description);

            // Create a user
            var newUserRequest = new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            };
            var user = await _apiClient.Users.CreateAsync(newUserRequest);

            // Assign a user to the role
            var assignUsersRequest = new AssignUsersRequest
            {
                Users = new[]
                {
                    user.UserId
                }
            };
            await _apiClient.Roles.AssignUsersAsync(role.Id, assignUsersRequest);

            // Ensure the user is assigned to the role
            var assignedUsers = await _apiClient.Roles.GetUsersAsync(role.Id);
            assignedUsers.Should().NotBeNull();
            assignedUsers.First().UserId.Should().Be(user.UserId);

            // Clean Up
            await _apiClient.Roles.DeleteAsync(role.Id);
            await _apiClient.Users.DeleteAsync(user.UserId);
        }

        [Fact]
        public async Task Test_roles_assign_role_to_user()
        {
            // Add a new role
            var newRoleRequest = new RoleCreateRequest
            {
                Name = $"{Guid.NewGuid():N}role",
                Description = $"{Guid.NewGuid():N}description",
            };
            var role = await _apiClient.Roles.CreateAsync(newRoleRequest);
            role.Should().NotBeNull();
            role.Name.Should().Be(newRoleRequest.Name);
            role.Description.Should().Be(newRoleRequest.Description);

            // Create a user
            var newUserRequest = new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            };
            var user = await _apiClient.Users.CreateAsync(newUserRequest);

            // Assign a user to the role
            var assignRolesRequest = new AssignRolesRequest()
            {
                Roles = new[]
                {
                    role.Id
                }
            };
            await _apiClient.Users.AssignRolesAsync(user.UserId, assignRolesRequest);

            // Ensure the Role is assigned to user
            var assignedRoles = await _apiClient.Users.GetRolesAsync(user.UserId, new PaginationInfo());
            assignedRoles.Should().NotBeNull();
            assignedRoles.Should().HaveCount(1);
            assignedRoles.First().Id.Should().Be(role.Id);

            // Remove role from user
            await _apiClient.Users.RemoveRolesAsync(user.UserId, assignRolesRequest);

            // Ensure the Role has been removed from user
            var removedRoles = await _apiClient.Users.GetRolesAsync(user.UserId, new PaginationInfo());
            removedRoles.Should().NotBeNull();
            removedRoles.Should().HaveCount(0);

            // Clean Up
            await _apiClient.Roles.DeleteAsync(role.Id);
            await _apiClient.Users.DeleteAsync(user.UserId);
        }

        [Fact]
        public async Task Test_roles_assign_unassign_permission_to_role()
        {
            // Add a new role
            var newRoleRequest = new RoleCreateRequest
            {
                Name = $"{Guid.NewGuid():N}role",
                Description = $"{Guid.NewGuid():N}description",
            };
            var role = await _apiClient.Roles.CreateAsync(newRoleRequest);
            role.Should().NotBeNull();
            role.Name.Should().Be(newRoleRequest.Name);
            role.Description.Should().Be(newRoleRequest.Description);

            // Get a resource server
            var resourceServer = await _apiClient.ResourceServers.GetAsync("5cccc711773967081270a036");
            var originalScopes = resourceServer.Scopes.ToList();

            // Create a permission/scope
            var newScope = new ResourceServerScope { Value = $"{Guid.NewGuid():N}scope", Description = "Integration test" };

            // Update resource server with new scope
            resourceServer = await _apiClient.ResourceServers.UpdateAsync(resourceServer.Id, new ResourceServerUpdateRequest
            {
                Scopes = originalScopes.Concat(new[] { newScope }).ToList(),
            });

            // Associate a permission with the role
            var assignPermissionsRequest = new AssignPermissionsRequest()
            {
                Permissions = new[] { new PermissionIdentity { Identifier = resourceServer.Identifier, Name = newScope.Value } } 
            };
            await _apiClient.Roles.AssignPermissionsAsync(role.Id, assignPermissionsRequest);

            // Ensure the permission is associated with the role
            var associatedPermissions = await _apiClient.Roles.GetPermissionsAsync(role.Id, new PaginationInfo());
            associatedPermissions.Should().NotBeNull();
            associatedPermissions.Should().HaveCount(1);
            associatedPermissions.First().Identifier.Should().Be(resourceServer.Identifier);
            associatedPermissions.First().Name.Should().Be(newScope.Value);

            // Unassociate a permission with the role
            await _apiClient.Roles.RemovePermissionsAsync(role.Id, assignPermissionsRequest);

            // Ensure the permission is unassociated with the role
            associatedPermissions = await _apiClient.Roles.GetPermissionsAsync(role.Id, new PaginationInfo());
            associatedPermissions.Should().NotBeNull();
            associatedPermissions.Should().HaveCount(0);

            // Clean Up - Remove the permission from the resource server
            resourceServer = await _apiClient.ResourceServers.UpdateAsync(resourceServer.Id, new ResourceServerUpdateRequest
            {
                Scopes = originalScopes
            });

            // Clean Up - Remove the role
            await _apiClient.Roles.DeleteAsync(role.Id);
        }

        [Fact]
        public async Task Test_when_paging_not_specified_does_not_include_totals()
        {
            // Act
            var roles = await _apiClient.Roles.GetAllAsync(new GetRolesRequest());

            // Assert
            Assert.Null(roles.Paging);
        }

        [Fact]
        public async Task Test_paging_does_not_include_totals()
        {
            // Act
            var roles = await _apiClient.Roles.GetAllAsync(new GetRolesRequest(), new PaginationInfo(0, 50, false));

            // Assert
            Assert.Null(roles.Paging);
        }

        [Fact]
        public async Task Test_paging_includes_totals()
        {
            // Act
            var roles = await _apiClient.Roles.GetAllAsync(new GetRolesRequest(), new PaginationInfo(0, 50, true));

            // Assert
            Assert.NotNull(roles.Paging);
        }

        [Fact]
        public async Task Test_permissions_can_be_retrieved()
        {
            var userPermissions = await _apiClient.Roles.GetPermissionsAsync("rol_XzVrldh70ox7yjl2", new PaginationInfo(0, 50, true));

            Assert.Equal(2, userPermissions.Count);
        }
    }
}
