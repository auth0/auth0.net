using System;
using System.Threading.Tasks;
using Auth0.Core.Models;
using Auth0.ManagementApi.Client.Exceptions;
using FluentAssertions;
using NUnit.Framework;

namespace Auth0.ManagementApi.Client.FunctionalTests
{
    [TestFixture]
    public class UsersTests : TestBase
    {
        private ManagementApiClient apiClient;
        private Connection connection;

        [SetUp]
        public async Task SetUp()
        {
            apiClient = new ManagementApiClient(GetVariable("AUTH0_TOKEN_USERS"), new Uri(GetVariable("AUTH0_API_URL")));

            // We will need a connection to add the users to...
            connection = await apiClient.Connections.Create(new ConnectionCreateRequest
            {
                Name = "integration-new-connection",
                Strategy = "auth0"
            });
        }

        [TearDown]
        public async Task TearDown()
        {
            await apiClient.Connections.Delete(connection.Id);
        } 

        [Test]
        public async Task Test_users_crud_sequence()
        {
            // Get all the users
            var usersBefore = await apiClient.Users.GetAll();

            // Add a new user
            var newUserRequest = new UserCreateRequest
            {
                Connection = connection.Name,
                Email = "test123@test.com",
                EmailVerified = true,
                Password = "password"
            };
            var newUserResponse = await apiClient.Users.Create(newUserRequest);
            newUserResponse.Should().NotBeNull();
            newUserResponse.Email.Should().Be(newUserRequest.Email);

            // Get all the users again. Verify we now have one more
            var usersAfter = await apiClient.Users.GetAll();
            usersAfter.Count.Should().Be(usersBefore.Count + 1);

            // Update the user
            var updateUserRequest = new UserUpdateRequest
            {
                Email = "test456@test.com",
                VerifyEmail = false
            };
            var updateUserResponse = await apiClient.Users.Update(newUserResponse.UserId, updateUserRequest);
            updateUserResponse.Should().NotBeNull();
            updateUserResponse.Email.Should().Be(updateUserRequest.Email);

            // Get a single user
            var user = await apiClient.Users.Get(newUserResponse.UserId);
            user.Should().NotBeNull();
            user.Email.Should().Be(updateUserResponse.Email);

            // Delete the user and ensure we get an exception when trying to fetch them again
            await apiClient.Users.Delete(user.UserId);
            Func<Task> getFunc = async () => await apiClient.Users.Get(user.UserId);
            getFunc.ShouldThrow<ApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_user");
        }
    }
}