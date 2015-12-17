using Newtonsoft.Json;

namespace Auth0.Core
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
        /// A set of URLs that represents valid origins for CORS.
        /// </summary>
        [JsonProperty("allowed_origins")]
        public string[] AllowedOrigins { get; set; }

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


        [JsonProperty("resource_servers")]
        public ResourceServer[] ResourceServers { get; set; }

        /// <summary>
        /// True to use Auth0 instead of the IdP to do Single Sign On, false otherwise.
        /// </summary>
        [JsonProperty("sso")]
        public bool? Sso { get; set; }
    }
}