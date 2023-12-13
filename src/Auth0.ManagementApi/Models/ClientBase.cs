using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Base class for clients.
    /// </summary>
    public abstract class ClientBase
    {
        /// <summary>
        /// Gets or sets the addons which are associated with the client.
        /// </summary>
        [JsonProperty("addons")]
        public Addons AddOns { get; set; }

        /// <summary>
        /// Ids of clients that will be allowed to perform delegation requests. Clients that will be allowed to make delegation request.
        /// </summary>
        /// <remarks>
        /// By default, all your clients will be allowed. This field allows you to specify specific clients.
        /// </remarks>
        [JsonProperty("allowed_clients")]
        public string[] AllowedClients { get; set; }

        /// <summary>
        /// The URLs that Auth0 can redirect to after logout
        /// </summary>
        [JsonProperty("allowed_logout_urls")]
        public string[] AllowedLogoutUrls { get; set; }

        /// <summary>
        /// A set of URLs that represents valid origins for CORS.
        /// </summary>
        [JsonProperty("allowed_origins")]
        public string[] AllowedOrigins { get; set; }

        /// <summary>
        /// A set of allowed origins for use with Cross-Origin Authentication and web message response mode.
        /// </summary>
        [JsonProperty("web_origins")]
        public string[] WebOrigins { get; set; }

        /// <summary>
        /// The default login initiation endpoint.
        /// </summary>
        [JsonProperty("initiate_login_uri")]
        public string InitiateLoginUri { get; set; }

        /// <summary>
        /// A set of URLs that are valid to call back from Auth0 when authenticating users.
        /// </summary>
        [JsonProperty("callbacks")]
        public string[] Callbacks { get; set; }

        /// <summary>
        /// List of audiences for SAML protocol.
        /// </summary>
        [JsonProperty("client_aliases")]
        public string[] ClientAliases { get; set; }

        /// <summary>
        /// Metadata associated with this client
        /// </summary>
        [JsonProperty("client_metadata")]
        public dynamic ClientMetaData { get; set; }

        /// <summary>
        /// The secret used to sign tokens for the client.
        /// </summary>
        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// True if the custom login page is to be used, false otherwise. Defaults to true.
        /// </summary>
        [JsonProperty("custom_login_page_on")]
        public bool? IsCustomLoginPageOn { get; set; }

        /// <summary>
        /// Whether this client a first party client or not
        /// </summary>
        [JsonProperty("is_first_party")]
        public bool? IsFirstParty { get; set; }

        /// <summary>
        /// The content (HTML, CSS, JS) of the custom login page.
        /// </summary>
        [JsonProperty("custom_login_page")]
        public string CustomLoginPage { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("custom_login_page_preview")]
        public string CustomLoginPagePreview { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("encryption_key")]
        public EncryptionKey EncryptionKey { get; set; }

        /// <summary>
        /// Form template for WS-Federation protocol.
        /// </summary>
        [JsonProperty("form_template")]
        public string FormTemplate { get; set; }

        /// <summary>
        /// A set of grant types that the client is authorized to use
        /// </summary>
        [JsonProperty("grant_types")]
        public string[] GrantTypes { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("jwt_configuration")]
        public JwtConfiguration JwtConfiguration { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("mobile")]
        public Mobile Mobile { get; set; }

        /// <summary>
        /// The name of the client. Must contain at least one character. Does not allow '&lt;' or '&gt;'.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The description of the client. Max character count is 140
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The logo_uri of the client. The URL of the logo to display for the application,
        /// if none is set the default badge for this type of application will be shown.
        /// Recommended size is 150x150 pixels
        /// </summary>
        [JsonProperty("logo_uri")]
        public string LogoUri { get; set; }

        /// <summary>
        /// Indicates whether this client will conform to strict OIDC specifications.
        /// </summary>
        [JsonProperty("oidc_conformant")]
        public bool? OidcConformant { get; set; }

        [JsonProperty("oidc_logout")]
        public OidcLogoutConfig OidcLogout { get; set; }

        /// <summary>
        /// A list of resource servers (APIs) that the client is authorized to request access tokens for, using the Client Credentials exchange.
        /// </summary>
        /// <remarks>
        /// This is a legacy structure. If you want to grant Resource Server (API) access to clients, please use <see cref="ManagementApiClient.ClientGrants"/> instead.
        /// </remarks>
        [JsonProperty("resource_servers")]
        public ClientResourceServerAssociation[] ResourceServers { get; set; }

        /// <summary>
        /// True to use Auth0 instead of the IdP to do Single Sign On, false otherwise.
        /// </summary>
        [JsonProperty("sso")]
        public bool? Sso { get; set; }

        /// <summary>
        /// Configuration of refresh tokens for a client
        /// </summary>
        [JsonProperty("refresh_token")]
        public RefreshToken RefreshToken { get; set; }

        /// <summary>
        /// Organization usage for a client
        /// </summary>
        [JsonProperty("organization_usage")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrganizationUsage? OrganizationUsage { get; set; }

        /// <summary>
        /// Defines how to proceed during an authentication transaction when organization usage is required.
        /// </summary>
        [JsonProperty("organization_require_behavior")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrganizationRequireBehavior? OrganizationRequireBehavior { get; set; }

        /// <summary>
        /// Whether this client can be used to make cross-origin authentication requests (true) or it is not allowed to make such requests (false).
        /// </summary>
        [JsonProperty("cross_origin_authentication")]
        public bool? CrossOriginAuthentication { get; set; }
        
        /// <summary>
        /// Makes the use of Pushed Authorization Requests mandatory for this client.
        /// </summary>
        [JsonProperty("require_pushed_authorization_requests")]
        public bool? RequirePushedAuthorizationRequests { get; set; }
    }

}

