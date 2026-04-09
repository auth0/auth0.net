using Auth0.ManagementApi.Clients;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial interface IClientsClient
{
    public ICredentialsClient Credentials { get; }
    public Auth0.ManagementApi.Clients.IConnectionsClient Connections { get; }

    /// <summary>
    /// Retrieve clients (applications and SSO integrations) matching provided filters. A list of fields to include or exclude may also be specified.
    /// For more information, read <see href="https://www.auth0.com/docs/get-started/applications"> Applications in Auth0</see> and <see href="https://www.auth0.com/docs/authenticate/single-sign-on"> Single Sign-On</see>.
    ///
    /// <list type="bullet">
    ///   <item><description>
    ///     The following can be retrieved with any scope:
    ///     <c>client_id</c>, <c>app_type</c>, <c>name</c>, and <c>description</c>.
    ///   </description></item>
    ///   <item><description>
    ///     The following properties can only be retrieved with the <c>read:clients</c> or
    ///     <c>read:client_keys</c> scope:
    ///     <c>callbacks</c>, <c>oidc_logout</c>, <c>allowed_origins</c>,
    ///     <c>web_origins</c>, <c>tenant</c>, <c>global</c>, <c>config_route</c>,
    ///     <c>callback_url_template</c>, <c>jwt_configuration</c>,
    ///     <c>jwt_configuration.lifetime_in_seconds</c>, <c>jwt_configuration.secret_encoded</c>,
    ///     <c>jwt_configuration.scopes</c>, <c>jwt_configuration.alg</c>, <c>api_type</c>,
    ///     <c>logo_uri</c>, <c>allowed_clients</c>, <c>owners</c>, <c>custom_login_page</c>,
    ///     <c>custom_login_page_off</c>, <c>sso</c>, <c>addons</c>, <c>form_template</c>,
    ///     <c>custom_login_page_codeview</c>, <c>resource_servers</c>, <c>client_metadata</c>,
    ///     <c>mobile</c>, <c>mobile.android</c>, <c>mobile.ios</c>, <c>allowed_logout_urls</c>,
    ///     <c>token_endpoint_auth_method</c>, <c>is_first_party</c>, <c>oidc_conformant</c>,
    ///     <c>is_token_endpoint_ip_header_trusted</c>, <c>initiate_login_uri</c>, <c>grant_types</c>,
    ///     <c>refresh_token</c>, <c>refresh_token.rotation_type</c>, <c>refresh_token.expiration_type</c>,
    ///     <c>refresh_token.leeway</c>, <c>refresh_token.token_lifetime</c>, <c>refresh_token.policies</c>, <c>organization_usage</c>,
    ///     <c>organization_require_behavior</c>.
    ///   </description></item>
    ///   <item><description>
    ///     The following properties can only be retrieved with the
    ///     <c>read:client_keys</c> or <c>read:client_credentials</c> scope:
    ///     <c>encryption_key</c>, <c>encryption_key.pub</c>, <c>encryption_key.cert</c>,
    ///     <c>client_secret</c>, <c>client_authentication_methods</c> and <c>signing_key</c>.
    ///   </description></item>
    /// </list>
    /// </summary>
    Task<Pager<Client>> ListAsync(
        ListClientsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new client (application or SSO integration). For more information, read <see href="https://www.auth0.com/docs/get-started/auth0-overview/create-applications">Create Applications</see>
    /// <see href="https://www.auth0.com/docs/authenticate/single-sign-on/api-endpoints-for-single-sign-on>"&gt;API Endpoints for Single Sign-On</see>.
    ///
    /// Notes:
    /// - We recommend leaving the `client_secret` parameter unspecified to allow the generation of a safe secret.
    /// - The <c>client_authentication_methods</c> and <c>token_endpoint_auth_method</c> properties are mutually exclusive. Use
    /// <c>client_authentication_methods</c> to configure the client with Private Key JWT authentication method. Otherwise, use <c>token_endpoint_auth_method</c>
    /// to configure the client with client secret (basic or post) or with no authentication method (none).
    /// - When using <c>client_authentication_methods</c> to configure the client with Private Key JWT authentication method, specify fully defined credentials.
    /// These credentials will be automatically enabled for Private Key JWT authentication on the client.
    /// - To configure <c>client_authentication_methods</c>, the <c>create:client_credentials</c> scope is required.
    /// - To configure <c>client_authentication_methods</c>, the property <c>jwt_configuration.alg</c> must be set to RS256.
    ///
    /// SSO Integrations created via this endpoint will accept login requests and share user profile information.
    /// </summary>
    WithRawResponseTask<CreateClientResponseContent> CreateAsync(
        CreateClientRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetches and validates a Client ID Metadata Document without creating a client.
    ///       Returns the raw metadata and how it would be mapped to Auth0 client fields.
    ///       This endpoint is useful for testing metadata URIs before creating CIMD clients.
    /// </summary>
    WithRawResponseTask<PreviewCimdMetadataResponseContent> PreviewCimdMetadataAsync(
        PreviewCimdMetadataRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Idempotent registration for Client ID Metadata Document (CIMD) clients.
    ///       Uses external_client_id as the unique identifier for upsert operations.
    ///       **Create:** Returns 201 when a new client is created (requires \
    /// </summary>
    WithRawResponseTask<RegisterCimdClientResponseContent> RegisterCimdClientAsync(
        RegisterCimdClientRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve client details by ID. Clients are SSO connections or Applications linked with your Auth0 tenant. A list of fields to include or exclude may also be specified.
    /// For more information, read <see href="https://www.auth0.com/docs/get-started/applications"> Applications in Auth0</see> and <see href="https://www.auth0.com/docs/authenticate/single-sign-on"> Single Sign-On</see>.
    /// <list type="bullet">
    ///   <item><description>
    ///     The following properties can be retrieved with any of the scopes:
    ///     <c>client_id</c>, <c>app_type</c>, <c>name</c>, and <c>description</c>.
    ///   </description></item>
    ///   <item><description>
    ///     The following properties can only be retrieved with the <c>read:clients</c> or
    ///     <c>read:client_keys</c> scopes:
    ///     <c>callbacks</c>, <c>oidc_logout</c>, <c>allowed_origins</c>,
    ///     <c>web_origins</c>, <c>tenant</c>, <c>global</c>, <c>config_route</c>,
    ///     <c>callback_url_template</c>, <c>jwt_configuration</c>,
    ///     <c>jwt_configuration.lifetime_in_seconds</c>, <c>jwt_configuration.secret_encoded</c>,
    ///     <c>jwt_configuration.scopes</c>, <c>jwt_configuration.alg</c>, <c>api_type</c>,
    ///     <c>logo_uri</c>, <c>allowed_clients</c>, <c>owners</c>, <c>custom_login_page</c>,
    ///     <c>custom_login_page_off</c>, <c>sso</c>, <c>addons</c>, <c>form_template</c>,
    ///     <c>custom_login_page_codeview</c>, <c>resource_servers</c>, <c>client_metadata</c>,
    ///     <c>mobile</c>, <c>mobile.android</c>, <c>mobile.ios</c>, <c>allowed_logout_urls</c>,
    ///     <c>token_endpoint_auth_method</c>, <c>is_first_party</c>, <c>oidc_conformant</c>,
    ///     <c>is_token_endpoint_ip_header_trusted</c>, <c>initiate_login_uri</c>, <c>grant_types</c>,
    ///     <c>refresh_token</c>, <c>refresh_token.rotation_type</c>, <c>refresh_token.expiration_type</c>,
    ///     <c>refresh_token.leeway</c>, <c>refresh_token.token_lifetime</c>, <c>refresh_token.policies</c>, <c>organization_usage</c>,
    ///     <c>organization_require_behavior</c>.
    ///   </description></item>
    ///   <item><description>
    ///     The following properties can only be retrieved with the <c>read:client_keys</c> or <c>read:client_credentials</c> scopes:
    ///     <c>encryption_key</c>, <c>encryption_key.pub</c>, <c>encryption_key.cert</c>,
    ///     <c>client_secret</c>, <c>client_authentication_methods</c> and <c>signing_key</c>.
    ///   </description></item>
    /// </list>
    /// </summary>
    WithRawResponseTask<GetClientResponseContent> GetAsync(
        string id,
        GetClientRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a client and related configuration (rules, connections, etc).
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a client's settings. For more information, read <see href="https://www.auth0.com/docs/get-started/applications"> Applications in Auth0</see> and <see href="https://www.auth0.com/docs/authenticate/single-sign-on"> Single Sign-On</see>.
    ///
    /// Notes:
    /// - The `client_secret` and `signing_key` attributes can only be updated with the `update:client_keys` scope.
    /// - The <c>client_authentication_methods</c> and <c>token_endpoint_auth_method</c> properties are mutually exclusive. Use <c>client_authentication_methods</c> to configure the client with Private Key JWT authentication method. Otherwise, use <c>token_endpoint_auth_method</c> to configure the client with client secret (basic or post) or with no authentication method (none).
    /// - When using <c>client_authentication_methods</c> to configure the client with Private Key JWT authentication method, only specify the credential IDs that were generated when creating the credentials on the client.
    /// - To configure <c>client_authentication_methods</c>, the <c>update:client_credentials</c> scope is required.
    /// - To configure <c>client_authentication_methods</c>, the property <c>jwt_configuration.alg</c> must be set to RS256.
    /// - To change a client's <c>is_first_party</c> property to <c>false</c>, the <c>organization_usage</c> and <c>organization_require_behavior</c> properties must be unset.
    /// </summary>
    WithRawResponseTask<UpdateClientResponseContent> UpdateAsync(
        string id,
        UpdateClientRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Rotate a client secret.
    ///
    /// This endpoint cannot be used with clients configured with Private Key JWT authentication method (client_authentication_methods configured with private_key_jwt). The generated secret is NOT base64 encoded.
    ///
    /// For more information, read <see href="https://www.auth0.com/docs/get-started/applications/rotate-client-secret">Rotate Client Secrets</see>.
    /// </summary>
    WithRawResponseTask<RotateClientSecretResponseContent> RotateSecretAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
