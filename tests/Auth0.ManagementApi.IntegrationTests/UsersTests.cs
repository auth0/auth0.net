using System;
using System.Dynamic;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using NUnit.Framework;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    [TestFixture]
    public class UsersTests : TestBase
    {
        private ManagementApiClient apiClient;
        private Connection connection;

        [SetUp]
        public async Task SetUp()
        {
            var scopes = new
            {
                users = new
                {
                    actions = new string[] {"read", "create", "update", "delete"}
                },
                connections = new
                {
                    actions = new string[] {"create", "delete"}
                },
                users_app_metadata = new
                {
                    actions = new string[] {"update"}
                },
                logs = new
                {
                    actions = new string[] {"read"}
                }
            };
            string token = GenerateToken(scopes);

            apiClient = new ManagementApiClient(token, new Uri(GetVariable("AUTH0_MANAGEMENT_API_URL")));

            // We will need a connection to add the users to...
            connection = await apiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = Guid.NewGuid().ToString("N"),
                Strategy = "auth0",
                EnabledClients = new[] {"rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW"}
            });
        }

        [TearDown]
        public async Task TearDown()
        {
            await apiClient.Connections.DeleteAsync(connection.Id);
        }

        [Test]
        public async Task Test_users_crud_sequence()
        {
            // Get all the users
            var usersBefore = await apiClient.Users.GetAllAsync();

            // Add a new user
            var newUserRequest = new UserCreateRequest
            {
                Connection = connection.Name,
                Email = $"{Guid.NewGuid().ToString("N")}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = "password"
            };
            var newUserResponse = await apiClient.Users.CreateAsync(newUserRequest);
            newUserResponse.Should().NotBeNull();
            newUserResponse.Email.Should().Be(newUserRequest.Email);

            // Get all the users again. Verify we now have one more
            var usersAfter = await apiClient.Users.GetAllAsync();
            usersAfter.Count.Should().Be(usersBefore.Count + 1);

            // Update the user
            var updateUserRequest = new UserUpdateRequest
            {
                Email = $"{Guid.NewGuid().ToString("N")}@nonexistingdomain.aaa",
                VerifyEmail = false
            };
            var updateUserResponse = await apiClient.Users.UpdateAsync(newUserResponse.UserId, updateUserRequest);
            updateUserResponse.Should().NotBeNull();
            updateUserResponse.Email.Should().Be(updateUserRequest.Email);

            // Get a single user
            var user = await apiClient.Users.GetAsync(newUserResponse.UserId);
            user.Should().NotBeNull();
            user.Email.Should().Be(updateUserResponse.Email);

            // Delete the user and ensure we get an exception when trying to fetch them again
            await apiClient.Users.DeleteAsync(user.UserId);
            Func<Task> getFunc = async () => await apiClient.Users.GetAsync(user.UserId);
            getFunc.ShouldThrow<ApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_user");
        }

        [Test]
        public async Task Test_user_blocking()
        {
            // Add a new user, and ensure user is not blocked
            var newUserRequest = new UserCreateRequest
            {
                Connection = connection.Name,
                Email = $"{Guid.NewGuid().ToString("N")}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = "password"
            };
            var newUserResponse = await apiClient.Users.CreateAsync(newUserRequest);
            newUserResponse.Blocked.Should().BeFalse();

            // Ensure the user is not blocked when we select the user individually
            var user = await apiClient.Users.GetAsync(newUserResponse.UserId);
            user.Blocked.Should().BeFalse();

            // Block the user, and ensure returned user is blocked
            var updateUserRequest = new UserUpdateRequest
            {
                Blocked = true
            };
            var updateUserResponse = await apiClient.Users.UpdateAsync(newUserResponse.UserId, updateUserRequest);
            updateUserResponse.Blocked.Should().BeTrue();

            // Ensure the user is not blocked when we select the user individually
            user = await apiClient.Users.GetAsync(newUserResponse.UserId);
            user.Blocked.Should().BeTrue();

            // Delete the user
            await apiClient.Users.DeleteAsync(user.UserId);
        }

        [Test]
        public async Task Test_deleting_user_from_connection()
        {
            // Add a new user, and ensure user is not blocked
            var newUserRequest = new UserCreateRequest
            {
                Connection = connection.Name,
                Email = $"{Guid.NewGuid().ToString("N")}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = "password"
            };
            var newUserResponse = await apiClient.Users.CreateAsync(newUserRequest);
            newUserResponse.Blocked.Should().BeFalse();

            // Delete the user from the connection
            await apiClient.Connections.DeleteUserAsync(connection.Id, newUserRequest.Email);
        }

        [Test]
        public async Task Test_pagination_totals_deserialize_correctly()
        {
            var users = await apiClient.Users.GetAllAsync(includeTotals: true);

            users.Should().NotBeNull();
            users.Paging.Should().NotBeNull();
        }

        [Test, Explicit]
        public async Task Can_update_user_metadata()
        {
            // Add a new user with metadata
            var newUserRequest = new UserCreateRequest
            {
                Connection = connection.Name,
                Email = $"{Guid.NewGuid().ToString("N")}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = "password",
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
            var newUserResponse = await apiClient.Users.CreateAsync(newUserRequest);

            // Do some updating
            var updateUserRequest = new UserUpdateRequest();
            updateUserRequest.AppMetadata = new ExpandoObject();
            updateUserRequest.AppMetadata.IsSubscribedTo = "1";
            var updateUserResponse = await apiClient.Users.UpdateAsync(newUserResponse.UserId, updateUserRequest);

            // Get the user to ensure the metadata was set
            var user = await apiClient.Users.GetAsync(newUserResponse.UserId);

            // Delete the user
            await apiClient.Users.DeleteAsync(user.UserId);
        }

        [Test]
        public async Task Test_logs_deserialization_without_totals()
        {
            var newUserRequest = new UserCreateRequest
            {
                Connection = connection.Name,
                Email = $"{Guid.NewGuid().ToString("N")}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = "password"
            };
            var user = await apiClient.Users.CreateAsync(newUserRequest);

            var logEntries = await apiClient.Users.GetLogsAsync(user.UserId);

            await apiClient.Users.DeleteAsync(user.UserId);

            logEntries.Should().NotBeNull();
            logEntries.Paging.Should().BeNull();
        }

        [Test]
        public async Task Test_logs_deserialization_with_totals()
        {
            var newUserRequest = new UserCreateRequest
            {
                Connection = connection.Name,
                Email = $"{Guid.NewGuid().ToString("N")}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = "password"
            };
            var user = await apiClient.Users.CreateAsync(newUserRequest);

            var logEntries = await apiClient.Logs.GetAllAsync(includeTotals: true);

            await apiClient.Users.DeleteAsync(user.UserId);

            logEntries.Should().NotBeNull();
            logEntries.Paging.Should().NotBeNull();
        }
    }
}