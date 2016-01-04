using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request to authenticate with a social provider and return an access token.
    /// </summary>
    public class AccessTokenRequest
    {
        /// <summary>
        /// Gets or sets the client (app) identifier.
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the access token for the social provider.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the type of social provider connection. Can be one of either facebook, google-oauth2, twitter or weibo.
        /// </summary>
        [JsonProperty("connection")]
        public string Connection { get; set; }

        /// <summary>
        /// Gets or sets the requested scope.
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }
    }
}