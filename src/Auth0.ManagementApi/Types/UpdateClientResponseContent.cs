using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateClientResponseContent : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// ID of this client.
    /// </summary>
    [Optional]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    /// <summary>
    /// Name of the tenant this client belongs to.
    /// </summary>
    [Optional]
    [JsonPropertyName("tenant")]
    public string? Tenant { get; set; }

    /// <summary>
    /// Name of this client (min length: 1 character, does not allow `&lt;` or `&gt;`).
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Free text description of this client (max length: 140 characters).
    /// </summary>
    [Optional]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Whether this is your global 'All Applications' client representing legacy tenant settings (true) or a regular client (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("global")]
    public bool? Global { get; set; }

    /// <summary>
    /// Client secret (which you must not make public).
    /// </summary>
    [Optional]
    [JsonPropertyName("client_secret")]
    public string? ClientSecret { get; set; }

    [Optional]
    [JsonPropertyName("app_type")]
    public ClientAppTypeEnum? AppType { get; set; }

    /// <summary>
    /// URL of the logo to display for this client. Recommended size is 150x150 pixels.
    /// </summary>
    [Optional]
    [JsonPropertyName("logo_uri")]
    public string? LogoUri { get; set; }

    /// <summary>
    /// Whether this client a first party client (true) or not (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("is_first_party")]
    public bool? IsFirstParty { get; set; }

    /// <summary>
    /// Whether this client conforms to <see href="https://auth0.com/docs/api-auth/tutorials/adoption">strict OIDC specifications</see> (true) or uses legacy features (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("oidc_conformant")]
    public bool? OidcConformant { get; set; }

    /// <summary>
    /// Comma-separated list of URLs whitelisted for Auth0 to use as a callback to the client after authentication.
    /// </summary>
    [Optional]
    [JsonPropertyName("callbacks")]
    public IEnumerable<string>? Callbacks { get; set; }

    /// <summary>
    /// Comma-separated list of URLs allowed to make requests from JavaScript to Auth0 API (typically used with CORS). By default, all your callback URLs will be allowed. This field allows you to enter other origins if necessary. You can also use wildcards at the subdomain level (e.g., https://*.contoso.com). Query strings and hash information are not taken into account when validating these URLs.
    /// </summary>
    [Optional]
    [JsonPropertyName("allowed_origins")]
    public IEnumerable<string>? AllowedOrigins { get; set; }

    /// <summary>
    /// Comma-separated list of allowed origins for use with <see href="https://auth0.com/docs/cross-origin-authentication">Cross-Origin Authentication</see>, <see href="https://auth0.com/docs/flows/concepts/device-auth">Device Flow</see>, and <see href="https://auth0.com/docs/protocols/oauth2#how-response-mode-works">web message response mode</see>.
    /// </summary>
    [Optional]
    [JsonPropertyName("web_origins")]
    public IEnumerable<string>? WebOrigins { get; set; }

    /// <summary>
    /// List of audiences/realms for SAML protocol. Used by the wsfed addon.
    /// </summary>
    [Optional]
    [JsonPropertyName("client_aliases")]
    public IEnumerable<string>? ClientAliases { get; set; }

    /// <summary>
    /// List of allow clients and API ids that are allowed to make delegation requests. Empty means all all your clients are allowed.
    /// </summary>
    [Optional]
    [JsonPropertyName("allowed_clients")]
    public IEnumerable<string>? AllowedClients { get; set; }

    /// <summary>
    /// Comma-separated list of URLs that are valid to redirect to after logout from Auth0. Wildcards are allowed for subdomains.
    /// </summary>
    [Optional]
    [JsonPropertyName("allowed_logout_urls")]
    public IEnumerable<string>? AllowedLogoutUrls { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("session_transfer")]
    public Optional<ClientSessionTransferConfiguration?> SessionTransfer { get; set; }

    [Optional]
    [JsonPropertyName("oidc_logout")]
    public ClientOidcBackchannelLogoutSettings? OidcLogout { get; set; }

    /// <summary>
    /// List of grant types supported for this application. Can include `authorization_code`, `implicit`, `refresh_token`, `client_credentials`, `password`, `http://auth0.com/oauth/grant-type/password-realm`, `http://auth0.com/oauth/grant-type/mfa-oob`, `http://auth0.com/oauth/grant-type/mfa-otp`, `http://auth0.com/oauth/grant-type/mfa-recovery-code`, `urn:openid:params:grant-type:ciba`, `urn:ietf:params:oauth:grant-type:device_code`, and `urn:auth0:params:oauth:grant-type:token-exchange:federated-connection-access-token`.
    /// </summary>
    [Optional]
    [JsonPropertyName("grant_types")]
    public IEnumerable<string>? GrantTypes { get; set; }

    [Optional]
    [JsonPropertyName("jwt_configuration")]
    public ClientJwtConfiguration? JwtConfiguration { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("signing_keys")]
    public Optional<IEnumerable<ClientSigningKey>?> SigningKeys { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("encryption_key")]
    public Optional<ClientEncryptionKey?> EncryptionKey { get; set; }

    /// <summary>
    /// Applies only to SSO clients and determines whether Auth0 will handle Single Sign On (true) or whether the Identity Provider will (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("sso")]
    public bool? Sso { get; set; }

    /// <summary>
    /// Whether Single Sign On is disabled (true) or enabled (true). Defaults to true.
    /// </summary>
    [Optional]
    [JsonPropertyName("sso_disabled")]
    public bool? SsoDisabled { get; set; }

    /// <summary>
    /// Whether this client can be used to make cross-origin authentication requests (true) or it is not allowed to make such requests (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("cross_origin_authentication")]
    public bool? CrossOriginAuthentication { get; set; }

    /// <summary>
    /// URL of the location in your site where the cross origin verification takes place for the cross-origin auth flow when performing Auth in your own domain instead of Auth0 hosted login page.
    /// </summary>
    [Optional]
    [JsonPropertyName("cross_origin_loc")]
    public string? CrossOriginLoc { get; set; }

    /// <summary>
    /// Whether a custom login page is to be used (true) or the default provided login page (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("custom_login_page_on")]
    public bool? CustomLoginPageOn { get; set; }

    /// <summary>
    /// The content (HTML, CSS, JS) of the custom login page.
    /// </summary>
    [Optional]
    [JsonPropertyName("custom_login_page")]
    public string? CustomLoginPage { get; set; }

    /// <summary>
    /// The content (HTML, CSS, JS) of the custom login page. (Used on Previews)
    /// </summary>
    [Optional]
    [JsonPropertyName("custom_login_page_preview")]
    public string? CustomLoginPagePreview { get; set; }

    /// <summary>
    /// HTML form template to be used for WS-Federation.
    /// </summary>
    [Optional]
    [JsonPropertyName("form_template")]
    public string? FormTemplate { get; set; }

    [Optional]
    [JsonPropertyName("addons")]
    public ClientAddons? Addons { get; set; }

    [Optional]
    [JsonPropertyName("token_endpoint_auth_method")]
    public ClientTokenEndpointAuthMethodEnum? TokenEndpointAuthMethod { get; set; }

    /// <summary>
    /// If true, trust that the IP specified in the `auth0-forwarded-for` header is the end-user's IP for brute-force-protection on token endpoint.
    /// </summary>
    [Optional]
    [JsonPropertyName("is_token_endpoint_ip_header_trusted")]
    public bool? IsTokenEndpointIpHeaderTrusted { get; set; }

    [Optional]
    [JsonPropertyName("client_metadata")]
    public Dictionary<string, object?>? ClientMetadata { get; set; }

    [Optional]
    [JsonPropertyName("mobile")]
    public ClientMobile? Mobile { get; set; }

    /// <summary>
    /// Initiate login uri, must be https
    /// </summary>
    [Optional]
    [JsonPropertyName("initiate_login_uri")]
    public string? InitiateLoginUri { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("refresh_token")]
    public Optional<ClientRefreshTokenConfiguration?> RefreshToken { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("default_organization")]
    public Optional<ClientDefaultOrganization?> DefaultOrganization { get; set; }

    [Optional]
    [JsonPropertyName("organization_usage")]
    public ClientOrganizationUsageEnum? OrganizationUsage { get; set; }

    [Optional]
    [JsonPropertyName("organization_require_behavior")]
    public ClientOrganizationRequireBehaviorEnum? OrganizationRequireBehavior { get; set; }

    /// <summary>
    /// Defines the available methods for organization discovery during the `pre_login_prompt`. Users can discover their organization either by `email`, `organization_name` or both.
    /// </summary>
    [Optional]
    [JsonPropertyName("organization_discovery_methods")]
    public IEnumerable<ClientOrganizationDiscoveryEnum>? OrganizationDiscoveryMethods { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("client_authentication_methods")]
    public Optional<ClientAuthenticationMethod?> ClientAuthenticationMethods { get; set; }

    /// <summary>
    /// Makes the use of Pushed Authorization Requests mandatory for this client
    /// </summary>
    [Optional]
    [JsonPropertyName("require_pushed_authorization_requests")]
    public bool? RequirePushedAuthorizationRequests { get; set; }

    /// <summary>
    /// Makes the use of Proof-of-Possession mandatory for this client
    /// </summary>
    [Optional]
    [JsonPropertyName("require_proof_of_possession")]
    public bool? RequireProofOfPossession { get; set; }

    [Optional]
    [JsonPropertyName("signed_request_object")]
    public ClientSignedRequestObjectWithCredentialId? SignedRequestObject { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("compliance_level")]
    public Optional<ClientComplianceLevelEnum?> ComplianceLevel { get; set; }

    /// <summary>
    /// Controls whether a confirmation prompt is shown during login flows when the redirect URI uses non-verifiable callback URIs (for example, a custom URI schema such as `myapp://`, or `localhost`).
    /// If set to true, a confirmation prompt will not be shown. We recommend that this is set to false for improved protection from malicious apps.
    /// See https://auth0.com/docs/secure/security-guidance/measures-against-app-impersonation for more information.
    /// </summary>
    [Optional]
    [JsonPropertyName("skip_non_verifiable_callback_uri_confirmation_prompt")]
    public bool? SkipNonVerifiableCallbackUriConfirmationPrompt { get; set; }

    [Optional]
    [JsonPropertyName("token_exchange")]
    public ClientTokenExchangeConfiguration? TokenExchange { get; set; }

    /// <summary>
    /// Specifies how long, in seconds, a Pushed Authorization Request URI remains valid
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("par_request_expiry")]
    public Optional<int?> ParRequestExpiry { get; set; }

    [Optional]
    [JsonPropertyName("token_quota")]
    public TokenQuota? TokenQuota { get; set; }

    [Optional]
    [JsonPropertyName("express_configuration")]
    public ExpressConfiguration? ExpressConfiguration { get; set; }

    /// <summary>
    /// The identifier of the resource server that this client is linked to.
    /// </summary>
    [Optional]
    [JsonPropertyName("resource_server_identifier")]
    public string? ResourceServerIdentifier { get; set; }

    [Optional]
    [JsonPropertyName("async_approval_notification_channels")]
    public IEnumerable<AsyncApprovalNotificationsChannelsEnum>? AsyncApprovalNotificationChannels { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
