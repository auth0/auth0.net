using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Models;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    public class DatabaseConnectionTests : TestBase, IAsyncLifetime
    {
        private ManagementApiClient _managementApiClient;
        private AuthenticationApiClient _authenticationApiClient;

        private Connection _connection;
        private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";
        private const string Password2 = "xuh8k},+}KNit&z.!HEE6R2N";

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            _managementApiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));

            // We will need a connection to add the users to...
            _connection = await _managementApiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = Guid.NewGuid().ToString("N"),
                Strategy = "auth0",
                EnabledClients = new[] {GetVariable("AUTH0_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID")}
            });

            _authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));
        }

        public async Task DisposeAsync()
        {
            if (_connection != null)
                await _managementApiClient.Connections.DeleteAsync(_connection.Id);
        }

        [Fact]
        public async Task Can_signup_user_and_change_password()
        {
            // Arrange
            var authenticationApiClient =
                new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            // Sign up the user
            var signupUserRequest = new SignupUserRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                Password = Password,
                UserMetadata = new
                {
                    a = "1",
                    b = "two"
                }
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
                Password = Password2
            };
            Func<Task> changePasswordFunc = async () => await authenticationApiClient.ChangePasswordAsync(changePasswordRequest);
            changePasswordFunc.Should().Throw<ApiException>().And.ApiError.Error.Should().Be("password is not allowed");
        }

        [Fact]
        public async Task Signup_Response_Normalizes_Id_For_ImportDb()
        {
            // Sign up the user
            var signupUserRequest = new SignupUserRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Connection = "integration-importdb",
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                Password = Password
            };
            var signupUserResponse = await _authenticationApiClient.SignupUserAsync(signupUserRequest);
            signupUserResponse.Should().NotBeNull();
            signupUserResponse.Id.Should().NotBeNull();
            signupUserResponse.Email.Should().Be(signupUserRequest.Email);
        }

        [Fact]
        public async Task Signup_Response_Normalizes_Id_For_RegularDb()
        {
            // Sign up the user
            var signupUserRequest = new SignupUserRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Connection = "integration-regulardb",
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                Password = Password
            };
            var signupUserResponse = await _authenticationApiClient.SignupUserAsync(signupUserRequest);
            signupUserResponse.Should().NotBeNull();
            signupUserResponse.Id.Should().NotBeNull();
            signupUserResponse.Email.Should().Be(signupUserRequest.Email);
        }

        [Fact]
        public async Task Signup_Response_Normalizes_Id_For_ExternalDb_Id()
        {
            // Sign up the user
            var signupUserRequest = new SignupUserRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Connection = "intergration-externaldb-id",
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                Password = Password
            };
            var signupUserResponse = await _authenticationApiClient.SignupUserAsync(signupUserRequest);
            signupUserResponse.Should().NotBeNull();
            signupUserResponse.Id.Should().NotBeNull();
            signupUserResponse.Email.Should().Be(signupUserRequest.Email);
        }

        [Fact]
        public async Task Signup_Response_Normalizes_Id_For_ExternalDb_User_Id()
        {
            // Sign up the user
            var signupUserRequest = new SignupUserRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Connection = "intergration-externaldb-user-id",
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                Password = Password
            };
            var signupUserResponse = await _authenticationApiClient.SignupUserAsync(signupUserRequest);
            signupUserResponse.Should().NotBeNull();
            signupUserResponse.Id.Should().NotBeNull();
            signupUserResponse.Email.Should().Be(signupUserRequest.Email);
        }
    }
}