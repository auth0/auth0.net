using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users;

public partial interface IPermissionsClient
{
    /// <summary>
    /// Retrieve all permissions associated with the user.
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
    Task CreateAsync(
        string id,
        CreateUserPermissionsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove permissions from a user.
    /// </summary>
    Task DeleteAsync(
        string id,
        DeleteUserPermissionsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
