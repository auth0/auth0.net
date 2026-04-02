using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Connections;

public partial interface IUsersClient
{
    /// <summary>
    /// Deletes a specified connection user by its email (you cannot delete all users from specific connection). Currently, only Database Connections are supported.
    /// </summary>
    Task DeleteByEmailAsync(
        string id,
        DeleteConnectionUsersByEmailQueryParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
