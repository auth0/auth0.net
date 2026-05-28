using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users;

public partial interface IEffectivePermissionsClient
{
    public Auth0.ManagementApi.Users.EffectivePermissions.Sources.ISourcesClient Sources { get; }

    /// <summary>
    /// Returns the list of effective permissions for a user, taking into account permissions granted directly to the user, as well as those inherited through roles and group memberships.
    /// </summary>
    Task<Pager<UserEffectivePermissionResponseContent>> ListAsync(
        string id,
        ListUserEffectivePermissionsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
