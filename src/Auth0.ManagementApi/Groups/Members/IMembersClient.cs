using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Groups;

public partial interface IMembersClient
{
    /// <summary>
    /// List all users that are a member of this group.
    /// </summary>
    Task<Pager<GroupMember>> GetAsync(
        string id,
        GetGroupMembersRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
