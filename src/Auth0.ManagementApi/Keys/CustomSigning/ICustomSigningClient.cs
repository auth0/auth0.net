using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Keys;

public partial interface ICustomSigningClient
{
    /// <summary>
    /// Get entire jwks representation of custom signing keys.
    /// </summary>
    WithRawResponseTask<GetCustomSigningKeysResponseContent> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create or replace entire jwks representation of custom signing keys.
    /// </summary>
    WithRawResponseTask<SetCustomSigningKeysResponseContent> SetAsync(
        SetCustomSigningKeysRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete entire jwks representation of custom signing keys.
    /// </summary>
    Task DeleteAsync(RequestOptions? options = null, CancellationToken cancellationToken = default);
}
