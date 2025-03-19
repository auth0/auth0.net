using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models.SelfServiceProfiles
{
    /// <summary>
    /// If provided, this will create a new connection for the SSO flow with the given configuration.
    /// </summary>
    public class SelfServiceSsoConnectionConfig
    {
        /// <summary>
        /// Name of the connection that will be created as part of the SSO flow.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Connection name used in the new universal login experience
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        
        /// <summary>
        /// true promotes to a domain-level connection so that third-party applications can use it.
        /// false does not promote the connection,
        /// so only first-party applications with the connection enabled can use it.
        /// </summary>
        [JsonProperty("is_domain_connection")]
        public bool? IsDomainConnection { get; set; }
        
        /// <summary>
        /// Enables showing a button for the connection in the login page (new experience only).
        /// If false, it will be usable only by HRD.
        /// </summary>
        [JsonProperty("show_as_button")]
        public bool? ShowAsButton { get; set; }
        
        /// <summary>
        /// Metadata associated with the connection in the form of an object with string values (max 255 chars).
        /// Maximum of 10 metadata properties allowed.
        /// </summary>
        [JsonProperty("metadata")]
        public dynamic Metadata { get; set; }

        /// <inheritdoc cref="SelfServiceSsoConnectionConfigOptions"/>
        [JsonProperty("options")]
        public SelfServiceSsoConnectionConfigOptions Options { get; set; }
    }
    
    /// <summary>
    /// The connection's options (depend on the connection strategy)
    /// </summary>
    public class SelfServiceSsoConnectionConfigOptions {
        
        /// <summary>
        /// URL for the icon. Must use HTTPS.
        /// </summary>
        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }
        
        /// <summary>
        /// List of domain_aliases that can be authenticated in the Identity Provider
        /// </summary>
        [JsonProperty("domain_aliases")]
        public string[] DomainAliases { get; set; }
    
        /// <inheritdoc cref="SelfServiceSsoConnectionConfigIdpInitiated"/>>
        [JsonProperty("idpinitiated")]
        public SelfServiceSsoConnectionConfigIdpInitiated IdpInitiated { get; set; }
    }

    /// <summary>
    /// Allows IdP-initiated login
    /// </summary>
    public class SelfServiceSsoConnectionConfigIdpInitiated
    {
        /// <summary>
        /// Enables IdP-initiated login for this connection
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }
        
        /// <summary>
        /// Default application client_id user is redirected to after validated SAML response
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <inheritdoc cref="Auth0.ManagementApi.Models.SelfServiceProfiles.ClientProtocol" />
        [JsonProperty("client_protocol")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ClientProtocol ClientProtocol { get; set; }
        
        /// <summary>
        /// Query string options to customize the behaviour for OpenID Connect when idpinitiated.client_protocol
        /// is oauth2. Allowed parameters: redirect_uri, scope, response_type.
        /// For example, redirect_uri=https://jwt.io&scope=openid email&response_type=token
        /// </summary>
        [JsonProperty("client_authorizequery")]
        public string ClientAuthorizeQuery { get; set; }
    }

    /// <summary>
    /// The protocol used to connect to the default application
    /// </summary>
    public enum ClientProtocol
    {
        [EnumMember(Value = "samlp")]
        Samlp,
        
        [EnumMember(Value = "wsfed")]
        Wsfed,
        
        [EnumMember(Value = "oauth2")]
        Oauth2
    }
}