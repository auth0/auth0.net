using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class ApiConnectionTests
    {
        [Fact]
        public async Task Disposes_HttpClient_it_creates_on_dispose()
        {
            var apiConnection = new HttpClientManagementConnection();
            apiConnection.Dispose();
            await Assert.ThrowsAsync<ObjectDisposedException >(() => apiConnection.GetAsync<string>(new Uri("/")));
        }

        [Fact]
        public async Task Does_not_dispose_HttpClient_it_was_given_on_dispose()
        {
            var httpClient = new HttpClient();
            var apiConnection = new HttpClientManagementConnection(httpClient);
            apiConnection.Dispose();
            await apiConnection.GetAsync<string>(new Uri("/"));
        }
    }
}
