using System;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom.Html;
using AngleSharp.Extensions;
using Auth0.AuthenticationApi.Models;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    public class AuthenticationTests : TestBase, IAsyncLifetime
    {
        private ManagementApiClient _managementApiClient;
        private Connection _connection;
        private User _user;
        private User _plusUser;
        private User _userInDefaultDirectory;
        private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            _managementApiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));

            var tenantSettings = await _managementApiClient.TenantSettings.GetAsync();

            if (string.IsNullOrEmpty(tenantSettings.DefaultDirectory))
            {
                throw new Exception("Tests require a tenant with a Default Directory selected.\r\n" +
                    "Enable OAuth 2.0 API Authorization under Account Settings | General and "+
                    "select a Default Directory under Account Settings | General");
            }
            
            // We will need a connection to add the users to...
            _connection = await _managementApiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = Guid.NewGuid().ToString("N"),
                Strategy = "auth0",
                EnabledClients = new []{ GetVariable("AUTH0_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
            });

            // And add a dummy user to test against
            _user = await _managementApiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid().ToString("N")}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            });

            // Add a user with a + in the username
            _plusUser = await _managementApiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid().ToString("N")}+1@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            });

            // Add a user with a + in the username
            _userInDefaultDirectory = await _managementApiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = tenantSettings.DefaultDirectory,
                Email = $"{Guid.NewGuid().ToString("N")}+1@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            });
        }

        public async Task DisposeAsync()
        {
            if (_user != null)
                await _managementApiClient.Users.DeleteAsync(_user.UserId);

            if (_userInDefaultDirectory != null)
                await _managementApiClient.Users.DeleteAsync(_userInDefaultDirectory.UserId);

            if (_plusUser != null)
                await _managementApiClient.Users.DeleteAsync(_plusUser.UserId);

            if (_connection != null)
                await _managementApiClient.Connections.DeleteAsync(_connection.Id);
        }

        [Fact]
        public async Task Can_authenticate_against_Auth0()
        {
            // Arrange
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            // Act
            var authenticationResponse = await authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                ClientSecret = GetVariable("AUTH0_CLIENT_SECRET"),
                Realm = _connection.Name,
                Scope = "openid",
                Username = _user.Email,
                Password = Password
                
            });

            // Assert
            authenticationResponse.Should().NotBeNull();
            authenticationResponse.TokenType.Should().NotBeNull();
            authenticationResponse.AccessToken.Should().NotBeNull();
            authenticationResponse.IdToken.Should().NotBeNull();
            authenticationResponse.RefreshToken.Should().BeNull(); // No refresh token if offline access was not requested
        }

        [Fact]
        public async Task Can_authenticate_to_default_directory()
        {
            // Arrange
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            // Act
            var authenticationResponse = await authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                ClientSecret = GetVariable("AUTH0_CLIENT_SECRET"),
                Scope = "openid",
                Username = _userInDefaultDirectory.Email,
                Password = Password

            });

            // Assert
            authenticationResponse.Should().NotBeNull();
            authenticationResponse.TokenType.Should().NotBeNull();
            authenticationResponse.AccessToken.Should().NotBeNull();
            authenticationResponse.IdToken.Should().NotBeNull();
            authenticationResponse.RefreshToken.Should().BeNull(); // No refresh token if offline access was not requested
        }

        [Fact(Skip = "Need to look into offline_access")]
        public async Task Can_request_offline_access()
        {
            // Arrange
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            // Act
            var authenticationResponse = await authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                ClientSecret = GetVariable("AUTH0_CLIENT_SECRET"),
                Realm = _connection.Name,
                Scope = "openid offline_access",
                Username = _user.Email,
                Password = Password
            });

            // Assert
            authenticationResponse.Should().NotBeNull();
            authenticationResponse.TokenType.Should().NotBeNull();
            authenticationResponse.AccessToken.Should().NotBeNull();
            authenticationResponse.IdToken.Should().NotBeNull();
            authenticationResponse.RefreshToken.Should().NotBeNull(); // Requested offline access, so we should get a refresh token
        }

        [Fact]
        public async Task Can_authenticate_user_with_plus_in_username()
        {
            // Arrange
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            // Act
            var authenticationResponse = await authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                ClientSecret = GetVariable("AUTH0_CLIENT_SECRET"),
                Realm = _connection.Name,
                Scope = "openid",
                Username = _plusUser.Email,
                Password = Password
            });

            // Assert
            authenticationResponse.Should().NotBeNull();
            authenticationResponse.TokenType.Should().NotBeNull();
            authenticationResponse.AccessToken.Should().NotBeNull();
            authenticationResponse.IdToken.Should().NotBeNull();
        }
    }
}