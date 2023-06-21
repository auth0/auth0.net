using System.Threading.Tasks;
using Auth0.ManagementApi;

namespace Auth0.IntegrationTests.Shared.CleanUp
{
    public class RolesCleanUpStrategy : CleanUpStrategy
    {
        public RolesCleanUpStrategy(ManagementApiClient apiClient) : base(CleanUpType.Roles, apiClient)
        {

        }

        public override async Task Run(string id)
        {
            System.Diagnostics.Debug.WriteLine("Running RolesCleanUpStrategy");
            await ApiClient.Roles.DeleteAsync(id);
        }
    }
}