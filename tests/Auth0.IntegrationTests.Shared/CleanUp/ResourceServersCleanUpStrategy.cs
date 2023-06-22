using System;
using System.Threading.Tasks;
using Auth0.ManagementApi;

namespace Auth0.IntegrationTests.Shared.CleanUp
{
    public class ResourceServersCleanUpStrategy : CleanUpStrategy
    {
        public ResourceServersCleanUpStrategy(ManagementApiClient apiClient) : base(CleanUpType.ResourceServers, apiClient)
        {

        }

        public override async Task Run(string id)
        {
            System.Diagnostics.Debug.WriteLine("Running ResourceServersCleanUpStrategy");
            await ApiClient.ResourceServers.DeleteAsync(id);
        }
    }
}