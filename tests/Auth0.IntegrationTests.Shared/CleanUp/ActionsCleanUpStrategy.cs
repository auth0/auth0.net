using System.Threading.Tasks;
using Auth0.ManagementApi;

namespace Auth0.IntegrationTests.Shared.CleanUp;

public class ActionsCleanUpStrategy: CleanUpStrategy
{
    public ActionsCleanUpStrategy(ManagementApiClient apiClient) : base(CleanUpType.Actions, apiClient)
    {
                
    }

    public override async Task Run(string id)
    {
        System.Diagnostics.Debug.WriteLine("Running ActionsCleanUpStrategy");
        await ApiClient.Actions.DeleteAsync(id);
    }
}