using Newtonsoft.Json;

namespace Auth0.Core.Rules
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

    }

}