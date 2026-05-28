using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users.EffectiveRoles.Sources;

public partial interface IGroupsClient
{
    /// <summary>
    /// Lists the groups that grant a user a specific role.
    /// </summary>
    Task<Pager<Group>> ListAsync(
        string id,
        ListUserRoleSourceGroupsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
