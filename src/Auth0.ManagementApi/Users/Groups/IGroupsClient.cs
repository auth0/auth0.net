using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users;

public partial interface IGroupsClient
{
    /// <summary>
    /// List all groups to which this user belongs.
    /// </summary>
    Task<Pager<UserGroupsResponseSchema>> GetAsync(
        string id,
        GetUserGroupsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
