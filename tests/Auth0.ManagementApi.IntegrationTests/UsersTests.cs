using System;
using System.Dynamic;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;
using System.Linq;
using Auth0.ManagementApi.Paging;
using System.Collections.Generic;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class UsersTestsFixture : TestBaseFixture
    {
        public Connection Connection { get; private set; }
        public User User { get; private set; }
        public const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            Connection = await ApiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}",
                Strategy = "auth0",
                EnabledClients = new[] { TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
            });

            TrackIdentifier(CleanUpType.Connections, Connection.Id);

            User = await ApiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = Connection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            });

            TrackIdentifier(CleanUpType.Users, User.UserId);
        }

        public override async Task DisposeAsync()
        {
            foreach (KeyValuePair<CleanUpType, IList<string>> entry in identifiers)
            {
                await ManagementTestBaseUtils.CleanupAsync(ApiClient, entry.Key, entry.Value);
            }

            ApiClient?.Dispose();
        }
    }

    public class UsersTests : IClassFixture<UsersTestsFixture>
    {
        private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        UsersTestsFixture fixture;

        public UsersTests(UsersTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task Test_users_crud_sequence()
        {
            // Add a new user
            var newUserRequest = new UserCreateRequest
            {
                Connection = fixture.Connection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            };
            var newUserResponse = await fixture.ApiClient.Users.CreateAsync(newUserRequest);

            fixture.TrackIdentifier(CleanUpType.Users, newUserResponse.UserId);

            newUserResponse.Should().NotBeNull();
            newUserResponse.Email.Should().Be(newUserRequest.Email);

            // Get all the users again. Verify we now have one more
            //var usersAfter = await fixture.ApiClient.Users.GetAllAsync();
            //usersAfter.Count.Should().Be(usersBefore.Count + 1);

            // Update the user
            var updateUserRequest = new UserUpdateRequest
            {
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                VerifyEmail = false
            };
            var updateUserResponse = await fixture.ApiClient.Users.UpdateAsync(newUserResponse.UserId, updateUserRequest);
            updateUserResponse.Should().NotBeNull();
            updateUserResponse.Email.Should().Be(updateUserRequest.Email);

            // Ensure firstname, lastname etc are ignored and not sent to Auth0. If not, the following will throw an exception
            updateUserRequest = new UserUpdateRequest
            {
                EmailVerified = true // We need to pass in at least one property, so we set this as the other properties below will not be serialized
            };
            await fixture.ApiClient.Users.UpdateAsync(newUserResponse.UserId, updateUserRequest);

            // Get a single user
            var user = await fixture.ApiClient.Users.GetAsync(newUserResponse.UserId);
            user.Should().NotBeNull();
            user.Email.Should().Be(updateUserResponse.Email);

            // Delete the user and ensure we get an exception when trying to fetch them again
            await fixture.ApiClient.Users.DeleteAsync(user.UserId);
            Func<Task> getFunc = async () => await fixture.ApiClient.Users.GetAsync(user.UserId);
            getFunc.Should().Throw<ErrorApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_user");

            fixture.UnTrackIdentifier(CleanUpType.Users, newUserResponse.UserId);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void Attempting_to_delete_users_with_null_or_empty_id_should_throw(string id)
        {
            Func<Task> deleteFunc = async () => await fixture.ApiClient.Users.DeleteAsync(id);
            deleteFunc.Should().Throw<ArgumentException>().And.Message.Should().StartWith("Value cannot be null or whitespace.");
        }

        [Fact]
        public async Task Test_user_by_email()
        {
            var email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}";

            var newUserRequest = new UserCreateRequest
            {
                Connection = fixture.Connection.Name,
                Email = email,
                EmailVerified = true,
                Password = Password
            };

            var newUserResponse = await fixture.ApiClient.Users.CreateAsync(newUserRequest);
            fixture.TrackIdentifier(CleanUpType.Users, newUserResponse.UserId);

            // Ensure we can find the user by email address
            var users = await fixture.ApiClient.Users.GetUsersByEmailAsync(email);
            Assert.Single(users);

            // Make sure they are one and the same
            Assert.Equal(newUserResponse.UserId, users[0].UserId);

            await fixture.ApiClient.Users.DeleteAsync(newUserResponse.UserId);
            fixture.UnTrackIdentifier(CleanUpType.Users, newUserResponse.UserId);
        }

        [Fact]
        public async Task Test_user_blocking()
        {
            // Add a new user, and ensure user is not blocked
            var newUserRequest = new UserCreateRequest
            {
                Connection = fixture.Connection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            };
            var newUserResponse = await fixture.ApiClient.Users.CreateAsync(newUserRequest);

            fixture.TrackIdentifier(CleanUpType.Users, newUserResponse.UserId);

            Assert.NotEqual(true, newUserResponse.Blocked);

            // Ensure the user is not blocked when we select the user individually
            var user = await fixture.ApiClient.Users.GetAsync(newUserResponse.UserId);
            user.Blocked.Should().NotBeTrue();

            // Block the user, and ensure returned user is blocked
            var updateUserRequest = new UserUpdateRequest
            {
                Blocked = true
            };
            var updateUserResponse = await fixture.ApiClient.Users.UpdateAsync(newUserResponse.UserId, updateUserRequest);
            updateUserResponse.Blocked.Should().BeTrue();

            // Ensure the user is not blocked when we select the user individually
            user = await fixture.ApiClient.Users.GetAsync(newUserResponse.UserId);
            user.Blocked.Should().BeTrue();

            // Delete the user
            await fixture.ApiClient.Users.DeleteAsync(user.UserId);
            fixture.UnTrackIdentifier(CleanUpType.Users, newUserResponse.UserId);
        }

        [Fact]
        public async Task Test_deleting_user_from_connection()
        {
            // Add a new user, and ensure user is not blocked
            var newUserRequest = new UserCreateRequest
            {
                Connection = fixture.Connection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            };
            var newUserResponse = await fixture.ApiClient.Users.CreateAsync(newUserRequest);
            fixture.TrackIdentifier(CleanUpType.Users, newUserResponse.UserId);

            Assert.NotEqual(true, newUserResponse.Blocked);

            // Delete the user from the connection
            await fixture.ApiClient.Connections.DeleteUserAsync(fixture.Connection.Id, newUserRequest.Email);

            await fixture.ApiClient.Users.DeleteAsync(newUserResponse.UserId);
            fixture.UnTrackIdentifier(CleanUpType.Users, newUserResponse.UserId);
        }

        [Fact]
        public async Task Test_when_paging_not_specified_does_not_include_totals()
        {
            // Act
            var users = await fixture.ApiClient.Users.GetAllAsync(new GetUsersRequest(), new PaginationInfo());

            // Assert
            Assert.Null(users.Paging);
        }

        [Fact]
        public async Task Test_paging_does_not_include_totals()
        {
            // Act
            var users = await fixture.ApiClient.Users.GetAllAsync(new GetUsersRequest(), new PaginationInfo(0, 50, false));

            // Assert
            Assert.Null(users.Paging);
        }

        [Fact]
        public async Task Test_paging_includes_totals()
        {
            // Act
            var users = await fixture.ApiClient.Users.GetAllAsync(new GetUsersRequest(), new PaginationInfo(0, 50, true));

            // Assert
            Assert.NotNull(users.Paging);
        }

        [Fact]
        public async Task Test_without_paging()
        {
            // Act
            var users = await fixture.ApiClient.Users.GetAllAsync(new GetUsersRequest());

            // Assert
            users.Paging.Should().BeNull();
            users.Count.Should().BeGreaterThan(0);
        }


        [Fact]
        public async Task Can_update_user_metadata()
        {
            // Add a new user with metadata
            var newUserRequest = new UserCreateRequest
            {
                Connection = fixture.Connection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
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
            var newUserResponse = await fixture.ApiClient.Users.CreateAsync(newUserRequest);
            fixture.TrackIdentifier(CleanUpType.Users, newUserResponse.UserId);

            Assert.Equal("red", newUserResponse.UserMetadata.Color.ToString());

            // Do some updating
            var updateUserRequest = new UserUpdateRequest
            {
                AppMetadata = new ExpandoObject(),
                UserMetadata = new ExpandoObject()
            };
            updateUserRequest.AppMetadata.IsSubscribedTo = "1";
            updateUserRequest.UserMetadata.Color = null;
            await fixture.ApiClient.Users.UpdateAsync(newUserResponse.UserId, updateUserRequest);

            // Get the user to ensure the metadata was set
            var user = await fixture.ApiClient.Users.GetAsync(newUserResponse.UserId);
            Assert.Equal("1", user.AppMetadata.IsSubscribedTo.ToString());
            Assert.Null(user.UserMetadata.Color);

            // Delete the user
            await fixture.ApiClient.Users.DeleteAsync(user.UserId);
            fixture.UnTrackIdentifier(CleanUpType.Users, newUserResponse.UserId);

        }


        [Fact]
        public async Task Can_read_user_metadata_as_type()
        {
            // Add a new user with metadata
            var customAppMetadata = new CustomMetadata
            {
                Amount = 42,
                Name = "A name"
            };
            var customUserMetadat = new CustomMetadata
            {
                Amount = 43,
                Name = "One off"
            };
            var newUserRequest = new UserCreateRequest
            {
                Connection = fixture.Connection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            };
            newUserRequest.SetAppMetadata(customAppMetadata);
            newUserRequest.SetUserMetadata(customUserMetadat);

            var newUserResponse = await fixture.ApiClient.Users.CreateAsync(newUserRequest);
            fixture.TrackIdentifier(CleanUpType.Users, newUserResponse.UserId);
            // read metadata
            var appMetadata = newUserResponse.GetAppMetadata<CustomMetadata>();
            var userMetadata = newUserResponse.GetUserMetadata<CustomMetadata>();

            Assert.NotNull(appMetadata);
            Assert.Equal(appMetadata.Amount, customAppMetadata.Amount);
            Assert.Equal(appMetadata.Name, customAppMetadata.Name);

            Assert.NotNull(userMetadata);
            Assert.Equal(userMetadata.Amount, customUserMetadat.Amount);
            Assert.Equal(userMetadata.Name, customUserMetadat.Name);

            // Do some updating
            var updateUserRequest = new UserUpdateRequest();
            customAppMetadata = new CustomMetadata
            {
                Amount = 1,
                Name = "Another name"
            };
            customUserMetadat = new CustomMetadata
            {
                Amount = 44,
                Name = "Two off"
            };
            updateUserRequest.SetAppMetadata(customAppMetadata);
            updateUserRequest.SetUserMetadata(customUserMetadat);
            await fixture.ApiClient.Users.UpdateAsync(newUserResponse.UserId, updateUserRequest);

            // Get the user to ensure the metadata was set
            var user = await fixture.ApiClient.Users.GetAsync(newUserResponse.UserId);
            appMetadata = user.GetAppMetadata<CustomMetadata>();
            userMetadata = user.GetUserMetadata<CustomMetadata>();

            Assert.NotNull(appMetadata);
            Assert.Equal(appMetadata.Amount, customAppMetadata.Amount);
            Assert.Equal(appMetadata.Name, customAppMetadata.Name);

            Assert.NotNull(userMetadata);
            Assert.Equal(userMetadata.Amount, customUserMetadat.Amount);
            Assert.Equal(userMetadata.Name, customUserMetadat.Name);

            // Delete the user
            await fixture.ApiClient.Users.DeleteAsync(user.UserId);
            fixture.UnTrackIdentifier(CleanUpType.Users, newUserResponse.UserId);
        }

        [Fact]
        public async Task Test_logs_deserialization_without_totals()
        {
            var newUserRequest = new UserCreateRequest
            {
                Connection = fixture.Connection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            };
            var user = await fixture.ApiClient.Users.CreateAsync(newUserRequest);
            fixture.TrackIdentifier(CleanUpType.Users, user.UserId);

            var logEntries = await fixture.ApiClient.Users.GetLogsAsync(new GetUserLogsRequest
            {
                UserId = user.UserId
            }, new PaginationInfo());

            await fixture.ApiClient.Users.DeleteAsync(user.UserId);
            fixture.UnTrackIdentifier(CleanUpType.Users, user.UserId);


            logEntries.Should().NotBeNull();
            logEntries.Paging.Should().BeNull();
        }

        [Fact]
        public async Task Test_logs_deserialization_with_totals()
        {
            var newUserRequest = new UserCreateRequest
            {
                Connection = fixture.Connection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            };
            var user = await fixture.ApiClient.Users.CreateAsync(newUserRequest);
            fixture.TrackIdentifier(CleanUpType.Users, user.UserId);

            var logEntries = await fixture.ApiClient.Users.GetLogsAsync(new GetUserLogsRequest
            {
                UserId = user.UserId
            }, new PaginationInfo(0, 50, true));

            await fixture.ApiClient.Users.DeleteAsync(user.UserId);
            fixture.UnTrackIdentifier(CleanUpType.Users, user.UserId);


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
                Connection = fixture.Connection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            };

            var mainUser = await fixture.ApiClient.Users.CreateAsync(mainIdentityCreateRequest);
            fixture.TrackIdentifier(CleanUpType.Users, mainUser.UserId);

            var secondaryIdentityUserCreateRequest = new UserCreateRequest
            {
                Connection = fixture.Connection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            };

            var secondaryUser = await fixture.ApiClient.Users.CreateAsync(secondaryIdentityUserCreateRequest);
            fixture.TrackIdentifier(CleanUpType.Users, secondaryUser.UserId);


            await fixture.ApiClient.Users.LinkAccountAsync(mainUser.UserId, new UserAccountLinkRequest
            {
                ConnectionId = fixture.Connection.Id,
                Provider = "auth0",
                UserId = secondaryUser.UserId.Split('|')[1]
            });


            var linkedUser = await fixture.ApiClient.Users.GetAsync(mainUser.UserId);
            linkedUser.Should().NotBeNull();
            linkedUser.Identities.Should().HaveCount(2);
            var secondaryIdentity = linkedUser.Identities[1];
            secondaryIdentity.ProfileData.Should().NotBeNull();
            secondaryIdentity.ProfileData["email"].Should().Be(secondaryUser.Email);


            await fixture.ApiClient.Users.DeleteAsync(mainUser.UserId);
            fixture.UnTrackIdentifier(CleanUpType.Users, mainUser.UserId);


            await fixture.ApiClient.Users.DeleteAsync(secondaryUser.UserId);
            fixture.UnTrackIdentifier(CleanUpType.Users, secondaryUser.UserId);
        }

        [Fact]
        public async Task Can_create_user_with_custom_id()
        {
            string userId = Guid.NewGuid().ToString("N");

            var userCreateRequest = new UserCreateRequest
            {
                UserId = userId,
                Connection = fixture.Connection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            };
            var user = await fixture.ApiClient.Users.CreateAsync(userCreateRequest);
            fixture.TrackIdentifier(CleanUpType.Users, user.UserId);

            // Retrieve the new user
            user = await fixture.ApiClient.Users.GetAsync(user.UserId);

            // Verify
            user.Should().NotBeNull();
            user.Identities[0].UserId.Should().Be(userId);

            await fixture.ApiClient.Users.DeleteAsync(user.UserId);
            fixture.UnTrackIdentifier(CleanUpType.Users, user.UserId);
        }

        [Fact]
        public async Task Test_roles_assign_unassign_permission_to_user()
        {
            var userCreateRequest = new UserCreateRequest
            {
                Connection = fixture.Connection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            };

            var user = await fixture.ApiClient.Users.CreateAsync(userCreateRequest);
            fixture.TrackIdentifier(CleanUpType.Users, user.UserId);

            // Get a resource server
            var resourceServer = await fixture.ApiClient.ResourceServers.GetAsync("dotnet-testing");
            var originalScopes = resourceServer.Scopes != null ? resourceServer.Scopes.ToList() : new List<ResourceServerScope>();


            // Create a permission/scope
            var newScope = new ResourceServerScope { Value = $"{Guid.NewGuid():N}scope", Description = "Integration test" };

            // Update resource server with new scope
            resourceServer = await fixture.ApiClient.ResourceServers.UpdateAsync(resourceServer.Id, new ResourceServerUpdateRequest
            {
                Scopes = originalScopes.Concat(new[] { newScope }).ToList(),
            });

            // Associate a permission with the user
            var assignPermissionsRequest = new AssignPermissionsRequest()
            {
                Permissions = new[] { new PermissionIdentity { Identifier = resourceServer.Identifier, Name = newScope.Value } }
            };
            await fixture.ApiClient.Users.AssignPermissionsAsync(user.UserId, assignPermissionsRequest);

            // Ensure the permission is associated with the user
            var associatedPermissions = await fixture.ApiClient.Users.GetPermissionsAsync(user.UserId, new PaginationInfo());
            associatedPermissions.Should().NotBeNull();
            associatedPermissions.Should().HaveCount(1);
            associatedPermissions.First().Identifier.Should().Be(resourceServer.Identifier);
            associatedPermissions.First().Name.Should().Be(newScope.Value);

            // check permission sources
            associatedPermissions.First().Sources.Should().HaveCount(1);
            associatedPermissions.First().Sources.First().ID.Should().Be(string.Empty);
            associatedPermissions.First().Sources.First().Name.Should().Be(string.Empty);
            associatedPermissions.First().Sources.First().Type.Should().Be(PermissionSourceType.Direct);

            // Unassociate a permission with the user
            await fixture.ApiClient.Users.RemovePermissionsAsync(user.UserId, assignPermissionsRequest);

            // Ensure the permission is unassociated with the user
            associatedPermissions = await fixture.ApiClient.Users.GetPermissionsAsync(user.UserId, new PaginationInfo());
            associatedPermissions.Should().NotBeNull();
            associatedPermissions.Should().HaveCount(0);

            // Clean Up - Remove the permission from the resource server
            await fixture.ApiClient.ResourceServers.UpdateAsync(resourceServer.Id, new ResourceServerUpdateRequest
            {
                Scopes = originalScopes
            });

            // Clean Up - Remove the user
            await fixture.ApiClient.Users.DeleteAsync(user.UserId);
            fixture.UnTrackIdentifier(CleanUpType.Users, user.UserId);
        }

        [Fact]
        public async void Test_user_organizations()
        {
            var existingOrganizationId = "org_V6ojENVd1ERs5YY1";
            var userCreateRequest = new UserCreateRequest
            {
                Connection = fixture.Connection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            };

            var user = await fixture.ApiClient.Users.CreateAsync(userCreateRequest);
            fixture.TrackIdentifier(CleanUpType.Users, user.UserId);

            await fixture.ApiClient.Organizations.AddMembersAsync(existingOrganizationId, new OrganizationAddMembersRequest
            {
                Members = new List<string> { user.UserId }
            });

            var organizations = await fixture.ApiClient.Users.GetAllOrganizationsAsync(user.UserId, new PaginationInfo());

            organizations.Should().NotBeNull();
            organizations.Count.Should().Be(1);

            await fixture.ApiClient.Organizations.DeleteMemberAsync(existingOrganizationId, new OrganizationDeleteMembersRequest
            {
                Members = new List<string> { user.UserId }
            });

            organizations = await fixture.ApiClient.Users.GetAllOrganizationsAsync(user.UserId, new PaginationInfo());

            organizations.Should().NotBeNull();
            organizations.Count.Should().Be(0);

            // Clean Up - Remove the user
            await fixture.ApiClient.Users.DeleteAsync(user.UserId);
            fixture.UnTrackIdentifier(CleanUpType.Users, user.UserId);
        }

        [Fact]
        public async Task Test_authentication_methods_crud()
        {
            var authenticationMethods = await fixture.ApiClient.Users.GetAuthenticationMethodsAsync(fixture.User.UserId, new PaginationInfo(0, 50, true));

            var newAuthenticationMethod = await fixture.ApiClient.Users.CreateAuthenticationMethodAsync(fixture.User.UserId, new Models.Users.AuthenticationMethodCreateRequest
            {
                Type = "email",
                Email = "frederik.prijck@gmail.com"
            });

            newAuthenticationMethod.Type.Should().Equals("email");

            await fixture.ApiClient.Users.UpdateAuthenticationMethodAsync(fixture.User.UserId, newAuthenticationMethod.Id, new Models.Users.AuthenticationMethodUpdateRequest
            {
                Name = "Test"
            });

            var getAuthenticationMethod = await fixture.ApiClient.Users.GetAuthenticationMethodAsync(fixture.User.UserId, newAuthenticationMethod.Id);
            getAuthenticationMethod.Type.Should().Equals("email");
            getAuthenticationMethod.Name.Should().Equals("Test");

            var allAuthenticationMethods = await fixture.ApiClient.Users.GetAuthenticationMethodsAsync(fixture.User.UserId);
            allAuthenticationMethods.Count.Should().Be(1);

            await fixture.ApiClient.Users.UpdateAuthenticationMethodsAsync(fixture.User.UserId, new List<Models.Users.AuthenticationMethodsUpdateRequest> {  new Models.Users.AuthenticationMethodsUpdateRequest
            {
                Name = "Test2",
                Type = "email",
                Email = "frederik.prijck@gmail.com"
            }});

            var allAuthenticationMethods2 = await fixture.ApiClient.Users.GetAuthenticationMethodsAsync(fixture.User.UserId, new PaginationInfo(0, 50, true));
            allAuthenticationMethods2.Count.Should().Be(1);

            await fixture.ApiClient.Users.DeleteAuthenticationMethodsAsync(fixture.User.UserId);

            var allAuthenticationMethods3 = await fixture.ApiClient.Users.GetAuthenticationMethodsAsync(fixture.User.UserId);
            allAuthenticationMethods3.Count.Should().Be(0);
        }

        private class CustomMetadata
        {
            public string Name { get; set; }
            public int Amount { get; set; }
        }
    }
}