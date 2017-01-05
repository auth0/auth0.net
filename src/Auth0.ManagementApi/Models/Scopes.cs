using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class Scopes
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("users")]
        public ScopeEntry Users { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("users_app_metadata")]
        public ScopeEntry UsersAppMetadata { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("clients")]
        public ScopeEntry Clients { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("client_keys")]
        public ScopeEntry ClientKeys { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("tokens")]
        public ScopeEntry Tokens { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("stats")]
        public ScopeEntry Stats { get; set; }
    }
}