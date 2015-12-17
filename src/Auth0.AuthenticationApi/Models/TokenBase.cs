using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Base class for all authentication tokens.
    /// </summary>
    public abstract class TokenBase
    {
        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the type of the token.
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
}