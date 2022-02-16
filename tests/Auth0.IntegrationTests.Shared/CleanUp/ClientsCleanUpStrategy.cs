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

        public override async Task Run()
        {
            System.Diagnostics.Debug.WriteLine("Running ClientsCleanUpStrategy");
            var clients = await ApiClient.Clients.GetAllAsync(new ManagementApi.Models.GetClientsRequest { }, new ManagementApi.Paging.PaginationInfo(0, 100));

            foreach (var client in clients)
            {
                if (client.Name.StartsWith(TestingConstants.ClientPrefix))
                {
                    Console.WriteLine($"Removing client {client.Name}");
                    await ApiClient.Clients.DeleteAsync(client.ClientId);
                }
            }
        }
    }
}