using System.Threading.Tasks;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.Tests.Shared;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class TestBaseFixture : IAsyncLifetime
    {
        public ManagementApiClient ApiClient { get; private set; }

        public virtual async Task InitializeAsync()
        {
            string token = await TestBaseUtils.GenerateManagementApiToken();

            ApiClient = new ManagementApiClient(token, TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 }));
        }

        public virtual async Task DisposeAsync()
        {
            await ManagementTestBaseUtils.CleanupAndDisposeAsync(ApiClient);
        }
    }
}
