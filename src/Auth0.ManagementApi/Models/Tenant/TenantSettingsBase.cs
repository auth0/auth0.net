﻿using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

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
/// Sessions related settings for tenant
/// </summary>
public class Session
{
    /// <summary>
    /// Whether to bypass prompting logic (false) when performing OIDC Logout
    /// </summary>
    [JsonProperty("oidc_logout_prompt_enabled")]
    public bool? OidcLogoutPromptEnabled { get; set; }
}

/// <summary>
/// Settings related to OIDC RP-initiated Logout
/// </summary>
public class OidcLogout
{
    /// <summary>
    /// Enable the end_session_endpoint URL in the .well-known discovery configuration.
    /// </summary>
    [JsonProperty("rp_logout_end_session_endpoint_discovery")]
    public bool? RpLogoutEndSessionEndpointDiscovery { get; set; }
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
    /// Selected sandbox version for rules and hooks extensibility.
    /// </summary>
    [JsonProperty("legacy_sandbox_version")]
    public string LegacySandboxVersion { get; set; }
        
    /// <summary>
    /// A set of available sandbox versions for the extensibility environment.
    /// </summary>
    [JsonProperty("sandbox_versions_available")]
    public string[] SandboxVersionsAvailable { get; set; }

    /// <summary>
    /// The default absolute redirection uri, must be https
    /// </summary>
    [JsonProperty("default_redirection_uri")]
    public string DefaultRedirectionUri { get; set; }
        
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
        
    /// <inheritdoc cref="Session"/>
    [JsonProperty("sessions")]
    public Session Sessions { get; set; }
        
    /// <inheritdoc cref="Auth0.ManagementApi.Models.OidcLogout"/>
    [JsonProperty("oidc_logout")]
    public OidcLogout OidcLogout { get; set; }
        
    /// <summary>
    /// Whether to accept an organization name instead of an ID on auth endpoints
    /// </summary>
    [JsonProperty("allow_organization_name_in_authentication_api")]
    public bool? AllowOrganizationNameInAuthenticationApi { get; set; }
        
    /// <summary>
    /// Whether to enable flexible factors for MFA in the PostLogin action
    /// </summary>
    [JsonProperty("customize_mfa_in_postlogin_action")]
    public bool? CustomizeMfaInPostLoginAction { get; set; } = null;
        
    /// <summary>
    /// Supported ACR values
    /// </summary>
    [JsonProperty("acr_values_supported")]
    public string[] AcrValuesSupported { get; set; }
        
    /// <summary>
    /// Enables the use of Pushed Authorization Requests
    /// </summary>
    [JsonProperty("pushed_authorization_requests_supported")]
    public bool? PushedAuthorizationRequestsSupported { get; set; }

    /// <summary>
    /// mTLS configuration.
    /// </summary>
    [JsonProperty("mtls")]
    public TenantMtls Mtls { get; set; }

    /// <summary>
    /// Supports iss parameter in authorization responses
    /// </summary>
    [JsonProperty("authorization_response_iss_parameter_supported")]
    public bool? AuthorizationResponseIssParameterSupported { get; set; }
        
    /// <summary>
    /// This defines the default token quota which will be used when there is no specified token quota.
    /// </summary>
    [JsonProperty("default_token_quota")]
    public DefaultTokenQuota DefaultTokenQuota { get; set; }
}