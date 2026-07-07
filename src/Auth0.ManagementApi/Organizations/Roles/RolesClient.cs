using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations.Roles;

public partial class RolesClient : IRolesClient
{
    private readonly RawClient _client;

    internal RolesClient(RawClient client)
    {
        _client = client;
        Members = new MembersClient(_client);
    }

    public IMembersClient Members { get; }
}
