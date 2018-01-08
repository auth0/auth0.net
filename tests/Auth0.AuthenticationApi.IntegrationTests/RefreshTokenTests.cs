using Auth0.Tests.Shared;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    public class RefreshTokenTests : TestBase
    {
        private const string RefreshToken = "your token";

        //[Test, Explicit]
        //public async Task Can_get_refreshed_access_token()
        //{
        //    // Arrange
        //    var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

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
