using System;
using System.Dynamic;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;
using System.Linq;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class UsersTests : TestBase, IAsyncLifetime
    {
        private ManagementApiClient _apiClient;
        private Connection _connection;
        private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            _apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));

            // We will need a connection to add the users to...
            _connection = await _apiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = Guid.NewGuid().ToString("N"),
                Strategy = "auth0",
                EnabledClients = new[] { GetVariable("AUTH0_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
            });
        }

        public async Task DisposeAsync()
        {
            await _apiClient.Connections.DeleteAsync(_connection.Id);
        }

        [Fact]
        public async Task Test_users_crud_sequence()
        {
            // Add a new user
            var newUserRequest = new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            };
            var newUserResponse = await _apiClient.Users.CreateAsync(newUserRequest);
            newUserResponse.Should().NotBeNull();
            newUserResponse.Email.Should().Be(newUserRequest.Email);

            // Get all the users again. Verify we now have one more
            //var usersAfter = await apiClient.Users.GetAllAsync();
            //usersAfter.Count.Should().Be(usersBefore.Count + 1);

            // Update the user
            var updateUserRequest = new UserUpdateRequest
            {
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                VerifyEmail = false
            };
            var updateUserResponse = await _apiClient.Users.UpdateAsync(newUserResponse.UserId, updateUserRequest);
            updateUserResponse.Should().NotBeNull();
            updateUserResponse.Email.Should().Be(updateUserRequest.Email);

            // Ensure firstname, lastname etc are ignored and not sent to Auth0. If not, the following will throw an exception
            updateUserRequest = new UserUpdateRequest
            {
                EmailVerified = true // We need to pass in at least one property, so we set this as the other properties below will not be serialized
            };
            await _apiClient.Users.UpdateAsync(newUserResponse.UserId, updateUserRequest);

            // Get a single user
            var user = await _apiClient.Users.GetAsync(newUserResponse.UserId);
            user.Should().NotBeNull();
            user.Email.Should().Be(updateUserResponse.Email);

            // Delete the user and ensure we get an exception when trying to fetch them again
            await _apiClient.Users.DeleteAsync(user.UserId);
            Func<Task> getFunc = async () => await _apiClient.Users.GetAsync(user.UserId);
            getFunc.Should().Throw<ErrorApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_user");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void Attempting_to_delete_users_with_null_or_empty_id_should_throw(string id)
        {
            Func<Task> deleteFunc = async () => await _apiClient.Users.DeleteAsync(id);
            deleteFunc.Should().Throw<ArgumentException>().And.Message.Should().Be($"Value cannot be null or whitespace.{Environment.NewLine}Parameter name: id");
        }

        [Fact]
        public async Task Test_user_by_email()
        {
            var email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa";

            var newUserRequest = new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = email,
                EmailVerified = true,
                Password = Password
            };

            var newUserResponse = await _apiClient.Users.CreateAsync(newUserRequest);

            // Ensure we can find the user by email address
            var users = await _apiClient.Users.GetUsersByEmailAsync(email);
            Assert.Single(users);

            // Make sure they are one and the same
            Assert.Equal(newUserResponse.UserId, users[0].UserId);
        }

        [Fact]
        public async Task Test_user_blocking()
        {
            // Add a new user, and ensure user is not blocked
            var newUserRequest = new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            };
            var newUserResponse = await _apiClient.Users.CreateAsync(newUserRequest);
            Assert.NotEqual(true, newUserResponse.Blocked);

            // Ensure the user is not blocked when we select the user individually
            var user = await _apiClient.Users.GetAsync(newUserResponse.UserId);
            user.Blocked.Should().NotBeTrue();

            // Block the user, and ensure returned user is blocked
            var updateUserRequest = new UserUpdateRequest
            {
                Blocked = true
            };
            var updateUserResponse = await _apiClient.Users.UpdateAsync(newUserResponse.UserId, updateUserRequest);
            updateUserResponse.Blocked.Should().BeTrue();

            // Ensure the user is not blocked when we select the user individually
            user = await _apiClient.Users.GetAsync(newUserResponse.UserId);
            user.Blocked.Should().BeTrue();

            // Delete the user
            await _apiClient.Users.DeleteAsync(user.UserId);
        }

        [Fact]
        public async Task Test_deleting_user_from_connection()
        {
            // Add a new user, and ensure user is not blocked
            var newUserRequest = new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            };
            var newUserResponse = await _apiClient.Users.CreateAsync(newUserRequest);
            Assert.NotEqual(true, newUserResponse.Blocked);

            // Delete the user from the connection
            await _apiClient.Connections.DeleteUserAsync(_connection.Id, newUserRequest.Email);
        }

        [Fact]
        public async Task Test_when_paging_not_specified_does_not_include_totals()
        {
            // Act
            var users = await _apiClient.Users.GetAllAsync(new GetUsersRequest(), new PaginationInfo());
            
            // Assert
            Assert.Null(users.Paging);
        }

        [Fact]
        public async Task Test_paging_does_not_include_totals()
        {
            // Act
            var users = await _apiClient.Users.GetAllAsync(new GetUsersRequest(), new PaginationInfo(0, 50, false));
            
            // Assert
            Assert.Null(users.Paging);
        }

        [Fact]
        public async Task Test_paging_includes_totals()
        {
            // Act
            var users = await _apiClient.Users.GetAllAsync(new GetUsersRequest(), new PaginationInfo(0, 50, true));
            
            // Assert
            Assert.NotNull(users.Paging);
        }

        [Fact]
        public async Task Can_update_user_metadata()
        {
            // Add a new user with metadata
            var newUserRequest = new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password,
                AppMetadata = new
                {
                    a = 1,
                    b = 2
                },
                UserMetadata = new
                {
                    c = 3,
                    d = 4,
                    Color = "red"
                }
            };
            var newUserResponse = await _apiClient.Users.CreateAsync(newUserRequest);
            Assert.Equal("red", newUserResponse.UserMetadata.Color.ToString());

            // Do some updating
            var updateUserRequest = new UserUpdateRequest
            {
                AppMetadata = new ExpandoObject(),
                UserMetadata = new ExpandoObject()
            };
            updateUserRequest.AppMetadata.IsSubscribedTo = "1";
            updateUserRequest.UserMetadata.Color = null;
            await _apiClient.Users.UpdateAsync(newUserResponse.UserId, updateUserRequest);

            // Get the user to ensure the metadata was set
            var user = await _apiClient.Users.GetAsync(newUserResponse.UserId);
            Assert.Equal("1", user.AppMetadata.IsSubscribedTo.ToString());
            Assert.Null(user.UserMetadata.Color);

            // Delete the user
            await _apiClient.Users.DeleteAsync(user.UserId);
        }

        [Fact]
        public async Task Test_logs_deserialization_without_totals()
        {
            var newUserRequest = new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            };
            var user = await _apiClient.Users.CreateAsync(newUserRequest);

            var logEntries = await _apiClient.Users.GetLogsAsync(new GetUserLogsRequest
            {
                UserId = user.UserId
            }, new PaginationInfo());

            await _apiClient.Users.DeleteAsync(user.UserId);

            logEntries.Should().NotBeNull();
            logEntries.Paging.Should().BeNull();
        }

        [Fact]
        public async Task Test_logs_deserialization_with_totals()
        {
            var newUserRequest = new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            };
            var user = await _apiClient.Users.CreateAsync(newUserRequest);

            var logEntries = await _apiClient.Users.GetLogsAsync(new GetUserLogsRequest
            {
                UserId = user.UserId
            }, new PaginationInfo(0, 50, true));

            await _apiClient.Users.DeleteAsync(user.UserId);

            logEntries.Should().NotBeNull();
            logEntries.Paging.Should().NotBeNull();
        }

        [Fact]
        public async Task Can_read_profileData()
        {
            // 'profileData' is available on linked identities,
            // so first let's create a linked user

            var mainIdentityCreateRequest = new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            };

            var mainUser = await _apiClient.Users.CreateAsync(mainIdentityCreateRequest);

            var secondaryIdentityUserCreateRequest = new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            };

            var secondaryUser = await _apiClient.Users.CreateAsync(secondaryIdentityUserCreateRequest);

            await _apiClient.Users.LinkAccountAsync(mainUser.UserId, new UserAccountLinkRequest
            {
                ConnectionId = _connection.Id,
                Provider = "auth0",
                UserId = secondaryUser.UserId.Split('|')[1]
            });


            var linkedUser = await _apiClient.Users.GetAsync(mainUser.UserId);
            linkedUser.Should().NotBeNull();
            linkedUser.Identities.Should().HaveCount(2);
            var secondaryIdentity = linkedUser.Identities[1];
            secondaryIdentity.ProfileData.Should().NotBeNull();
            secondaryIdentity.ProfileData["email"].Should().Be(secondaryUser.Email);
        }

        [Fact]
        public async Task Can_create_user_with_custom_id()
        {
            string userId = Guid.NewGuid().ToString("N");

            var userCreateRequest = new UserCreateRequest
            {
                UserId = userId,
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            };
            var user = await _apiClient.Users.CreateAsync(userCreateRequest);

            // Retrieve the new user
            user = await _apiClient.Users.GetAsync(user.UserId);

            // Verify
            user.Should().NotBeNull();
            user.Identities[0].UserId.Should().Be(userId);
        }

        [Fact]
        public async Task Test_permissions_can_be_retrieved()
        {
            var userPermissions = await _apiClient.Users.GetPermissionsAsync("auth0|5d4344cd2c016b0e7a14313a", new PaginationInfo(0, 50, true));
            
            Assert.Equal(2, userPermissions.Count);
        }

        [Fact]
        public async Task Test_roles_assign_unassign_permission_to_user()
        {
            var userCreateRequest = new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            };

            var user = await _apiClient.Users.CreateAsync(userCreateRequest);

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

            // Associate a permission with the user
            var assignPermissionsRequest = new AssignPermissionsRequest()
            {
                Permissions = new[] { new PermissionIdentity { Identifier = resourceServer.Identifier, Name = newScope.Value } }
            };
            await _apiClient.Users.AssignPermissionsAsync(user.UserId, assignPermissionsRequest);

            // Ensure the permission is associated with the user
            var associatedPermissions = await _apiClient.Users.GetPermissionsAsync(user.UserId, new PaginationInfo());
            associatedPermissions.Should().NotBeNull();
            associatedPermissions.Should().HaveCount(1);
            associatedPermissions.First().Identifier.Should().Be(resourceServer.Identifier);
            associatedPermissions.First().Name.Should().Be(newScope.Value);

            // Unassociate a permission with the user
            await _apiClient.Users.RemovePermissionsAsync(user.UserId, assignPermissionsRequest);

            // Ensure the permission is unassociated with the user
            associatedPermissions = await _apiClient.Users.GetPermissionsAsync(user.UserId, new PaginationInfo());
            associatedPermissions.Should().NotBeNull();
            associatedPermissions.Should().HaveCount(0);

            // Clean Up - Remove the permission from the resource server
            await _apiClient.ResourceServers.UpdateAsync(resourceServer.Id, new ResourceServerUpdateRequest
            {
                Scopes = originalScopes
            });

            // Clean Up - Remove the user
            await _apiClient.Users.DeleteAsync(user.UserId);
        }
    }
}