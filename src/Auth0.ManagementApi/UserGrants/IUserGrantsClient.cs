using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial interface IUserGrantsClient
{
    /// <summary>
    /// Retrieve the <a href="https://auth0.com/docs/api-auth/which-oauth-flow-to-use">grants</a> associated with your account.
    /// </summary>
    Task<Pager<UserGrant>> ListAsync(
        ListUserGrantsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a grant associated with your account.
    /// </summary>
    Task DeleteByUserIdAsync(
        DeleteUserGrantByUserIdRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a grant associated with your account.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
