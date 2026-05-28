using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users.EffectiveRoles.Sources;

public partial class SourcesClient : ISourcesClient
{
    private readonly RawClient _client;

    internal SourcesClient(RawClient client)
    {
        _client = client;
        Groups = new GroupsClient(_client);
    }

    public IGroupsClient Groups { get; }
}
