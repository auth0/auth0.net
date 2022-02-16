using Auth0.AuthenticationApi.Models;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.IntegrationTests.Testing;
using Auth0.IntegrationTests.Shared.CleanUp;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    public class DatabaseConnectionTests : ManagementTestBase, IAsyncLifetime
    {
        private AuthenticationApiClient _authenticationApiClient;
        private Connection _connection;
        private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            ApiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));

            // We will need a connection to add the users to...
            _connection = await ApiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = $"{TestingConstants.ConnectionPrefix}-{MakeRandomName()}",
                Strategy = "auth0",
                EnabledClients = new[] {GetVariable("AUTH0_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID")}
            });

            _authenticationApiClient = new TestAuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));
        }

        public override async Task DisposeAsync()
        {
            _authenticationApiClient.Dispose();
            await CleanupAndDisposeAsync(CleanUpType.Connections);
        }

        [Fact]
        public async Task Can_signup_user_and_change_password()
        {
            // Sign up the user
            var signupUserRequest = new SignupUserRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                Password = Password,
                FamilyName = "Surname",
                GivenName = "Forename",
                Name = "Full Name",
                Nickname = "Nick",
                Picture = new Uri("https://cdn.auth0.com/styleguide/components/1.0.8/media/logos/img/badge.png"),
                Username = "A User",
                UserMetadata = new
                {
                    a = "1",
                    b = "two"
                }
            };
            var signupUserResponse = await _authenticationApiClient.SignupUserAsync(signupUserRequest);
            signupUserResponse.Should().NotBeNull();
            signupUserResponse.Id.Should().NotBeNull();
            signupUserResponse.EmailVerified.Should().BeFalse();
            signupUserResponse.Email.Should().Be(signupUserRequest.Email);
            signupUserResponse.FamilyName.Should().Be(signupUserRequest.FamilyName);
            signupUserResponse.GivenName.Should().Be(signupUserRequest.GivenName);
            signupUserResponse.Name.Should().Be(signupUserRequest.Name);
            signupUserResponse.Nickname.Should().Be(signupUserRequest.Nickname);
            signupUserResponse.Picture.Should().Be(signupUserRequest.Picture);
        }

        [Fact]
        public async Task Signup_Response_Normalizes_Id_For_RegularDb()
        {
            // Sign up the user
            var signupUserRequest = new SignupUserRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Connection = "Username-Password-Authentication",
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                Password = Password
            };
            var signupUserResponse = await _authenticationApiClient.SignupUserAsync(signupUserRequest);
            signupUserResponse.Should().NotBeNull();
            signupUserResponse.Id.Should().NotBeNull();
            signupUserResponse.Email.Should().Be(signupUserRequest.Email);
        }
    }
}