using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Anomaly;

public partial class AnomalyClient : IAnomalyClient
{
    private readonly RawClient _client;

    internal AnomalyClient(RawClient client)
    {
        _client = client;
        Blocks = new BlocksClient(_client);
    }

    public IBlocksClient Blocks { get; }
}
