using Auth0.Core.Http;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class ApiConnectionTests
    {
        [Fact]
        public async Task Disposes_HttpClient_it_creates_on_dispose()
        {
            var apiConnection = new ApiConnection("token", "https://auth0.com");
            apiConnection.Dispose();
            await Assert.ThrowsAsync<ObjectDisposedException >(() => apiConnection.GetAsync<string>("", null, null, null, null));
        }

        [Fact]
        public async Task Does_not_dispose_HttpClient_it_was_given_on_dispose()
        {
            var httpClient = new HttpClient();
            var apiConnection = new ApiConnection("token", "https://auth0.com", httpClient);
            apiConnection.Dispose();
            await apiConnection.GetAsync<string>("", null, null, null, null);
        }
        
        [Fact]
        public void Does_not_add_default_HttpHeader_if_HttpClient_already_has_it()
        {
            var httpClient = new HttpClient();

            // create multiple ApiConnections
            var apiConnection1 = new ApiConnection("token", "https://auth0.com", httpClient);
            var apiConnection2 = new ApiConnection("token", "https://auth0.com", httpClient);

            var headerValues = httpClient.DefaultRequestHeaders.GetValues("Auth0-Client");

            // ensure HttpClient has only one value in Auth0-Client header
            headerValues.Count().Should().Be(1);
        }
    }
}
