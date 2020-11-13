using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents configuration of refresh tokens for a client.
    /// </summary>
    public class RefreshToken
    {
        /// <summary>
        /// Refresh token rotation type
        /// </summary>
        [JsonProperty("rotation_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RefreshTokenRotationType RotationType { get; set; }

        /// <summary>
        /// Refresh token expiration type
        /// </summary>
        [JsonProperty("expiration_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RefreshTokenExpirationType ExpirationType { get; set; }

        /// <summary>
        /// Period in seconds where the previous refresh token can be exchanged without triggering breach detection
        /// </summary>
        [JsonProperty("leeway")]
        public int? Leeway { get; set; }

        /// <summary>
        /// Period (in seconds) for which refresh tokens will remain valid
        /// </summary>
        [JsonProperty("token_lifetime")]
        public int? TokenLifetime { get; set; }

        /// <summary>
        /// Prevents tokens from having a set lifetime when true (takes precedence over token_lifetime values)
        /// </summary>
        [JsonProperty("infinite_token_lifetime")]
        public bool? InfiniteTokenLifetime { get; set; }

        /// <summary>
        /// Period (in seconds) for which refresh tokens will remain valid without use
        /// </summary>
        [JsonProperty("idle_token_lifetime")]
        public int? IdleTokenLifetime { get; set; }

        /// <summary>
        /// Prevents tokens from expiring without use when true (takes precedence over idle_token_lifetime values)
        /// </summary>
        [JsonProperty("infinite_idle_token_lifetime")]
        public bool? InfiniteIdleTokenLifetime { get; set; }
    }
}
