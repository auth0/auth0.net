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
        /// The type of application this client represents
        /// </summary>
        [JsonProperty("app_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ClientApplicationType ApplicationType { get; set; }

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
        /// 
        /// </summary>
        [JsonProperty("resource_servers")]
        public ClientResourceServerAssociation[] ResourceServers { get; set; }

        /// <summary>
        /// True to use Auth0 instead of the IdP to do Single Sign On, false otherwise.
        /// </summary>
        [JsonProperty("sso")]
        public bool? Sso { get; set; }

        /// <summary>
        /// Defines the requested authentication method for the token endpoint.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        [JsonProperty("token_endpoint_auth_method")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TokenEndpointAuthMethod TokenEndpointAuthMethod { get; set; }
    }
}

