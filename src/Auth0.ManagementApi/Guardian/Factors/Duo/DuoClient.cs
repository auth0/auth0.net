using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Guardian.Factors.Duo;

public partial class DuoClient : IDuoClient
{
    private readonly RawClient _client;

    internal DuoClient(RawClient client)
    {
        _client = client;
        Settings = new SettingsClient(_client);
    }

    public ISettingsClient Settings { get; }
}
