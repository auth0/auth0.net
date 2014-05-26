using Newtonsoft.Json;

namespace Auth0.Rules
{

    /// <summary>
    /// 
    /// </summary>
    [JsonObject]
    public partial class Query
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("response_type")]
        public string ResponseType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("connection")]
        public string Connection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("redirect_uri ")]
        public string RedirectUri { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }
    }
}