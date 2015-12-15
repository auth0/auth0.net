using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents an access token.
    /// </summary>
    public class AccessToken : TokenBase
    {
        /// <summary>
        /// Gets or sets the identifier token.
        /// </summary>
        [JsonProperty("id_token")]
        public string IdToken { get; set; }
    }
}