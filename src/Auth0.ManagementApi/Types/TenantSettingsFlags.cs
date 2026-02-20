using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Flags used to change the behavior of this tenant.
/// </summary>
[Serializable]
public record TenantSettingsFlags : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Whether to use the older v1 change password flow (true, not recommended except for backward compatibility) or the newer safer flow (false, recommended).
    /// </summary>
    [Optional]
    [JsonPropertyName("change_pwd_flow_v1")]
    public bool? ChangePwdFlowV1 { get; set; }

    /// <summary>
    /// Whether the APIs section is enabled (true) or disabled (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("enable_apis_section")]
    public bool? EnableApisSection { get; set; }

    /// <summary>
    /// Whether the impersonation functionality has been disabled (true) or not (false). Read-only.
    /// </summary>
    [Optional]
    [JsonPropertyName("disable_impersonation")]
    public bool? DisableImpersonation { get; set; }

    /// <summary>
    /// Whether all current connections should be enabled when a new client (application) is created (true, default) or not (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("enable_client_connections")]
    public bool? EnableClientConnections { get; set; }

    /// <summary>
    /// Whether advanced API Authorization scenarios are enabled (true) or disabled (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("enable_pipeline2")]
    public bool? EnablePipeline2 { get; set; }

    /// <summary>
    /// If enabled, clients are able to add legacy delegation grants.
    /// </summary>
    [Optional]
    [JsonPropertyName("allow_legacy_delegation_grant_types")]
    public bool? AllowLegacyDelegationGrantTypes { get; set; }

    /// <summary>
    /// If enabled, clients are able to add legacy RO grants.
    /// </summary>
    [Optional]
    [JsonPropertyName("allow_legacy_ro_grant_types")]
    public bool? AllowLegacyRoGrantTypes { get; set; }

    /// <summary>
    /// Whether the legacy `/tokeninfo` endpoint is enabled for your account (true) or unavailable (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("allow_legacy_tokeninfo_endpoint")]
    public bool? AllowLegacyTokeninfoEndpoint { get; set; }

    /// <summary>
    /// Whether ID tokens and the userinfo endpoint includes a complete user profile (true) or only OpenID Connect claims (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("enable_legacy_profile")]
    public bool? EnableLegacyProfile { get; set; }

    /// <summary>
    /// Whether ID tokens can be used to authorize some types of requests to API v2 (true) not not (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("enable_idtoken_api2")]
    public bool? EnableIdtokenApi2 { get; set; }

    /// <summary>
    /// Whether the public sign up process shows a user_exists error (true) or a generic error (false) if the user already exists.
    /// </summary>
    [Optional]
    [JsonPropertyName("enable_public_signup_user_exists_error")]
    public bool? EnablePublicSignupUserExistsError { get; set; }

    /// <summary>
    /// Whether users are prompted to confirm log in before SSO redirection (false) or are not prompted (true).
    /// </summary>
    [Optional]
    [JsonPropertyName("enable_sso")]
    public bool? EnableSso { get; set; }

    /// <summary>
    /// Whether the `enable_sso` setting can be changed (true) or not (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("allow_changing_enable_sso")]
    public bool? AllowChangingEnableSso { get; set; }

    /// <summary>
    /// Whether classic Universal Login prompts include additional security headers to prevent clickjacking (true) or no safeguard (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("disable_clickjack_protection_headers")]
    public bool? DisableClickjackProtectionHeaders { get; set; }

    /// <summary>
    /// Do not Publish Enterprise Connections Information with IdP domains on the lock configuration file.
    /// </summary>
    [Optional]
    [JsonPropertyName("no_disclose_enterprise_connections")]
    public bool? NoDiscloseEnterpriseConnections { get; set; }

    /// <summary>
    /// Enforce client authentication for passwordless start.
    /// </summary>
    [Optional]
    [JsonPropertyName("enforce_client_authentication_on_passwordless_start")]
    public bool? EnforceClientAuthenticationOnPasswordlessStart { get; set; }

    /// <summary>
    /// Enables the email verification flow during login for Azure AD and ADFS connections
    /// </summary>
    [Optional]
    [JsonPropertyName("enable_adfs_waad_email_verification")]
    public bool? EnableAdfsWaadEmailVerification { get; set; }

    /// <summary>
    /// Delete underlying grant when a Refresh Token is revoked via the Authentication API.
    /// </summary>
    [Optional]
    [JsonPropertyName("revoke_refresh_token_grant")]
    public bool? RevokeRefreshTokenGrant { get; set; }

    /// <summary>
    /// Enables beta access to log streaming changes
    /// </summary>
    [Optional]
    [JsonPropertyName("dashboard_log_streams_next")]
    public bool? DashboardLogStreamsNext { get; set; }

    /// <summary>
    /// Enables new insights activity page view
    /// </summary>
    [Optional]
    [JsonPropertyName("dashboard_insights_view")]
    public bool? DashboardInsightsView { get; set; }

    /// <summary>
    /// Disables SAML fields map fix for bad mappings with repeated attributes
    /// </summary>
    [Optional]
    [JsonPropertyName("disable_fields_map_fix")]
    public bool? DisableFieldsMapFix { get; set; }

    /// <summary>
    /// Used to allow users to pick what factor to enroll of the available MFA factors.
    /// </summary>
    [Optional]
    [JsonPropertyName("mfa_show_factor_list_on_enrollment")]
    public bool? MfaShowFactorListOnEnrollment { get; set; }

    /// <summary>
    /// Removes alg property from jwks .well-known endpoint
    /// </summary>
    [Optional]
    [JsonPropertyName("remove_alg_from_jwks")]
    public bool? RemoveAlgFromJwks { get; set; }

    /// <summary>
    /// Improves bot detection during signup in classic universal login
    /// </summary>
    [Optional]
    [JsonPropertyName("improved_signup_bot_detection_in_classic")]
    public bool? ImprovedSignupBotDetectionInClassic { get; set; }

    /// <summary>
    /// This tenant signed up for the Auth4GenAI trail
    /// </summary>
    [Optional]
    [JsonPropertyName("genai_trial")]
    public bool? GenaiTrial { get; set; }

    /// <summary>
    /// Whether third-party developers can <see href="https://auth0.com/docs/api-auth/dynamic-client-registration">dynamically register</see> applications for your APIs (true) or not (false). This flag enables dynamic client registration.
    /// </summary>
    [Optional]
    [JsonPropertyName("enable_dynamic_client_registration")]
    public bool? EnableDynamicClientRegistration { get; set; }

    /// <summary>
    /// If true, SMS phone numbers will not be obfuscated in Management API GET calls.
    /// </summary>
    [Optional]
    [JsonPropertyName("disable_management_api_sms_obfuscation")]
    public bool? DisableManagementApiSmsObfuscation { get; set; }

    /// <summary>
    /// Changes email_verified behavior for Azure AD/ADFS connections when enabled. Sets email_verified to false otherwise.
    /// </summary>
    [Optional]
    [JsonPropertyName("trust_azure_adfs_email_verified_connection_property")]
    public bool? TrustAzureAdfsEmailVerifiedConnectionProperty { get; set; }

    /// <summary>
    /// If true, custom domains feature will be enabled for tenant.
    /// </summary>
    [Optional]
    [JsonPropertyName("custom_domains_provisioning")]
    public bool? CustomDomainsProvisioning { get; set; }

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
