using Newtonsoft.Json;

namespace Auth0.Rules
{

    /// <summary>
    /// An object containing useful information of the request.
    /// </summary>
    [JsonObject]
    public partial class Request
    {

        /// <summary>
        /// The QueryString of the login transaction sent by the application.
        /// </summary>
        [JsonProperty("query")]
        public Query Query { get; set; }

        /// <summary>
        /// The body of the POST request on login transactions used on oauth2-resource-owner or wstrust-usernamemixed protocols.
        /// </summary>
        [JsonProperty("body")]
        public dynamic Body { get; set; }

        /// <summary>
        /// The user-agent of the client that is trying to log in.
        /// </summary>
        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }

        /// <summary>
        /// The originating IP address of the user trying to log in.
        /// </summary>
        [JsonProperty("ip")]
        public string Ip { get; set; }
    }
}