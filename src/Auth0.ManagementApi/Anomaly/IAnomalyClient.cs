namespace Auth0.ManagementApi.Anomaly;

public partial interface IAnomalyClient
{
    public IBlocksClient Blocks { get; }
}
