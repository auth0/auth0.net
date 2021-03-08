using Auth0.Tests.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    public class HttpClientAuthenticationConnectionTests : TestBase
    {
        [Fact]
        public async Task Disposes_HttpClient_it_creates_on_dispose()
        {
            var connection = new HttpClientAuthenticationConnection();
            connection.Dispose();
            await Assert.ThrowsAsync<ObjectDisposedException >(() => connection.GetAsync<string>(new Uri("https://www.auth0.com")));
        }

        [Fact]
        public async Task Does_not_dispose_HttpClient_it_was_given_on_dispose()
        {
            var httpClient = new HttpClient();
            var apiConnection = new HttpClientAuthenticationConnection(httpClient);
            apiConnection.Dispose();
            await httpClient.GetAsync(new Uri("https://www.auth0.com"));
        }
    }
}
