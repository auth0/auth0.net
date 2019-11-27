using Auth0.Tests.Shared;
using System;
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
            var apiConnection = new HttpClientManagementConnection();
            apiConnection.Dispose();
            await Assert.ThrowsAsync<ObjectDisposedException >(() => apiConnection.GetAsync<string>(new Uri("https://" + GetVariable("AUTH0_MANAGEMENT_API_URL"))));
        }

        [Fact]
        public async Task Does_not_dispose_HttpClient_it_was_given_on_dispose()
        {
            var httpClient = new HttpClient();
            var apiConnection = new HttpClientManagementConnection(httpClient);
            apiConnection.Dispose();
            await apiConnection.GetAsync<string>(new Uri("https://" + GetVariable("AUTH0_MANAGEMENT_API_URL")));
        }
    }
}
