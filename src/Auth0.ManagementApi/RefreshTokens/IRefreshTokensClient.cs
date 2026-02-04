namespace Auth0.ManagementApi;

public partial interface IRefreshTokensClient
{
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
}
