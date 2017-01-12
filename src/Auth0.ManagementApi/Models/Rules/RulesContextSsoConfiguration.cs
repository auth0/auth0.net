using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Rules
{

    /// <summary>
    /// 
    /// </summary>
    [JsonObject]
    public class RulesContextSsoConfiguration
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("current_clients")]
        public string[] CurrentClients { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("with_auth0")]
        public bool WithAuth0 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("with_dbconn")]
        public bool WithDatabaseConnection { get; set; }

    }
}
