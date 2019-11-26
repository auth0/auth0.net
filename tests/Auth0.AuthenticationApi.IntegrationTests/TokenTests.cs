using Auth0.AuthenticationApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    public class TokenTests : TestBase
    {
        [Fact]
        public async Task Can_get_token_using_client_credentials()
        {
            using (var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL")))
            {
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
}
