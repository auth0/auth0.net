using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Tenant flags.
    /// </summary>
    public class TenantFlags
    {
        /// <summary>
        /// Enables the first version of the Change Password flow. We've deprecated this option and recommending a safer flow. This flag is only for backwards compatibility.
        /// </summary>
        [JsonProperty("change_pwd_flow_v1")]
        public bool ChangePwdFlowV1 { get; set; }

        /// <summary>
        /// This flag enables the APIs section.
        /// </summary>
        [JsonProperty("enable_apis_section")]
        public bool EnableAPIsSection { get; set; }

        /// <summary>
        /// This flag determines whether all current connections shall be enabled when a new client is created. Default value is true.
        /// </summary>
        [JsonProperty("enable_client_connections")]
        public bool EnableClientConnections { get; set; }

        /// <summary>
        /// This flag enables advanced API Authorization scenarios.
        /// </summary>
        [JsonProperty("enable_pipeline2")]
        public bool EnablePipeline2 { get; set; }

        /// <summary>
        /// If true, the classic Universal Login prompts will not include additional security headers to prevent click-jacking.
        /// </summary>
        [JsonProperty("disable_clickjack_protection_headers")]
        public bool DisableClickjackProtectionHeaders { get; set; }

        /// <summary>
        /// Whether third-party developers can dynamically register applications for your APIs (true) or not (false). This flag enables dynamic client registration.
        /// </summary>
        [JsonProperty("enable_dynamic_client_registration")]
        public bool? EnableDynamicClientRegistration { get; set; } = null;
        
        /// <summary>
        /// Whether emails sent by Auth0 for change password, verification etc. should use your verified custom domain (true) or your auth0.com sub-domain (false). Affects all emails, links, and URLs. Email will fail if the custom domain is not verified.
        /// </summary>
        [JsonProperty("enable_custom_domain_in_emails")]
        public bool? EnableCustomDomainInEmails { get; set; } = null;

        /// <summary>
        /// Whether the legacy /tokeninfo endpoint is enabled for your account (true) or unavailable (false).
        /// </summary>
        [JsonProperty("allow_legacy_tokeninfo_endpoint")]
        public bool? AllowLegacyTokeninfoEndpoint { get; set; } = null;

        /// <summary>
        /// Whether ID tokens and the userinfo endpoint includes a complete user profile (true) or only OpenID Connect claims (false).
        /// </summary>
        [JsonProperty("enable_legacy_profile")]
        public bool? EnableLegacyProfile { get; set; } = null;

        /// <summary>
        /// Whether ID tokens can be used to authorize some types of requests to API v2 (true) not not (false).
        /// </summary>
        [JsonProperty("enable_idtoken_api2")]
        public bool? EnableIdTokenApi2 { get; set; } = null;

        /// <summary>
        /// Whether the public sign up process shows a user_exists error (true) or a generic error (false) if the user already exists.
        /// </summary>
        [JsonProperty("enable_public_signup_user_exists_error")]
        public bool? EnablePublicSignupUserExistsError { get; set; } = null;

        /// <summary>
        /// Whether the legacy delegation endpoint will be enabled for your account (true) or not available (false).
        /// </summary>
        [JsonProperty("allow_legacy_delegation_grant_types")]
        public bool? AllowLegacyDelegationGrantTypes { get; set; } = null;

        /// <summary>
        /// Whether the legacy auth/ro endpoint (used with resource owner password and passwordless features) will be enabled for your account (true) or not available (false).
        /// </summary>
        [JsonProperty("allow_legacy_ro_grant_types")]
        public bool? AllowLegacyRoGrantTypes { get; set; } = null;

        /// <summary>
        /// Whether users are prompted to confirm log in before SSO redirection (false) or are not prompted (true).
        /// </summary>
        [JsonProperty("enable_sso")]
        public bool? EnableSSO { get; set; } = null;

        /// <summary>
        /// Do not Publish Enterprise Connections Information with IdP domains on the lock configuration file.
        /// </summary>
        [JsonProperty("no_disclose_enterprise_connections")]
        public bool? NoDiscloseEnterpriseConnections { get; set; } = null;

        /// <summary>
        /// If true, SMS phone numbers will not be obfuscated in Management API GET calls.
        /// </summary>
        [JsonProperty("disable_management_api_sms_obfuscation")]
        public bool? DisableManagementApiSmsObfuscation { get; set; } = null;

        /// <summary>
        /// Enforce client authentication for passwordless start
        /// </summary>
        [JsonProperty("enforce_client_authentication_on_passwordless_start")]
        public bool? EnforceClientAuthenticationOnPasswordlessStart { get; set; } = null;

        /// <summary>
        /// Changes email_verified behavior for Azure AD/ADFS connections when enabled. Sets email_verified to false otherwise.
        /// </summary>
        [JsonProperty("trust_azure_adfs_email_verified_connection_property")]
        public bool? TrustAzureAdfsEmailVerifiedConnectionProperty { get; set; } = null;

        /// <summary>
        /// Enables the email verification flow during login for Azure AD and ADFS connections
        /// </summary>
        [JsonProperty("enable_adfs_waad_email_verification")]
        public bool? EnableAdfsWaadEmailVerification { get; set; } = null;

        /// <summary>
        /// Delete underlying grant when a Refresh Token is revoked via the Authentication API.
        /// </summary>
        [JsonProperty("revoke_refresh_token_grant")]
        public bool? RevokeRefreshTokenGrant { get; set; } = null;
        
        /// <summary>
        /// Makes the use of Pushed Authorization Requests mandatory for all clients across the tenant.
        /// </summary>
        [JsonProperty("require_pushed_authorization_requests")]
        public bool? RequirePushedAuthorizationRequests { get; set; } = null;
    }
}
