namespace Auth0.ManagementApi.Flows.Vault;

public partial interface IVaultClient
{
    public IConnectionsClient Connections { get; }
}
