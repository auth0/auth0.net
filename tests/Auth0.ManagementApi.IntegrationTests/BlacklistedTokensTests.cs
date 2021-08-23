using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class BlacklistedTokensTests : TestBase
    {
        //[Test]
        //[Ignore("Ignore for now until I can figure out reason for intermittent failure")]
        //public async Task Test_blacklist_sequence()
        //{
        //    string apiKey = GetVariable("AUTH0_API_KEY");

        //    var apiClient = new ManagementApiClient(GetVariable("AUTH0_TOKEN_BLACKLISTED_TOKENS"), GetVariable("AUTH0_MANAGEMENT_API_URL"));

        //    // Get all the blacklisted tokens
        //    var tokensBefore = await apiClient.BlacklistedTokens.GetAllAsync(apiKey);

        //    // Generate a token which allows us to list all clients
        //    var scopes = new
        //    {
        //        clients = new
        //        {
        //            actions = new string[] { "read" }
        //        }
        //    };
        //    string jti = Guid.NewGuid().ToString("N");
        //    string token = GenerateToken(scopes, jti);

        //    // Confirm that the token is working
        //    var confirmationApiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));
        //    var clients = await confirmationApiClient.Clients.GetAllAsync();
        //    clients.Should().NotBeNull();

        //    // Now blacklist that new token
        //    var blacklistRequest = new BlacklistedTokenCreateRequest
        //    {
        //        Aud = apiKey,
        //        Jti = jti
        //    };
        //    await apiClient.BlacklistedTokens.CreateAsync(blacklistRequest);

        //    // Get all the blacklisted tokens and check that we have one more
        //    var tokensAfter = await apiClient.BlacklistedTokens.GetAllAsync(apiKey);
        //    tokensAfter.Count.Should().Be(tokensBefore.Count + 1);

        //    // Try and get all the clients again with that token
        //    Func<Task> getFunc = async () => await confirmationApiClient.Clients.GetAllAsync();
        //    getFunc.ShouldThrow<ApiException>().And.ApiError.StatusCode.Should().Be(401);
        //}
    }
}