using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record GetTenantSettingsResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Nullable, Optional]
    [JsonPropertyName("change_password")]
    public Optional<TenantSettingsPasswordPage?> ChangePassword { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("guardian_mfa_page")]
    public Optional<TenantSettingsGuardianPage?> GuardianMfaPage { get; set; }

    /// <summary>
    /// Default audience for API authorization.
    /// </summary>
    [Optional]
    [JsonPropertyName("default_audience")]
    public string? DefaultAudience { get; set; }

    /// <summary>
    /// Name of connection used for password grants at the `/token`endpoint. The following connection types are supported: LDAP, AD, Database Connections, Passwordless, Windows Azure Active Directory, ADFS.
    /// </summary>
    [Optional]
    [JsonPropertyName("default_directory")]
    public string? DefaultDirectory { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("error_page")]
    public Optional<TenantSettingsErrorPage?> ErrorPage { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("device_flow")]
    public Optional<TenantSettingsDeviceFlow?> DeviceFlow { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("default_token_quota")]
    public Optional<DefaultTokenQuota?> DefaultTokenQuota { get; set; }

    [Optional]
    [JsonPropertyName("flags")]
    public TenantSettingsFlags? Flags { get; set; }

    /// <summary>
    /// Friendly name for this tenant.
    /// </summary>
    [Optional]
    [JsonPropertyName("friendly_name")]
    public string? FriendlyName { get; set; }

    /// <summary>
    /// URL of logo to be shown for this tenant (recommended size: 150x150)
    /// </summary>
    [Optional]
    [JsonPropertyName("picture_url")]
    public string? PictureUrl { get; set; }

    /// <summary>
    /// End-user support email address.
    /// </summary>
    [Optional]
    [JsonPropertyName("support_email")]
    public string? SupportEmail { get; set; }

    /// <summary>
    /// End-user support URL.
    /// </summary>
    [Optional]
    [JsonPropertyName("support_url")]
    public string? SupportUrl { get; set; }

    /// <summary>
    /// URLs that are valid to redirect to after logout from Auth0.
    /// </summary>
    [Optional]
    [JsonPropertyName("allowed_logout_urls")]
    public IEnumerable<string>? AllowedLogoutUrls { get; set; }

    /// <summary>
    /// Number of hours a session will stay valid.
    /// </summary>
    [Optional]
    [JsonPropertyName("session_lifetime")]
    public double? SessionLifetime { get; set; }

    /// <summary>
    /// Number of hours for which a session can be inactive before the user must log in again.
    /// </summary>
    [Optional]
    [JsonPropertyName("idle_session_lifetime")]
    public double? IdleSessionLifetime { get; set; }

    /// <summary>
    /// Number of hours an ephemeral (non-persistent) session will stay valid.
    /// </summary>
    [Optional]
    [JsonPropertyName("ephemeral_session_lifetime")]
    public double? EphemeralSessionLifetime { get; set; }

    /// <summary>
    /// Number of hours for which an ephemeral (non-persistent) session can be inactive before the user must log in again.
    /// </summary>
    [Optional]
    [JsonPropertyName("idle_ephemeral_session_lifetime")]
    public double? IdleEphemeralSessionLifetime { get; set; }

    /// <summary>
    /// Selected sandbox version for the extensibility environment.
    /// </summary>
    [Optional]
    [JsonPropertyName("sandbox_version")]
    public string? SandboxVersion { get; set; }

    /// <summary>
    /// Selected sandbox version for rules and hooks extensibility.
    /// </summary>
    [Optional]
    [JsonPropertyName("legacy_sandbox_version")]
    public string? LegacySandboxVersion { get; set; }

    /// <summary>
    /// Available sandbox versions for the extensibility environment.
    /// </summary>
    [Optional]
    [JsonPropertyName("sandbox_versions_available")]
    public IEnumerable<string>? SandboxVersionsAvailable { get; set; }

    /// <summary>
    /// The default absolute redirection uri, must be https
    /// </summary>
    [Optional]
    [JsonPropertyName("default_redirection_uri")]
    public string? DefaultRedirectionUri { get; set; }

    /// <summary>
    /// Supported locales for the user interface.
    /// </summary>
    [Optional]
    [JsonPropertyName("enabled_locales")]
    public IEnumerable<SupportedLocales>? EnabledLocales { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("session_cookie")]
    public Optional<SessionCookieSchema?> SessionCookie { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("sessions")]
    public Optional<TenantSettingsSessions?> Sessions { get; set; }

    [Optional]
    [JsonPropertyName("oidc_logout")]
    public TenantOidcLogoutSettings? OidcLogout { get; set; }

    /// <summary>
    /// Whether to accept an organization name instead of an ID on auth endpoints
    /// </summary>
    [Optional]
    [JsonPropertyName("allow_organization_name_in_authentication_api")]
    public bool? AllowOrganizationNameInAuthenticationApi { get; set; }

    /// <summary>
    /// Whether to enable flexible factors for MFA in the PostLogin action
    /// </summary>
    [Optional]
    [JsonPropertyName("customize_mfa_in_postlogin_action")]
    public bool? CustomizeMfaInPostloginAction { get; set; }

    /// <summary>
    /// Supported ACR values
    /// </summary>
    [Optional]
    [JsonPropertyName("acr_values_supported")]
    public IEnumerable<string>? AcrValuesSupported { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("mtls")]
    public Optional<TenantSettingsMtls?> Mtls { get; set; }

    /// <summary>
    /// Enables the use of Pushed Authorization Requests
    /// </summary>
    [Optional]
    [JsonPropertyName("pushed_authorization_requests_supported")]
    public bool? PushedAuthorizationRequestsSupported { get; set; }

    /// <summary>
    /// Supports iss parameter in authorization responses
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("authorization_response_iss_parameter_supported")]
    public Optional<bool?> AuthorizationResponseIssParameterSupported { get; set; }

    /// <summary>
    /// Controls whether a confirmation prompt is shown during login flows when the redirect URI uses non-verifiable callback URIs (for example, a custom URI schema such as `myapp://`, or `localhost`).
    /// If set to true, a confirmation prompt will not be shown. We recommend that this is set to false for improved protection from malicious apps.
    /// See https://auth0.com/docs/secure/security-guidance/measures-against-app-impersonation for more information.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("skip_non_verifiable_callback_uri_confirmation_prompt")]
    public Optional<bool?> SkipNonVerifiableCallbackUriConfirmationPrompt { get; set; }

    [Optional]
    [JsonPropertyName("resource_parameter_profile")]
    public TenantSettingsResourceParameterProfile? ResourceParameterProfile { get; set; }

    /// <summary>
    /// Whether Phone Consolidated Experience is enabled for this tenant.
    /// </summary>
    [Optional]
    [JsonPropertyName("phone_consolidated_experience")]
    public bool? PhoneConsolidatedExperience { get; set; }

    /// <summary>
    /// Whether Auth0 Guide (AI-powered assistance) is enabled for this tenant.
    /// </summary>
    [Optional]
    [JsonPropertyName("enable_ai_guide")]
    public bool? EnableAiGuide { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
