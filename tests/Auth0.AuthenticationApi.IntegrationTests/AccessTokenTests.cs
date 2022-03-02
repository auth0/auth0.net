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
    public class AccessTokenTests : ManagementTestBase, IAsyncLifetime
    {
        private AuthenticationApiClient _authenticationApiClient;
        private Connection _connection;
        private User _newUser;
        private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            ApiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 }));

            // We will need a connection to add the users to...
            _connection = await ApiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = $"{TestingConstants.ConnectionPrefix}-{MakeRandomName()}",
                Strategy = "auth0",
                EnabledClients = new[] { GetVariable("AUTH0_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
            });

            // Add a new user
            var newUserRequest = new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            };

            _newUser = await ApiClient.Users.CreateAsync(newUserRequest);

            _authenticationApiClient = new TestAuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));
        }

        public override async Task DisposeAsync()
        {
            _authenticationApiClient.Dispose();

            await CleanupAndDisposeAsync(CleanUpType.Connections);
            await CleanupAndDisposeAsync(CleanUpType.Users);
        }

        //[Test, Explicit]
        //public async Task Can_get_delegation_token()
        //{
        //    var authenticationApiClient = new TestAuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

        //    // First get the access token
        //    var token = await authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
        //    {
        //        ClientId = GetVariable("AUTH0_CLIENT_ID"),
        //        ClientSecret = GetVariable("AUTH0_CLIENT_SECRET"),
        //        Realm = connection.Name,
        //        Username = newUser.Email,
        //        Password = "password",
        //        Scope = "openid"
        //    });

        //    // Then request the delegation token
        //    var delegationToken = await authenticationApiClient.GetDelegationTokenAsync(new IdTokenDelegationRequest(
        //        GetVariable("AUTH0_CLIENT_ID"),
        //        GetVariable("AUTH0_CLIENT_ID"),
        //        token.IdToken)
        //    {
        //        Scope = "openid",
        //        GrantType = "urn:ietf:params:oauth:grant-type:jwt-bearer",
        //        ApiType = "app"
        //    });

        //    delegationToken.Should().NotBeNull();
        //    delegationToken.IdToken.Should().NotBeNull();
        //}

        [Fact]
        public async Task Can_obtain_user_info()
        {
            // First get the access token
            var token = await _authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                ClientSecret = GetVariable("AUTH0_CLIENT_SECRET"),
                Realm = _connection.Name,
                Username = _newUser.Email,
                Password = Password,
                Scope = "openid profile"
            });

            // Get the user info
            var user = await _authenticationApiClient.GetUserInfoAsync(token.AccessToken);
            user.Should().NotBeNull();
            user.UserId.Should().NotBeNull();
        }

        [Fact(Skip = "Run manually")]
        public async Task Can_exchange_authorization_code_for_access_token()
        {
            var authenticationApiClient = new TestAuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            // Exchange the authorization code
            var token = await authenticationApiClient.GetTokenAsync(new AuthorizationCodeTokenRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                ClientSecret = GetVariable("AUTH0_CLIENT_SECRET"),
                RedirectUri = "http://www.blah.com/test",
                Code= "AaBhdAOl4OKvjX2I"
            });

            // Assert
            token.Should().NotBeNull();
        }

    }
}