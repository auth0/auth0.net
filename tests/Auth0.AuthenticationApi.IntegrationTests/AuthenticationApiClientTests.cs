using System;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    public class AuthenticationApiClientTests
    {
        [Fact]
        public async Task Disposes_ApiConnection_it_creates_on_dispose()
        {
            var authClient = new AuthenticationApiClient("dotnet.auth0.com");
            authClient.Dispose();
            await Assert.ThrowsAsync<ObjectDisposedException>(() => authClient.StartPasswordlessSmsFlowAsync(new Models.PasswordlessSmsRequest()));
        }
    }
}
