using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class SessionCookie
    {
        /// <summary>
        /// Behavior of the session cookie
        /// </summary>
        /// <remarks>Can be any of 'persistent' or 'non-persistent'</remarks>
        [JsonProperty("mode")]
        public string Mode { get; set; }
    }

    /// <summary>
    /// Settings for a given tenant.
    /// </summary>
    public class TenantSettingsBase
    {
        /// <summary>
        /// Change Password page customization.
        /// </summary>
        [JsonProperty("change_password")]
        public TenantChangePassword ChangePassword { get; set; }

        /// <summary>
        /// Guardian page customization.
        /// </summary>
        [JsonProperty("guardian_mfa_page")]
        public TenantGuardianMfaPage GuardianMfaPage { get; set; }

        /// <summary>
        /// Default audience for API Authorization.
        /// </summary>
        [JsonProperty("default_audience")]
        public string DefaultAudience { get; set; }

        /// <summary>
        /// Name of the connection that will be used for password grants at the token endpoint. Only the following connection types are supported: LDAP, AD, Database Connections, Passwordless, Windows Azure Active Directory, ADFS.
        /// </summary>
        [JsonProperty("default_directory")]
        public string DefaultDirectory { get; set; }

        /// <summary>
        /// Tenant error page customization.
        /// </summary>
        [JsonProperty("error_page")]
        public TenantErrorPage ErrorPage { get; set; }

        /// <summary>
        /// Tenant Device Flow configuration.
        /// </summary>
        [JsonProperty("device_flow")]
        public TenantDeviceFlow DeviceFlow { get; set; }

        /// <summary>
        /// Tenant flags.
        /// </summary>
        [JsonProperty("flags")]
        public TenantFlags Flags { get; set; }

        /// <summary>
        /// The friendly name of the tenant.
        /// </summary>
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }

        /// <summary>
        /// The URL of the tenant logo (recommended size: 150x150).
        /// </summary>
        [JsonProperty("picture_url")]
        public string PictureUrl { get; set; }

        /// <summary>
        /// User support email.
        /// </summary>
        [JsonProperty("support_email")]
        public string SupportEmail { get; set; }

        /// <summary>
        /// User support URL.
        /// </summary>
        [JsonProperty("support_url")]
        public string SupportUrl { get; set; }

        /// <summary>
        /// A set of URLs that are valid to redirect to after logout from Auth0.
        /// </summary>
        [JsonProperty("allowed_logout_urls")]
        public string[] AllowedLogoutUrls { get; set; }

        /// <summary>
        /// Login session lifetime, how long the session will stay valid (unit: hours).
        /// </summary>
        [JsonProperty("session_lifetime")]
        public float? SessionLifetime { get; set; }

        /// <summary>
        /// Force a user to login after they have been inactive for the specified number (unit: hours).
        /// </summary>
        [JsonProperty("idle_session_lifetime")]
        public float? IdleSessionLifetime { get; set; }

        /// <summary>
        /// The selected sandbox version to be used for the extensibility environment.
        /// </summary>
        [JsonProperty("sandbox_version")]
        public string SandboxVersion { get; set; }

        /// <summary>
        /// A set of available sandbox versions for the extensibility environment.
        /// </summary>
        [JsonProperty("sandbox_versions_available")]
        public string[] SandboxVersionsAvailable { get; set; }

        /// <summary>
        /// Supported locales for the UI.
        /// </summary>
        [JsonProperty("enabled_locales")]
        public string[] EnabledLocales { get; set; }

        /// <summary>
        /// Session cookie configuration
        /// </summary>
        [JsonProperty("session_cookie")]
        public SessionCookie SessionCookie { get; set; }
        
        /// <summary>
        /// Whether to enable flexible factors for MFA in the PostLogin action
        /// </summary>
        [JsonProperty("customize_mfa_in_postlogin_action")]
        public bool? CustomizeMfaInPostLoginAction { get; set; } = null;
    }
}