using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;
using Auth0.ManagementApi.Paging;
using System.Collections.Generic;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class RolesTests : ManagementTestBase, IAsyncLifetime
    {
        private Connection _connection;
        private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            ApiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 }));

            // We will need a connection to add the roles to...
            _connection = await ApiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = $"{TestingConstants.ConnectionPrefix}-{MakeRandomName()}",
                Strategy = "auth0",
                EnabledClients = new[] {GetVariable("AUTH0_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID")}
            });
        }

        public override async Task DisposeAsync()
        {
            await ApiClient.Connections.DeleteAsync(_connection.Id);
            await CleanupAndDisposeAsync();
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
            var newRoleResponse = await ApiClient.Roles.CreateAsync(newRoleRequest);
            newRoleResponse.Should().NotBeNull();
            newRoleResponse.Name.Should().Be(newRoleRequest.Name);
            newRoleResponse.Description.Should().Be(newRoleRequest.Description);

            // Update the role
            var updateRoleRequest = new RoleUpdateRequest
            {
                Name = $"{Guid.NewGuid():N}role",
            };
            var updateRoleResponse = await ApiClient.Roles.UpdateAsync(newRoleResponse.Id, updateRoleRequest);
            updateRoleResponse.Should().NotBeNull();
            updateRoleResponse.Name.Should().Be(updateRoleRequest.Name);

            // Get a single role
            var role = await ApiClient.Roles.GetAsync(newRoleResponse.Id);
            role.Should().NotBeNull();
            role.Name.Should().Be(updateRoleResponse.Name);

            // Create a user
            var newUserRequest = new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            };
            var user = await ApiClient.Users.CreateAsync(newUserRequest);

            // Assign a user to the role
            var assignUsersRequest = new AssignUsersRequest
            {
                Users = new[]
                {
                    user.UserId
                }
            };
            await ApiClient.Roles.AssignUsersAsync(role.Id, assignUsersRequest);

            // Ensure the user is assigned to the role
            var assignedUsers = await ApiClient.Roles.GetUsersAsync(role.Id);
            assignedUsers.Should().NotBeNull();
            assignedUsers.First().UserId.Should().Be(user.UserId);

            // Ensure the Role is assigned to user
            var assignedRoles = await ApiClient.Users.GetRolesAsync(user.UserId, new PaginationInfo());
            assignedRoles.Should().NotBeNull();
            assignedRoles.First().Id.Should().Be(role.Id);

            // Delete the role and ensure we get an exception when trying to fetch them again
            await ApiClient.Roles.DeleteAsync(role.Id);
            Func<Task> getFunc = async () => await ApiClient.Roles.GetAsync(role.Id);
            getFunc.Should().Throw<ErrorApiException>().And.ApiError.Error.Should().Be("Not Found");

            // Delete the user
            await ApiClient.Users.DeleteAsync(user.UserId);
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
            var role = await ApiClient.Roles.CreateAsync(newRoleRequest);
            role.Should().NotBeNull();
            role.Name.Should().Be(newRoleRequest.Name);
            role.Description.Should().Be(newRoleRequest.Description);

            // Create a user
            var newUserRequest = new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            };
            var user = await ApiClient.Users.CreateAsync(newUserRequest);

            // Assign a user to the role
            var assignUsersRequest = new AssignUsersRequest
            {
                Users = new[]
                {
                    user.UserId
                }
            };
            await ApiClient.Roles.AssignUsersAsync(role.Id, assignUsersRequest);

            // Ensure the user is assigned to the role
            var assignedUsers = await ApiClient.Roles.GetUsersAsync(role.Id);
            assignedUsers.Should().NotBeNull();
            assignedUsers.First().UserId.Should().Be(user.UserId);

            // Clean Up
            await ApiClient.Roles.DeleteAsync(role.Id);
            await ApiClient.Users.DeleteAsync(user.UserId);
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
            var role = await ApiClient.Roles.CreateAsync(newRoleRequest);
            role.Should().NotBeNull();
            role.Name.Should().Be(newRoleRequest.Name);
            role.Description.Should().Be(newRoleRequest.Description);

            // Create a user
            var newUserRequest = new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            };
            var user = await ApiClient.Users.CreateAsync(newUserRequest);

            // Assign a user to the role
            var assignRolesRequest = new AssignRolesRequest()
            {
                Roles = new[]
                {
                    role.Id
                }
            };
            await ApiClient.Users.AssignRolesAsync(user.UserId, assignRolesRequest);

            // Ensure the Role is assigned to user
            var assignedRoles = await ApiClient.Users.GetRolesAsync(user.UserId, new PaginationInfo());
            assignedRoles.Should().NotBeNull();
            assignedRoles.Should().HaveCount(1);
            assignedRoles.First().Id.Should().Be(role.Id);

            // Remove role from user
            await ApiClient.Users.RemoveRolesAsync(user.UserId, assignRolesRequest);

            // Ensure the Role has been removed from user
            var removedRoles = await ApiClient.Users.GetRolesAsync(user.UserId, new PaginationInfo());
            removedRoles.Should().NotBeNull();
            removedRoles.Should().HaveCount(0);

            // Clean Up
            await ApiClient.Roles.DeleteAsync(role.Id);
            await ApiClient.Users.DeleteAsync(user.UserId);
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
            var role = await ApiClient.Roles.CreateAsync(newRoleRequest);
            role.Should().NotBeNull();
            role.Name.Should().Be(newRoleRequest.Name);
            role.Description.Should().Be(newRoleRequest.Description);

            // Get a resource server
            var resourceServer = await ApiClient.ResourceServers.GetAsync("dotnet-testing");
            var originalScopes = resourceServer.Scopes != null ? resourceServer.Scopes.ToList() : new List<ResourceServerScope>();

            // Create a permission/scope
            var newScope = new ResourceServerScope { Value = $"{Guid.NewGuid():N}scope", Description = "Integration test" };

            // Update resource server with new scope
            resourceServer = await ApiClient.ResourceServers.UpdateAsync(resourceServer.Id, new ResourceServerUpdateRequest
            {
                Scopes = originalScopes.Concat(new[] { newScope }).ToList(),
            });

            // Associate a permission with the role
            var assignPermissionsRequest = new AssignPermissionsRequest()
            {
                Permissions = new[] { new PermissionIdentity { Identifier = resourceServer.Identifier, Name = newScope.Value } } 
            };
            await ApiClient.Roles.AssignPermissionsAsync(role.Id, assignPermissionsRequest);

            // Ensure the permission is associated with the role
            var associatedPermissions = await ApiClient.Roles.GetPermissionsAsync(role.Id, new PaginationInfo());
            associatedPermissions.Should().NotBeNull();
            associatedPermissions.Should().HaveCount(1);
            associatedPermissions.First().Identifier.Should().Be(resourceServer.Identifier);
            associatedPermissions.First().Name.Should().Be(newScope.Value);

            // Unassociate a permission with the role
            await ApiClient.Roles.RemovePermissionsAsync(role.Id, assignPermissionsRequest);

            // Ensure the permission is unassociated with the role
            associatedPermissions = await ApiClient.Roles.GetPermissionsAsync(role.Id, new PaginationInfo());
            associatedPermissions.Should().NotBeNull();
            associatedPermissions.Should().HaveCount(0);

            // Clean Up - Remove the permission from the resource server
            await ApiClient.ResourceServers.UpdateAsync(resourceServer.Id, new ResourceServerUpdateRequest
            {
                Scopes = originalScopes
            });

            // Clean Up - Remove the role
            await ApiClient.Roles.DeleteAsync(role.Id);
        }

        [Fact]
        public async Task Test_when_paging_not_specified_does_not_include_totals()
        {
            // Act
            var roles = await ApiClient.Roles.GetAllAsync(new GetRolesRequest());

            // Assert
            Assert.Null(roles.Paging);
        }

        [Fact]
        public async Task Test_paging_does_not_include_totals()
        {
            // Act
            var roles = await ApiClient.Roles.GetAllAsync(new GetRolesRequest(), new PaginationInfo(0, 50, false));

            // Assert
            Assert.Null(roles.Paging);
        }

        [Fact]
        public async Task Test_paging_includes_totals()
        {
            // Act
            var roles = await ApiClient.Roles.GetAllAsync(new GetRolesRequest(), new PaginationInfo(0, 50, true));

            // Assert
            Assert.NotNull(roles.Paging);
        }

        [Fact]
        public async Task Test_checkpoint_pagination()
        {
            var role = await ApiClient.Roles.CreateAsync(new RoleCreateRequest
            {
                Name = $"{Guid.NewGuid():N}role",
                Description = $"{Guid.NewGuid():N}description",
            });

            // Create a user
            var user1 = await ApiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            });
            var user2 = await ApiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            });
            
            await ApiClient.Roles.AssignUsersAsync(role.Id, new AssignUsersRequest
            {
                Users = new[]
                {
                    user1.UserId,
                    user2.UserId
                }
            });

            var firstCheckPointPaginationRequest = await ApiClient.Roles.GetUsersAsync(role.Id, new Paging.CheckpointPaginationInfo(1));
            var secondCheckPointPaginationRequest = await ApiClient.Roles.GetUsersAsync(role.Id, new Paging.CheckpointPaginationInfo(1, firstCheckPointPaginationRequest.Paging.Next));

            secondCheckPointPaginationRequest.Count.Should().Be(1);
            secondCheckPointPaginationRequest.Paging.Next.Should().NotBeNullOrEmpty();

            var checkpointPagingationRequestWithoutNext = await ApiClient.Roles.GetUsersAsync(role.Id, new Paging.CheckpointPaginationInfo(50));
            checkpointPagingationRequestWithoutNext.Count.Should().Be(2);
            checkpointPagingationRequestWithoutNext.Paging.Next.Should().BeNullOrEmpty();

            await ApiClient.Users.DeleteAsync(user1.UserId);
            await ApiClient.Users.DeleteAsync(user2.UserId);
            await ApiClient.Roles.DeleteAsync(role.Id);
        }

        [Fact]
        public async Task Test_permissions_can_be_retrieved()
        {
            var newRoleRequest = new RoleCreateRequest
            {
                Name = $"{Guid.NewGuid():N}role",
                Description = $"{Guid.NewGuid():N}description",
            };
            var role = await ApiClient.Roles.CreateAsync(newRoleRequest);

            var assignPermissionsRequest = new AssignPermissionsRequest
            {
                Permissions = new List<PermissionIdentity>
                {
                    new PermissionIdentity { Name = "dotnet:testing", Identifier = "dotnet-testing",  }
                }
            };
            await ApiClient.Roles.AssignPermissionsAsync(role.Id, assignPermissionsRequest);

            var userPermissions = await ApiClient.Roles.GetPermissionsAsync(role.Id, new PaginationInfo(0, 50, true));

            Assert.Equal(1, userPermissions.Count);

            await ApiClient.Roles.RemovePermissionsAsync(role.Id, assignPermissionsRequest);
            await ApiClient.Roles.DeleteAsync(role.Id);
        }
    }
}
