using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Tenants;

public partial class TenantsClient : ITenantsClient
{
    private readonly RawClient _client;

    internal TenantsClient(RawClient client)
    {
        _client = client;
        Settings = new SettingsClient(_client);
    }

    public ISettingsClient Settings { get; }
}
