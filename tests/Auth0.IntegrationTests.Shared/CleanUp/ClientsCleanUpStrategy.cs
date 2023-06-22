using System;
using System.Threading.Tasks;
using Auth0.ManagementApi;

namespace Auth0.IntegrationTests.Shared.CleanUp
{
    public class ClientsCleanUpStrategy : CleanUpStrategy
    {
        public ClientsCleanUpStrategy(ManagementApiClient apiClient) : base(CleanUpType.Clients, apiClient)
        {

        }

        public override async Task Run(string id)
        {
            System.Diagnostics.Debug.WriteLine("Running ClientsCleanUpStrategy");
            await ApiClient.Clients.DeleteAsync(id);
        }
    }
}