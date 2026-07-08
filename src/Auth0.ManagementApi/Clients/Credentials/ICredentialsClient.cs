using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Clients;

public partial interface ICredentialsClient
{
    /// <summary>
    /// Get the details of a client credential.
    ///
    /// **Important**: To enable credentials to be used for a client authentication method, set the `client_authentication_methods` property on the client. To enable credentials to be used for JWT-Secured Authorization requests set the `signed_request_object` property on the client.
    /// </summary>
    WithRawResponseTask<IEnumerable<ClientCredential>> ListAsync(
        string clientId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a client credential associated to your application. Credentials can be used to configure Private Key JWT and mTLS authentication methods, as well as for JWT-secured Authorization requests.
    ///
    /// **Public Key**
    ///
    /// Public Key credentials can be used to set up Private Key JWT client authentication and JWT-secured Authorization requests.
    ///
    /// Sample:
    ///
    /// ```json
    /// {
    ///   "credential_type": "public_key",
    ///   "name": "string",
    ///   "pem": "string",
    ///   "alg": "RS256",
    ///   "parse_expiry_from_cert": false,
    ///   "expires_at": "2022-12-31T23:59:59Z"
    /// }
    /// ```
    ///
    /// **Certificate (CA-signed & self-signed)**
    ///
    /// Certificate credentials can be used to set up mTLS client authentication. CA-signed certificates can be configured either with a signed certificate or with just the certificate Subject DN.
    ///
    /// CA-signed Certificate Sample (pem):
    ///
    /// ```json
    /// {
    ///   "credential_type": "x509_cert",
    ///   "name": "string",
    ///   "pem": "string"
    /// }
    /// ```
    ///
    /// CA-signed Certificate Sample (subject_dn):
    ///
    /// ```json
    /// {
    ///   "credential_type": "cert_subject_dn",
    ///   "name": "string",
    ///   "subject_dn": "string"
    /// }
    /// ```
    ///
    /// Self-signed Certificate Sample:
    ///
    /// ```json
    /// {
    ///   "credential_type": "cert_subject_dn",
    ///   "name": "string",
    ///   "pem": "string"
    /// }
    /// ```
    ///
    /// The credential will be created but not yet enabled for use until you set the corresponding properties in the client:
    ///
    /// - To enable the credential for Private Key JWT or mTLS authentication methods, set the `client_authentication_methods` property on the client. For more information, read [Configure Private Key JWT Authentication](https://auth0.com/docs/get-started/applications/configure-private-key-jwt) and [Configure mTLS Authentication](https://auth0.com/docs/get-started/applications/configure-mtls)
    /// - To enable the credential for JWT-secured Authorization requests, set the `signed_request_object`property on the client. For more information, read [Configure JWT-secured Authorization Requests (JAR)](https://auth0.com/docs/get-started/applications/configure-jar)
    /// </summary>
    WithRawResponseTask<PostClientCredentialResponseContent> CreateAsync(
        string clientId,
        PostClientCredentialRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the details of a client credential.
    ///
    /// **Important**: To enable credentials to be used for a client authentication method, set the `client_authentication_methods` property on the client. To enable credentials to be used for JWT-Secured Authorization requests set the `signed_request_object` property on the client.
    /// </summary>
    WithRawResponseTask<GetClientCredentialResponseContent> GetAsync(
        string clientId,
        string credentialId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a client credential you previously created. May be enabled or disabled. For more information, read <see href="https://www.auth0.com/docs/get-started/authentication-and-authorization-flow/client-credentials-flow">Client Credential Flow</see>.
    /// </summary>
    WithRawResponseTask DeleteAsync(
        string clientId,
        string credentialId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Change a client credential you previously created. May be enabled or disabled. For more information, read <see href="https://www.auth0.com/docs/get-started/authentication-and-authorization-flow/client-credentials-flow">Client Credential Flow</see>.
    /// </summary>
    WithRawResponseTask<PatchClientCredentialResponseContent> UpdateAsync(
        string clientId,
        string credentialId,
        PatchClientCredentialRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
