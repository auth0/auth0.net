using Auth0.Tests.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class HttpClientManagementConnectionTests : TestBase
    {
        [Fact]
        public async Task Disposes_HttpClient_it_creates_on_dispose()
        {
            var connection = new HttpClientManagementConnection();
            connection.Dispose();
            await Assert.ThrowsAsync<ObjectDisposedException>(() =>
               connection.GetAsync<string>(new Uri("https://www.auth0.com"), new Dictionary<string, string>()));
        }

        [Fact]
        public async Task Does_not_dispose_HttpClient_it_was_given_on_dispose()
        {
            var httpClient = new HttpClient();
            var connection = new HttpClientManagementConnection(httpClient);
            connection.Dispose();
            await httpClient.GetAsync(new Uri("https://www.auth0.com"));
        }
    }
}
