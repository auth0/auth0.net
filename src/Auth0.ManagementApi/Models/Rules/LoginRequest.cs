using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Rules
{
    /// <summary>
    /// Represents details of the Login request from the app to Auth0, including QueryString and User Location.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// The body of the POST request on login transactions used on oauth2-resource-owner or wstrust-usernamemixed protocols.
        /// </summary>
        [JsonProperty("body")]
        public dynamic Body { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("geoip")]
        public LoginRequestGeography Geography { get; set; }

        /// <summary>
        /// The originating IP address of the user trying to log in.
        /// </summary>
        [JsonProperty("ip")]
        public string IpAddress { get; set; }

        /// <summary>
        /// The QueryString of the login transaction sent by the application.
        /// </summary>
        [JsonProperty("query")]
        public LoginRequestQuery Query { get; set; }

        /// <summary>
        /// The user-agent of the client that is trying to log in.
        /// </summary>
        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }

    }

}