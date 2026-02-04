using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users;

public partial interface ISessionsClient
{
    /// <summary>
    /// Retrieve details for a user's sessions.
    /// </summary>
    Task<Pager<SessionResponseContent>> ListAsync(
        string userId,
        ListUserSessionsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete all sessions for a user.
    /// </summary>
    Task DeleteAsync(
        string userId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
