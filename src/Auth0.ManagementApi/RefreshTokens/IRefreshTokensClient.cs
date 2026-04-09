using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial interface IRefreshTokensClient
{
    /// <summary>
    /// Retrieve a paginated list of refresh tokens for a specific user, with optional filtering by client ID. Results are sorted by credential_id ascending.
    /// </summary>
    Task<Pager<RefreshTokenResponseContent>> ListAsync(
        GetRefreshTokensRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve refresh token information.
    /// </summary>
    WithRawResponseTask<GetRefreshTokenResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a refresh token by its ID.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a refresh token by its ID.
    /// </summary>
    WithRawResponseTask<UpdateRefreshTokenResponseContent> UpdateAsync(
        string id,
        UpdateRefreshTokenRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
