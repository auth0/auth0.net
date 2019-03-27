using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// </summary>
    public class JwtConfiguration
    {
        /// <summary>
        /// True if the client secret is base64 encoded, false otherwise. Defaults to true.
        /// </summary>
        [JsonProperty("secret_encoded")]
        public bool? IsSecretEncoded { get; set; }

        /// <summary>
        /// The amount of time (in seconds) that the token will be valid after being issued. (affects 'exp' claim)
        /// </summary>
        [JsonProperty("lifetime_in_seconds")]
        public int? LifetimeInSeconds { get; set; }

        /// <summary>
        /// The scopes for the JWT.
        /// </summary>
        [JsonProperty("scopes")]
        public Scopes Scopes { get; set; }

        /// <summary>
        /// The algorithm used to sign the JsonWebToken. Possible values are 'HS256' or 'RS256'.
        /// </summary>
        [JsonProperty("alg")]
        public string SigningAlgorithm { get; set; }
    }
}