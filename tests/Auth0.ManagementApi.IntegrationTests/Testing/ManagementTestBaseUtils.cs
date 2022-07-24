using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;

namespace Auth0.ManagementApi.IntegrationTests.Testing
{
    public class ManagementTestBaseUtils
    {
        public static async Task CleanupAndDisposeAsync(ManagementApiClient client, IList<CleanUpType> types = null)
        {
            await RunCleanUp(client, types);
            client.Dispose();
        }
        

        private static async Task RunCleanUp(ManagementApiClient client, IList<CleanUpType> types = null)
        {
            var strategies = new List<CleanUpStrategy>
            {
                new ActionsCleanUpStrategy(client),
                new ClientsCleanUpStrategy(client),
                new ConnectionsCleanUpStrategy(client),
                new HooksCleanUpStrategy(client),
                new OrganizationsCleanUpStrategy(client),
                new ResourceServersCleanUpStrategy(client),
                new UsersCleanUpStrategy(client),
                new RulesCleanUpStrategy(client)
            };

            var strategiesToRun = types != null ? strategies.FindAll(s => types.Contains(s.Type)) : strategies;

            foreach (var cleanUpStrategy in strategiesToRun)
            {
                await cleanUpStrategy.Run();
            }
        }
    }
}
