using System.Threading.Tasks;
using Auth0.ManagementApi;

namespace Auth0.IntegrationTests.Shared.CleanUp
{
    public class LogStreamsCleanUpStrategy : CleanUpStrategy
    {
        public LogStreamsCleanUpStrategy(ManagementApiClient apiClient) : base(CleanUpType.LogStreams, apiClient)
        {

        }

        public override Task Run()
        {
            // Not supported
            return Task.CompletedTask;
        }

        public override async Task Run(string id)
        {
            System.Diagnostics.Debug.WriteLine("Running LogStreamsCleanUpStrategy");
            await ApiClient.LogStreams.DeleteAsync(id);
        }
    }
}