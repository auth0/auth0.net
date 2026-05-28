using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users.EffectivePermissions.Sources;

public partial interface IRolesClient
{
    /// <summary>
    /// Lists the roles which grant the user a given permission, including roles assigned directly to the user and those inherited through group memberships.
    /// </summary>
    Task<Pager<UserEffectivePermissionRoleSourceResponseContent>> ListAsync(
        string id,
        ListUserEffectivePermissionRoleSourceRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
