using System.Threading.Tasks;
using Auth0.ManagementApi;

namespace Auth0.IntegrationTests.Shared.CleanUp
{
    public class ClientGrantsCleanUpStrategy : CleanUpStrategy
    {
        public ClientGrantsCleanUpStrategy(ManagementApiClient apiClient) : base(CleanUpType.ClientGrants, apiClient)
        {

        }

        public override async Task Run(string id)
        {
            System.Diagnostics.Debug.WriteLine("Running ClientGrantsCleanUpStrategy");
            await ApiClient.ClientGrants.DeleteAsync(id);
        }
    }
}