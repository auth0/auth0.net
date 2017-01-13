using Auth0.AuthenticationApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    [TestFixture]
    public class RefreshTokenTests : TestBase
    {
        private const string RefreshToken = "your token";

        //[Test, Explicit]
        //public async Task Can_get_refreshed_access_token()
        //{
        //    // Arrange
        //    var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

        //    // Act
        //    var authenticationResponse = await authenticationApiClient.GetRefreshedTokenAsync(new TokenRefreshRequest
        //    {
        //        ClientId = GetVariable("AUTH0_CLIENT_ID"),
        //        ClientSecret = GetVariable("AUTH0_CLIENT_SECRET"),
        //        Scope = "openid",
        //        RefreshToken = RefreshToken
        //    });

        //    // Assert
        //    authenticationResponse.Should().NotBeNull();
        //    authenticationResponse.AccessToken.Should().NotBeNull();
        //    authenticationResponse.IdToken.Should().NotBeNull();
        //}
    }
}
