using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models.Ciba
{
    /// <summary>
    /// Contains information about the client initiated backchannel authorization (CIBA) response.
    /// </summary>
    public class ClientInitiatedBackchannelAuthorizationResponse
    {
        /// <summary>
        /// Unique id of the authorization request. Can be used further to poll for /oauth/token.
        /// </summary>
        [JsonProperty("auth_req_id")]
        public string AuthRequestId { get; set; }
        
        /// <summary>
        /// Tells you how many seconds we have until the authentication request expires. 
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        
        /// <summary>
        /// Tells how many seconds you must leave between poll requests.
        /// </summary>
        [JsonProperty("interval")]
        public int Interval { get; set; }
    }
}