using System.Threading.Tasks;
using Auth0.ManagementApi;

namespace Auth0.IntegrationTests.Shared.CleanUp;

public class FlowsCleanUpStrategy : CleanUpStrategy
{
    public FlowsCleanUpStrategy(ManagementClient apiClient) : base(CleanUpType.Flows, apiClient)
    {

    }

    public override async Task Run(string id)
    {
        System.Diagnostics.Debug.WriteLine("Running FlowsCleanup");
        await ApiClient.Flows.DeleteAsync(id);
    }
}