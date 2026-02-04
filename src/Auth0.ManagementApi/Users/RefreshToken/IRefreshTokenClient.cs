using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users;

public partial interface IRefreshTokenClient
{
    /// <summary>
    /// Retrieve details for a user's refresh tokens.
    /// </summary>
    Task<Pager<RefreshTokenResponseContent>> ListAsync(
        string userId,
        ListRefreshTokensRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete all refresh tokens for a user.
    /// </summary>
    Task DeleteAsync(
        string userId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
