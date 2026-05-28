using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users.EffectivePermissions.Sources;

public partial class SourcesClient : ISourcesClient
{
    private readonly RawClient _client;

    internal SourcesClient(RawClient client)
    {
        _client = client;
        Roles = new RolesClient(_client);
    }

    public IRolesClient Roles { get; }
}
