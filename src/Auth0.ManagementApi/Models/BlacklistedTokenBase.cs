using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{

    /// <summary>
    /// Base class for blacklisted tokens.
    /// </summary>
    public class BlacklistedTokenBase
    {
        /// <summary>
        /// Gets or sets the JWT's aud claim. The Client identifier of the client for which it was issued.
        /// </summary>
        [JsonProperty("aud")]
        public string Aud { get; set; }

        /// <summary>
        /// Gets or sets the jti of the JWT to be blacklisted.
        /// </summary>
        [JsonProperty("jti")]
        public string Jti { get; set; }        
    }
}