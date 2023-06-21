using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests.Testing
{
    public class ManagementTestBase : TestBase
    {
        protected ManagementApiClient ApiClient;

        public virtual Task DisposeAsync()
        {
            if (ApiClient != null)
            {
                ApiClient.Dispose();
            }

            return Task.CompletedTask;
        }
    }
}
