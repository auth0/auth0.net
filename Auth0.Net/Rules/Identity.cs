using Newtonsoft.Json;

namespace Auth0.Rules
{

    /// <summary>
    /// This is used when the user associates one account with a new one (e.g.: Google and Facebook different accounts, same person).
    /// </summary>
    [JsonObject]
    public partial class Identity
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("provider")]
        public string Provider { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("connection")]
        public string Connection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("isSocial")]
        public bool IsSocial { get; set; }
    }
}