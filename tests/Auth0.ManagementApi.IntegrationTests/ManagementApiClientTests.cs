using System;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class ManagementApiClientTests
    {
        [Fact]
        public async Task Disposes_ApiConnection_it_creates_on_dispose()
        {
            var management = new ManagementApiClient("token", "test");
            management.Dispose();
            await Assert.ThrowsAsync<ObjectDisposedException>(() => management.Clients.GetAsync("1"));
        }
    }
}
