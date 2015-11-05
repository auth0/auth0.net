using Newtonsoft.Json;

namespace Auth0.Core
{

    /// <summary>
    /// 
    /// </summary>
    public class Identity
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("connection")]
        public string Connection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("provider")]
        public string Provider { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("isSocial")]
        public bool IsSocial { get; set; }
    }
}