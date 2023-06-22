using System.Threading.Tasks;
using Auth0.ManagementApi;

namespace Auth0.IntegrationTests.Shared.CleanUp
{
    public abstract class CleanUpStrategy
    {
        public ManagementApiClient ApiClient { get; }
        public CleanUpType Type { get; }

        protected CleanUpStrategy(CleanUpType type, ManagementApiClient apiClient)
        {
            Type = type;
            ApiClient = apiClient;
        }

        public abstract Task Run(string id);
    }
}