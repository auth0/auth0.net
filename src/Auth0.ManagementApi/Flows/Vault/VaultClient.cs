using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Flows.Vault;

public partial class VaultClient : IVaultClient
{
    private RawClient _client;

    internal VaultClient(RawClient client)
    {
        _client = client;
        Connections = new ConnectionsClient(_client);
    }

    public IConnectionsClient Connections { get; }
}
