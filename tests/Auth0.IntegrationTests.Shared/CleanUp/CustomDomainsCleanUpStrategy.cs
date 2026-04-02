using System.Threading.Tasks;
using Auth0.ManagementApi;

namespace Auth0.IntegrationTests.Shared.CleanUp;

public class CustomDomainsCleanUpStrategy(ManagementClient apiClient)
    : CleanUpStrategy(CleanUpType.CustomDomains, apiClient)
{
    public override async Task Run(string id)
    {
        System.Diagnostics.Debug.WriteLine("Running CustomDomainsCleanUpStrategy");
        await ApiClient.CustomDomains.DeleteAsync(id);
    }
}