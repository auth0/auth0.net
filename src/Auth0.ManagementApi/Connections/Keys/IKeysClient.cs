using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Connections;

public partial interface IKeysClient
{
    /// <summary>
    /// Gets the connection keys for the Okta or OIDC connection strategy.
    /// </summary>
    WithRawResponseTask<IEnumerable<ConnectionKey>> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Rotates the connection keys for the Okta or OIDC connection strategies.
    /// </summary>
    WithRawResponseTask<RotateConnectionsKeysResponseContent> RotateAsync(
        string id,
        Optional<RotateConnectionKeysRequestContent?> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
