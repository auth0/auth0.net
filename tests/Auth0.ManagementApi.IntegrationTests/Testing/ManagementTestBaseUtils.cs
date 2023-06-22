using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;

namespace Auth0.ManagementApi.IntegrationTests.Testing
{
    public class ManagementTestBaseUtils
    {
        public static async Task CleanupAsync(ManagementApiClient client, CleanUpType type, IList<string> identifiers)
        {
            var strategies = new List<CleanUpStrategy>
            {
                new ActionsCleanUpStrategy(client),
                new ClientGrantsCleanUpStrategy(client),
                new ClientsCleanUpStrategy(client),
                new ConnectionsCleanUpStrategy(client),
                new HooksCleanUpStrategy(client),
                new OrganizationsCleanUpStrategy(client),
                new ResourceServersCleanUpStrategy(client),
                new UsersCleanUpStrategy(client),
                new RulesCleanUpStrategy(client),
                new LogStreamsCleanUpStrategy(client),
                new RolesCleanUpStrategy(client)
            };

            var cleanUpStrategy = strategies.Single(s => s.Type == type);

            foreach (var identifier in identifiers)
            {
                await cleanUpStrategy.Run(identifier);
            }
        }
    }
}
