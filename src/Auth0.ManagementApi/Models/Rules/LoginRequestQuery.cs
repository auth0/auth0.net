using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Rules
{

    /// <summary>
    /// 
    /// </summary>
    [JsonObject]
    public class LoginRequestQuery
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("audience")]
        public string Audience { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("connection")]
        public string Connection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("device")]
        public string Device { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("protocol")]
        public string Protocol { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("prompt")]
        public string Prompt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("response_type")]
        public string ResponseType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sso")]
        public string Sso { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }
    }

}