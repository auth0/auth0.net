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

        public override async Task Run()
        {
            System.Diagnostics.Debug.WriteLine("Running ResourceServersCleanUpStrategy");
            var resourceServers = await ApiClient.ResourceServers.GetAllAsync(new ManagementApi.Paging.PaginationInfo(0, 100));

            foreach (var resourceServer in resourceServers)
            {
                if (resourceServer.Name.StartsWith(TestingConstants.ResourceServerPrefix))
                {
                    Console.WriteLine($"Removing resourceServer {resourceServer.Name}");
                    await ApiClient.ResourceServers.DeleteAsync(resourceServer.Id);
                }
            }
        }
    }
}