using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Client.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Auth0.AuthenticationApi.Client.IntegrationTests
{
    [TestFixture]
    public class AccessTokenTests : TestBase
    {
        [Test, Explicit]
        public async Task Can_log_in_with_access_token()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            var accessToken = await authenticationApiClient.GetAccessToken(new AccessTokenRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Connection = "google-oauth2",
                AccessToken = "your access token",
                Scope = "openid"
            });

            accessToken.Should().NotBeNull();
            accessToken.IdToken.Should().NotBeNull();
            accessToken.AccessToken.Should().NotBeNull();
            accessToken.TokenType.Should().Be("bearer");
        }
    }
}