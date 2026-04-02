using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Roles;

public partial interface IPermissionsClient
{
    /// <summary>
    /// Retrieve detailed list (name, description, resource server) of permissions granted by a specified user role.
    /// </summary>
    Task<Pager<PermissionsResponsePayload>> ListAsync(
        string id,
        ListRolePermissionsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Add one or more <see href="https://auth0.com/docs/manage-users/access-control/configure-core-rbac/manage-permissions">permissions</see> to a specified user role.
    /// </summary>
    Task AddAsync(
        string id,
        AddRolePermissionsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove one or more <see href="https://auth0.com/docs/manage-users/access-control/configure-core-rbac/manage-permissions">permissions</see> from a specified user role.
    /// </summary>
    Task DeleteAsync(
        string id,
        DeleteRolePermissionsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
