using System.Threading.Tasks;
using Auth0.ManagementApi;

namespace Auth0.IntegrationTests.Shared.CleanUp
{
    public class ConnectionsCleanUpStrategy : CleanUpStrategy
    {
        public ConnectionsCleanUpStrategy(ManagementApiClient apiClient) : base(CleanUpType.Connections, apiClient)
        {

        }

        public override async Task Run(string id)
        {
            System.Diagnostics.Debug.WriteLine("Running ConnectionsCleanUpStrategy");
            var connections = await ApiClient.Connections.GetAllAsync(new ManagementApi.Models.GetConnectionsRequest { });
            await ApiClient.Connections.DeleteAsync(id);        
        }
    }
}