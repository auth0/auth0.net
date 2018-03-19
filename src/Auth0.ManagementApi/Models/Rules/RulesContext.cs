using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Rules
{

    /// <summary>
    /// 
    /// </summary>
    [JsonObject]
    public class RulesContext
    {

        /// <summary>
        /// The client id of the application the user is logging in to.
        /// </summary>
        [JsonProperty("clientID")]
        public string ClientId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("clientName")]
        public string ClientName { get; set; }

        /// <summary>
        /// The name of the connection used to authenticate the user (e.g.: twitter or some-google-apps-domain)
        /// </summary>
        [JsonProperty("connection")]
        public string Connection { get; set; }

        /// <summary>
        /// The type of connection. 
        /// </summary>
        /// <remarks>
        /// For social connection connectionStrategy === connection. For enterprise connections, the strategy will be waad (Windows Azure AD), 
        /// ad (Active Directory/LDAP), auth0 (database connections), etc.
        /// </remarks>
        [JsonProperty("connectionStrategy")]
        public string ConnectionStrategy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("jwtConfiguration")]
        public dynamic JwtConfiguration { get; set; }

        /// <summary>
        /// The authentication protocol. 
        /// </summary>
        /// <remarks>
        /// Possible values: oidc-basic-profile (most used, web based login), oidc-implicit-profile (used on mobile devices and single page apps), 
        /// oauth2-resource-owner (user/password login typically used on database connections), samlp (SAML protocol used on SaaS apps), 
        /// wsfed (WS-Federation used on Microsoft products like Office365), wstrust-usernamemixed (WS-trust user/password login used on CRM and Office365), 
        /// and delegation (when calling the Delegation endpoint).
        /// </remarks>
        [JsonProperty("protocol")]
        public string Protocol { get; set; }

        /// <summary>
        /// An object containing useful information of the request.
        /// </summary>
        [JsonProperty("request")]
        public LoginRequest LoginRequest { get; set; }

        /// <summary>
        /// An object that controls the behavior of the SAML and WS-Fed endpoints. Useful for advanced claims mapping and token enrichment (only available for samlp and wsfed protocol).
        /// </summary>
        [JsonProperty("samlConfiguration")]
        public dynamic SamlConfiguration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sso")]
        public RulesContextSsoConfiguration SingleSignOn { get; set; }

        /// <summary>
        /// An object containing specific user stats, like stats.loginsCount.
        /// </summary>
        [JsonProperty("stats")]
        public RulesContextStats Stats { get; set; }

    }

}
