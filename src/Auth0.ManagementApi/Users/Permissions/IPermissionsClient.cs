using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users;

public partial interface IPermissionsClient
{
    /// <summary>
    /// Retrieve all permissions associated with the user.
    ///
    /// **Note**: Returns only permissions from direct assignments and directly assigned roles. For permissions a user has via group-based role assignments, use `GET /api/v2/users/{id}/effective-permissions`.
    /// </summary>
    Task<Pager<UserPermissionSchema>> ListAsync(
        string id,
        ListUserPermissionsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Assign permissions to a user.
    /// </summary>
    WithRawResponseTask CreateAsync(
        string id,
        CreateUserPermissionsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove permissions from a user.
    /// </summary>
    WithRawResponseTask DeleteAsync(
        string id,
        DeleteUserPermissionsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
