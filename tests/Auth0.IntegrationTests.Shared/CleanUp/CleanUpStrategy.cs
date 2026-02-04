using System.Threading.Tasks;
using Auth0.ManagementApi;

namespace Auth0.IntegrationTests.Shared.CleanUp;

public abstract class CleanUpStrategy
{
    public ManagementClient ApiClient { get; }
    public CleanUpType Type { get; }

    protected CleanUpStrategy(CleanUpType type, ManagementClient apiClient)
    {
        Type = type;
        ApiClient = apiClient;
    }

    public abstract Task Run(string id);
}