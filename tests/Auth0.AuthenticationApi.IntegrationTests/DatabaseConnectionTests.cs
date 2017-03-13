using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Models;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    public class DatabaseConnectionTests : TestBase, IAsyncLifetime
    {
        private ManagementApiClient managementApiClient;
        private Connection connection;

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            managementApiClient = new ManagementApiClient(token, new Uri(GetVariable("AUTH0_MANAGEMENT_API_URL")));

            // We will need a connection to add the users to...
            connection = await managementApiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = Guid.NewGuid().ToString("N"),
                Strategy = "auth0",
                EnabledClients = new[] { GetVariable("AUTH0_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
            });
        }

        public async Task DisposeAsync()
        {
            if (connection != null)
                await managementApiClient.Connections.DeleteAsync(connection.Id);
        }

        [Fact]
        public async Task Can_signup_user_and_change_password()
        {
            // Arrange
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            // Sign up the user
            var signupUserRequest = new SignupUserRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Connection = connection.Name,
                Email = $"{Guid.NewGuid().ToString("N")}@nonexistingdomain.aaa",
                Password = "password"
            };
            var signupUserResponse = await authenticationApiClient.SignupUserAsync(signupUserRequest);
            signupUserResponse.Should().NotBeNull();
            signupUserResponse.Id.Should().NotBeNull();
            signupUserResponse.EmailVerified.Should().BeFalse();
            signupUserResponse.Email.Should().Be(signupUserRequest.Email);

            // Change the user's Email address
            var changePasswordRequest = new ChangePasswordRequest
            {
                ClientId = signupUserRequest.ClientId,
                Connection = signupUserRequest.Connection,
                Email = signupUserRequest.Email,
                Password = "password2"
            };
            string changePasswordResponse = await authenticationApiClient.ChangePasswordAsync(changePasswordRequest);
            changePasswordResponse.Should().Be("\"We've just sent you an email to reset your password.\"");
        }
    }
}