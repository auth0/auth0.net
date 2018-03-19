using System;
using System.Dynamic;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;

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
            getFunc.ShouldThrow<ApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_user");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void Attempting_to_delete_users_with_null_or_empty_id_should_throw(string id)
        {
            Func<Task> deleteFunc = async () => await _apiClient.Users.DeleteAsync(id);
            deleteFunc.ShouldThrow<ArgumentException>().And.Message.Should().Be($"Value cannot be null or whitespace.{Environment.NewLine}Parameter name: id");
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
            newUserResponse.Blocked.Should().BeFalse();

            // Ensure the user is not blocked when we select the user individually
            var user = await _apiClient.Users.GetAsync(newUserResponse.UserId);
            user.Blocked.Should().BeFalse();

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
            newUserResponse.Blocked.Should().BeFalse();

            // Delete the user from the connection
            await _apiClient.Connections.DeleteUserAsync(_connection.Id, newUserRequest.Email);
        }

        [Fact(Skip = "Search for this tenant is disabled, so this will fail :(")]
        public async Task Test_pagination_totals_deserialize_correctly()
        {
            var users = await _apiClient.Users.GetAllAsync(includeTotals: true);

            users.Should().NotBeNull();
            users.Paging.Should().NotBeNull();
        }

        [Fact(Skip = "Run manually")]
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
                    d = 4
                }
            };
            var newUserResponse = await _apiClient.Users.CreateAsync(newUserRequest);

            // Do some updating
            var updateUserRequest = new UserUpdateRequest {AppMetadata = new ExpandoObject()};
            updateUserRequest.AppMetadata.IsSubscribedTo = "1";
            await _apiClient.Users.UpdateAsync(newUserResponse.UserId, updateUserRequest);

            // Get the user to ensure the metadata was set
            var user = await _apiClient.Users.GetAsync(newUserResponse.UserId);
            user.AppMetadata.IsSubscribedTo.Should().Be("1");

            // Delete the user
            await _apiClient.Users.DeleteAsync(user.UserId);
        }

        [Fact(Skip = "Need to fix!!!")]
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

            var logEntries = await _apiClient.Users.GetLogsAsync(user.UserId);

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

            var logEntries = await _apiClient.Logs.GetAllAsync(includeTotals: true);

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
    }
}