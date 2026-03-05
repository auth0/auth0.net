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
    /// Provision initial connection keys for Okta or OIDC connection strategies. This endpoint allows you to create keys before configuring the connection to use Private Key JWT authentication, enabling zero-downtime transitions.
    /// </summary>
    WithRawResponseTask<IEnumerable<PostConnectionsKeysResponseContentItem>> CreateAsync(
        string id,
        Optional<PostConnectionKeysRequestContent?> request,
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
