using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using NUnit.Framework;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    [TestFixture]
    public class AccessTokenTests : TestBase
    {
        private string accessToken = "your access token";

        [Test, Explicit]
        public async Task Can_log_in_with_access_token()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            var token = await authenticationApiClient.GetAccessToken(new AccessTokenRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Connection = "google-oauth2",
                AccessToken = accessToken,
                Scope = "openid"
            });

            token.Should().NotBeNull();
            token.IdToken.Should().NotBeNull();
            token.AccessToken.Should().NotBeNull();
        }

        [Test, Explicit]
        public async Task Can_get_delegation_token()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));
            
            // First get the access token
            var token = await authenticationApiClient.GetAccessToken(new AccessTokenRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Connection = "google-oauth2",
                AccessToken = accessToken,
                Scope = "openid"
            });

            // Then request the delegation token
            var delegationToken = await authenticationApiClient.GetDelegationToken(new IdTokenDelegationRequest(
                GetVariable("AUTH0_CLIENT_ID"),
                GetVariable("AUTH0_CLIENT_ID"),
                token.IdToken)
            {
                Scope = "openid",
                GrantType = "urn:ietf:params:oauth:grant-type:jwt-bearer",
                ApiType = "app"
            });

            delegationToken.Should().NotBeNull();
            delegationToken.IdToken.Should().NotBeNull();
        }

        [Test, Explicit]
        public async Task Can_obtain_user_info()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            // First get the access token
            var token = await authenticationApiClient.GetAccessToken(new AccessTokenRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Connection = "google-oauth2",
                AccessToken = accessToken,
                Scope = "openid"
            });


            // Get the user info
            var user = await authenticationApiClient.GetUserInfo(token.AccessToken);
            user.Should().NotBeNull();
            user.Email.Should().NotBeNull();
        }

        [Test, Explicit]
        public async Task Can_obtain_token_info()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            // First get the access token
            var token = await authenticationApiClient.GetAccessToken(new AccessTokenRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Connection = "google-oauth2",
                AccessToken = accessToken,
                Scope = "openid"
            });


            // Get the user info
            var user = await authenticationApiClient.GetTokenInfo(token.IdToken);
            user.Should().NotBeNull();
            user.Email.Should().NotBeNull();
        }

        [Test, Explicit]
        public async Task Can_exchange_authorization_code_for_access_token()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            // Exchange the authorization code
            var token = await authenticationApiClient.ExchangeCodeForAccessToken(new ExchangeCodeRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                ClientSecret = GetVariable("AUTH0_CLIENT_SECRET"),
                RedirectUri = "http://www.blah.com/test",
                AuthorizationCode = "AaBhdAOl4OKvjX2I"
            });

            // Assert
            token.Should().NotBeNull();
        }
    }
}