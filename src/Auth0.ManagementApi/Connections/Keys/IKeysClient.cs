using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Connections;

public partial interface IKeysClient
{
    /// <summary>
    /// Gets the connection keys for the Okta, OIDC, or SAML (samlp) connection strategy. The response includes both signing keys and encryption keys, told apart by `key_use`. Encryption keys apply only to OIDC and Okta connections.
    /// </summary>
    WithRawResponseTask<IEnumerable<ConnectionKey>> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Provision initial connection keys for Okta, OIDC, or SAML (samlp) connection strategies. This endpoint allows you to create keys before configuring the connection to use Private Key JWT authentication or encrypted ID tokens, enabling zero-downtime transitions.
    ///
    /// Set `key_use` to `signing` (default) to provision signing keys, optionally choosing `signing_alg`, or to `encryption` to provision encryption keys, optionally choosing `encryption_alg`. `signing_alg` and `encryption_alg` each apply only to their own key use. Encryption keys and encrypted ID tokens apply only to OIDC and Okta connections. The response lists all of the connection's keys.
    /// </summary>
    WithRawResponseTask<IEnumerable<PostConnectionsKeysResponseContentItem>> CreateAsync(
        string id,
        Optional<PostConnectionKeysRequestContent?> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Rotates the connection keys for the Okta, OIDC, or SAML (samlp) connection strategies.
    ///
    /// Set `key_use` to `signing` (default) to rotate the signing key, optionally choosing `signing_alg`, or to `encryption` to rotate the encryption key, optionally choosing `encryption_alg`. Rotating signing keys requires the connection to be configured to use JWT Client Authentication. Rotating encryption keys requires the connection to be configured to use encrypted ID tokens (`id_token_encrypted_response_alg` set), which applies only to OIDC and Okta connections. When `encryption_alg` is omitted, the new encryption key uses `id_token_encrypted_response_alg`.
    /// </summary>
    WithRawResponseTask<RotateConnectionsKeysResponseContent> RotateAsync(
        string id,
        Optional<RotateConnectionKeysRequestContent?> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
