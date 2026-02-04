using System.Threading.Tasks;
using Auth0.ManagementApi;

namespace Auth0.IntegrationTests.Shared.CleanUp;

public class FormsCleanUpStrategy : CleanUpStrategy
{
    public FormsCleanUpStrategy(ManagementClient apiClient) : base(CleanUpType.Forms, apiClient)
    {

    }

    public override async Task Run(string id)
    {
        System.Diagnostics.Debug.WriteLine("Running FormsCleanup");
        await ApiClient.Forms.DeleteAsync(id);
    }
}