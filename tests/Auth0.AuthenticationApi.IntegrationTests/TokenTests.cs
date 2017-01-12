using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using NUnit.Framework;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    [TestFixture]
    public class TokenTests : TestBase
    {
        [Test]
        public async Task Can_get_token_using_client_credentials()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            // Get the access token
            var token = await authenticationApiClient.GetTokenAsync(new ClientCredentialsTokenRequest
            {
                ClientId = GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID"),
                ClientSecret = GetVariable("AUTH0_MANAGEMENT_API_CLIENT_SECRET"),
                Audience = GetVariable("AUTH0_MANAGEMENT_API_AUDIENCE")
            });

            // Ensure that we received an access token back
            token.Should().NotBeNull();
        }
    }
}
