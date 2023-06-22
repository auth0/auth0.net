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
using System.Collections.Generic;
using System.Data.Common;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    public class AccessTokenTestsFixture : TestBaseFixture
    {
        public AuthenticationApiClient AuthenticationApiClient;

        public Connection Connection;
        public User NewUser;
        public string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            AuthenticationApiClient = new TestAuthenticationApiClient(TestBaseUtils.GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            // We will need a connection to add the users to...
            Connection = await ApiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}",
                Strategy = "auth0",
                EnabledClients = new[] { TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
            });

            TrackIdentifier(CleanUpType.Connections, Connection.Id);

            // Add a new user
            var newUserRequest = new UserCreateRequest
            {
                Connection = Connection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            };

            NewUser = await ApiClient.Users.CreateAsync(newUserRequest);

            TrackIdentifier(CleanUpType.Users, NewUser.UserId);
        }

        public override async Task DisposeAsync()
        {
            foreach (KeyValuePair<CleanUpType, IList<string>> entry in identifiers)
            {
                await ManagementTestBaseUtils.CleanupAsync(ApiClient, entry.Key, entry.Value);
            }

            AuthenticationApiClient.Dispose();
            ApiClient.Dispose();
        }
    }

    public class AccessTokenTests : IClassFixture<AccessTokenTestsFixture>
    {
        AccessTokenTestsFixture fixture;

        public AccessTokenTests(AccessTokenTestsFixture fixture)
        {
            this.fixture = fixture;
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
            var token = await fixture.AuthenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
            {
                ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
                ClientSecret = TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET"),
                Realm = fixture.Connection.Name,
                Username = fixture.NewUser.Email,
                Password = fixture.Password,
                Scope = "openid profile"
            });

            // Get the user info
            var user = await fixture.AuthenticationApiClient.GetUserInfoAsync(token.AccessToken);
            user.Should().NotBeNull();
            user.UserId.Should().NotBeNull();
        }

        [Fact(Skip = "Run manually")]
        public async Task Can_exchange_authorization_code_for_access_token()
        {
            var authenticationApiClient = new TestAuthenticationApiClient(TestBaseUtils.GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            // Exchange the authorization code
            var token = await authenticationApiClient.GetTokenAsync(new AuthorizationCodeTokenRequest
            {
                ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
                ClientSecret = TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET"),
                RedirectUri = "http://www.blah.com/test",
                Code= "AaBhdAOl4OKvjX2I"
            });

            // Assert
            token.Should().NotBeNull();
        }

    }
}