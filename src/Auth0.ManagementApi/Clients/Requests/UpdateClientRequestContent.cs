using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateClientRequestContent
{
    /// <summary>
    /// The name of the client. Must contain at least one character. Does not allow '&lt;' or '&gt;'.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Free text description of the purpose of the Client. (Max character length: <c>140</c>)
    /// </summary>
    [Optional]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The secret used to sign tokens for the client
    /// </summary>
    [Optional]
    [JsonPropertyName("client_secret")]
    public string? ClientSecret { get; set; }

    /// <summary>
    /// The URL of the client logo (recommended size: 150x150)
    /// </summary>
    [Optional]
    [JsonPropertyName("logo_uri")]
    public string? LogoUri { get; set; }

    /// <summary>
    /// A set of URLs that are valid to call back from Auth0 when authenticating users
    /// </summary>
    [Optional]
    [JsonPropertyName("callbacks")]
    public IEnumerable<string>? Callbacks { get; set; }

    [Optional]
    [JsonPropertyName("oidc_logout")]
    public ClientOidcBackchannelLogoutSettings? OidcLogout { get; set; }

    /// <summary>
    /// Configuration for OIDC backchannel logout (deprecated, in favor of oidc_logout)
    /// </summary>
    [Optional]
    [JsonPropertyName("oidc_backchannel_logout")]
    public ClientOidcBackchannelLogoutSettings? OidcBackchannelLogout { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("session_transfer")]
    public Optional<ClientSessionTransferConfiguration?> SessionTransfer { get; set; }

    /// <summary>
    /// A set of URLs that represents valid origins for CORS
    /// </summary>
    [Optional]
    [JsonPropertyName("allowed_origins")]
    public IEnumerable<string>? AllowedOrigins { get; set; }

    /// <summary>
    /// A set of URLs that represents valid web origins for use with web message response mode
    /// </summary>
    [Optional]
    [JsonPropertyName("web_origins")]
    public IEnumerable<string>? WebOrigins { get; set; }

    /// <summary>
    /// A set of grant types that the client is authorized to use. Can include `authorization_code`, `implicit`, `refresh_token`, `client_credentials`, `password`, `http://auth0.com/oauth/grant-type/password-realm`, `http://auth0.com/oauth/grant-type/mfa-oob`, `http://auth0.com/oauth/grant-type/mfa-otp`, `http://auth0.com/oauth/grant-type/mfa-recovery-code`, `urn:openid:params:grant-type:ciba`, `urn:ietf:params:oauth:grant-type:device_code`, and `urn:auth0:params:oauth:grant-type:token-exchange:federated-connection-access-token`.
    /// </summary>
    [Optional]
    [JsonPropertyName("grant_types")]
    public IEnumerable<string>? GrantTypes { get; set; }

    /// <summary>
    /// List of audiences for SAML protocol
    /// </summary>
    [Optional]
    [JsonPropertyName("client_aliases")]
    public IEnumerable<string>? ClientAliases { get; set; }

    /// <summary>
    /// Ids of clients that will be allowed to perform delegation requests. Clients that will be allowed to make delegation request. By default, all your clients will be allowed. This field allows you to specify specific clients
    /// </summary>
    [Optional]
    [JsonPropertyName("allowed_clients")]
    public IEnumerable<string>? AllowedClients { get; set; }

    /// <summary>
    /// URLs that are valid to redirect to after logout from Auth0
    /// </summary>
    [Optional]
    [JsonPropertyName("allowed_logout_urls")]
    public IEnumerable<string>? AllowedLogoutUrls { get; set; }

    /// <summary>
    /// An object that holds settings related to how JWTs are created
    /// </summary>
    [Optional]
    [JsonPropertyName("jwt_configuration")]
    public ClientJwtConfiguration? JwtConfiguration { get; set; }

    /// <summary>
    /// The client's encryption key
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("encryption_key")]
    public Optional<ClientEncryptionKey?> EncryptionKey { get; set; }

    /// <summary>
    /// <c>true</c> to use Auth0 instead of the IdP to do Single Sign On, <c>false</c> otherwise (default: <c>false</c>)
    /// </summary>
    [Optional]
    [JsonPropertyName("sso")]
    public bool? Sso { get; set; }

    /// <summary>
    /// <c>true</c> if this client can be used to make cross-origin authentication requests, <c>false</c> otherwise if cross origin is disabled
    /// </summary>
    [Optional]
    [JsonPropertyName("cross_origin_authentication")]
    public bool? CrossOriginAuthentication { get; set; }

    /// <summary>
    /// URL for the location in your site where the cross origin verification takes place for the cross-origin auth flow when performing Auth in your own domain instead of Auth0 hosted login page.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("cross_origin_loc")]
    public Optional<string?> CrossOriginLoc { get; set; }

    /// <summary>
    /// <c>true</c> to disable Single Sign On, <c>false</c> otherwise (default: <c>false</c>)
    /// </summary>
    [Optional]
    [JsonPropertyName("sso_disabled")]
    public bool? SsoDisabled { get; set; }

    /// <summary>
    /// <c>true</c> if the custom login page is to be used, <c>false</c> otherwise.
    /// </summary>
    [Optional]
    [JsonPropertyName("custom_login_page_on")]
    public bool? CustomLoginPageOn { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("token_endpoint_auth_method")]
    public Optional<ClientTokenEndpointAuthMethodOrNullEnum?> TokenEndpointAuthMethod { get; set; }

    /// <summary>
    /// If true, trust that the IP specified in the `auth0-forwarded-for` header is the end-user's IP for brute-force-protection on token endpoint.
    /// </summary>
    [Optional]
    [JsonPropertyName("is_token_endpoint_ip_header_trusted")]
    public bool? IsTokenEndpointIpHeaderTrusted { get; set; }

    [Optional]
    [JsonPropertyName("app_type")]
    public ClientAppTypeEnum? AppType { get; set; }

    /// <summary>
    /// Whether this client a first party client or not
    /// </summary>
    [Optional]
    [JsonPropertyName("is_first_party")]
    public bool? IsFirstParty { get; set; }

    /// <summary>
    /// Whether this client will conform to strict OIDC specifications
    /// </summary>
    [Optional]
    [JsonPropertyName("oidc_conformant")]
    public bool? OidcConformant { get; set; }

    /// <summary>
    /// The content (HTML, CSS, JS) of the custom login page
    /// </summary>
    [Optional]
    [JsonPropertyName("custom_login_page")]
    public string? CustomLoginPage { get; set; }

    [Optional]
    [JsonPropertyName("custom_login_page_preview")]
    public string? CustomLoginPagePreview { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("token_quota")]
    public Optional<UpdateTokenQuota?> TokenQuota { get; set; }

    /// <summary>
    /// Form template for WS-Federation protocol
    /// </summary>
    [Optional]
    [JsonPropertyName("form_template")]
    public string? FormTemplate { get; set; }

    [Optional]
    [JsonPropertyName("addons")]
    public ClientAddons? Addons { get; set; }

    [Optional]
    [JsonPropertyName("client_metadata")]
    public Dictionary<string, object?>? ClientMetadata { get; set; }

    /// <summary>
    /// Configuration related to native mobile apps
    /// </summary>
    [Optional]
    [JsonPropertyName("mobile")]
    public ClientMobile? Mobile { get; set; }

    /// <summary>
    /// Initiate login uri, must be https
    /// </summary>
    [Optional]
    [JsonPropertyName("initiate_login_uri")]
    public string? InitiateLoginUri { get; set; }

    [Optional]
    [JsonPropertyName("native_social_login")]
    public NativeSocialLogin? NativeSocialLogin { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("refresh_token")]
    public Optional<ClientRefreshTokenConfiguration?> RefreshToken { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("default_organization")]
    public Optional<ClientDefaultOrganization?> DefaultOrganization { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("organization_usage")]
    public Optional<ClientOrganizationUsagePatchEnum?> OrganizationUsage { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("organization_require_behavior")]
    public Optional<ClientOrganizationRequireBehaviorPatchEnum?> OrganizationRequireBehavior { get; set; }

    /// <summary>
    /// Defines the available methods for organization discovery during the `pre_login_prompt`. Users can discover their organization either by `email`, `organization_name` or both.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("organization_discovery_methods")]
    public Optional<IEnumerable<ClientOrganizationDiscoveryEnum>?> OrganizationDiscoveryMethods { get; set; }

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
    [Nullable, Optional]
    [JsonPropertyName("skip_non_verifiable_callback_uri_confirmation_prompt")]
    public Optional<bool?> SkipNonVerifiableCallbackUriConfirmationPrompt { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("token_exchange")]
    public Optional<ClientTokenExchangeConfigurationOrNull?> TokenExchange { get; set; }

    /// <summary>
    /// Specifies how long, in seconds, a Pushed Authorization Request URI remains valid
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("par_request_expiry")]
    public Optional<int?> ParRequestExpiry { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("express_configuration")]
    public Optional<ExpressConfigurationOrNull?> ExpressConfiguration { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("async_approval_notification_channels")]
    public Optional<IEnumerable<AsyncApprovalNotificationsChannelsEnum>?> AsyncApprovalNotificationChannels { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
