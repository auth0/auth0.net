using Newtonsoft.Json;

namespace Auth0.Core.Models
{
    public class Identity
    {
        /// <summary>
        /// The name of the connection for the identity.
        /// </summary>
        [JsonProperty("connection")]
        public string Connection { get; set; }

        /// <summary>
        /// The user's identifier.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// The type of identity provider.
        /// </summary>
        [JsonProperty("provider")]
        public string Provider { get; set; }

        /// <summary>
        /// Indicates whether this is a social identity.
        /// </summary>
        [JsonProperty("isSocial")]
        public bool? IsSocial { get; set; }
    }
}