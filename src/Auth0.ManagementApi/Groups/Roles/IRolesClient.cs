using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Groups;

public partial interface IRolesClient
{
    /// <summary>
    /// Lists the <see href="https://auth0.com/docs/manage-users/access-control/rbac">roles</see> assigned to a group.
    /// </summary>
    Task<Pager<Role>> ListAsync(
        string id,
        ListGroupRolesRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Assign one or more <see href="https://auth0.com/docs/manage-users/access-control/rbac">roles</see> to a specified group.
    /// </summary>
    Task CreateAsync(
        string id,
        CreateGroupRolesRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Unassign one or more <see href="https://auth0.com/docs/manage-users/access-control/rbac">roles</see> from a specified group.
    /// </summary>
    Task DeleteAsync(
        string id,
        DeleteGroupRolesRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
