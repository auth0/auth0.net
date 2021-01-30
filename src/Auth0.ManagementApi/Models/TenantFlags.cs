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
        /// </summary>
        [JsonProperty("enable_dynamic_client_registration")]
        public bool EnableDynamicClientRegistration { get; set; }
        
        /// <summary>
        /// </summary>
        [JsonProperty("enable_custom_domain_in_emails")]
        public bool EnableCustomDomainInEmails { get; set; }
        
        /// <summary>
        /// </summary>
        [JsonProperty("allow_legacy_tokeninfo_endpoint")]
        public bool AllowLegacyTokeninfoEndpoint { get; set; }
        
        /// <summary>
        /// </summary>
        [JsonProperty("enable_legacy_profile")]
        public bool EnableLegacyProfile { get; set; }
        
        /// <summary>
        /// </summary>
        [JsonProperty("enable_idtoken_api2")]
        public bool EnableIdTokenApi2 { get; set; }
        
        /// <summary>
        /// </summary>
        [JsonProperty("enable_public_signup_user_exists_error")]
        public bool EnablePublicSignupUserExistsError { get; set; }
        
        /// <summary>
        /// </summary>
        [JsonProperty("allow_legacy_delegation_grant_types")]
        public bool AllowLegacyDelegationGrantTypes { get; set; }
        
        /// <summary>
        /// </summary>
        [JsonProperty("allow_legacy_ro_grant_types")]
        public bool AllowLegacyRoGrantTypes { get; set; }
        
        /// <summary>
        /// </summary>
        [JsonProperty("enable_sso")]
        public bool EnableSSO { get; set; }
        
        /// <summary>
        /// </summary>
        [JsonProperty("no_disclose_enterprise_connections")]
        public bool NoDiscloseEnterpriseConnections { get; set; }
        
        /// <summary>
        /// </summary>
        [JsonProperty("disable_management_api_sms_obfuscation")]
        public bool DisableManagementApiSmsObfuscation { get; set; }
        
        /// <summary>
        /// </summary>
        [JsonProperty("enforce_client_authentication_on_passwordless_start")]
        public bool EnforceClientAuthenticationOnPasswordlessStart { get; set; }
        
        /// <summary>
        /// </summary>
        [JsonProperty("trust_azure_adfs_email_verified_connection_property")]
        public bool TrustAzureAdfsEmailVerifiedConnectionProperty { get; set; }
        
        /// <summary>
        /// </summary>
        [JsonProperty("enable_adfs_waad_email_verification")]
        public bool EnabdleAdfsWaadEmailVerification { get; set; }
        
        /// <summary>
        /// </summary>
        [JsonProperty("revoke_refresh_token_grant")]
        public bool RovokeRefreshTokenGrant { get; set; }
    }
}
