using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    public class MfaOobTokenResponse : TokenBase
    {
        /// <summary>
        /// The value of the different scopes issued in the token
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// The lifetime (in seconds) of the token
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
