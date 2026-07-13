using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Groups;

public partial interface IRolesClient
{
    /// <summary>
    /// Lists the [roles](https://auth0.com/docs/manage-users/access-control/rbac) assigned to a group.
    /// </summary>
    Task<Pager<Role>> ListAsync(
        string id,
        ListGroupRolesRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Assign one or more [roles](https://auth0.com/docs/manage-users/access-control/rbac) to a specified group.
    /// </summary>
    WithRawResponseTask CreateAsync(
        string id,
        CreateGroupRolesRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Unassign one or more [roles](https://auth0.com/docs/manage-users/access-control/rbac) from a specified group.
    /// </summary>
    WithRawResponseTask DeleteAsync(
        string id,
        DeleteGroupRolesRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
