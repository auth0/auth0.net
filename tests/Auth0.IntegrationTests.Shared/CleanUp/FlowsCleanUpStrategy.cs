using System.Threading.Tasks;
using Auth0.ManagementApi;

namespace Auth0.IntegrationTests.Shared.CleanUp
{
    public class FlowsCleanUpStrategy : CleanUpStrategy
    {
        public FlowsCleanUpStrategy(ManagementApiClient apiClient) : base(CleanUpType.Flows, apiClient)
        {

        }

        public override async Task Run(string id)
        {
            System.Diagnostics.Debug.WriteLine("Running FlowsCleanup");
            await ApiClient.FlowsClient.DeleteAsync(id);
        }
    }
}