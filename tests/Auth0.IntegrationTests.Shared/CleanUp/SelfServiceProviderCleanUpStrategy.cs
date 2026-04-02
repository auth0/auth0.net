using System.Threading.Tasks;
using Auth0.ManagementApi;

namespace Auth0.IntegrationTests.Shared.CleanUp;

public class SelfServiceProviderCleanUpStrategy : CleanUpStrategy
{
    public SelfServiceProviderCleanUpStrategy(ManagementClient apiClient) : base(CleanUpType.SelfServiceProvider, apiClient)
    {
            
    }

    public override async Task Run(string id)
    {
        System.Diagnostics.Debug.WriteLine("Running SelfServiceProviderCleanup");
        await ApiClient.SelfServiceProfiles.DeleteAsync(id);
    }
}