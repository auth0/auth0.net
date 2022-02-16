using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests.Testing
{
    public class ManagementTestBase : TestBase
    {
        protected ManagementApiClient ApiClient;
        
        public async Task CleanupAndDisposeAsync(CleanUpType? type = null)
        {
            if (ApiClient != null)
            {
                await RunCleanUp(type);
                ApiClient.Dispose();
            }
        }

        public virtual Task DisposeAsync()
        {
            if (ApiClient != null)
            {
                ApiClient.Dispose();
            }

            return Task.CompletedTask;
        }

        private async Task RunCleanUp(CleanUpType? type)
        {
            var strategies = new List<CleanUpStrategy>
            {
                new ActionsCleanUpStrategy(ApiClient),
                new ClientsCleanUpStrategy(ApiClient),
                new ConnectionsCleanUpStrategy(ApiClient),
                new HooksCleanUpStrategy(ApiClient),
                new OrganizationsCleanUpStrategy(ApiClient),
                new ResourceServersCleanUpStrategy(ApiClient),
                new UsersCleanUpStrategy(ApiClient)
            };

            var strategiesToRun = type != null ? strategies.FindAll(s => s.Type == type) : strategies;

            foreach (var cleanUpStrategy in strategiesToRun)
            {
                await cleanUpStrategy.Run();
            }
        }
    }
}
