using Newtonsoft.Json;

namespace Auth0.Core
{

    /// <summary>
    /// Describes a 3rd party account for a given <see cref="User"/>.
    /// </summary>
    /// <remarks>
    /// A single <see cref="User"/> may be linked to multiple 3rd party accounts. This object defines the details of one of those accounts.
    /// </remarks>
    [JsonObject]
    public class Identity
    {

        /// <summary>
        /// The token that can be used to call the <see cref="Provider"/>'s API to get more information about the user.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// The name of the connection for the identity.
        /// </summary>
        /// <remarks>
        /// Sometimes, this is the same as the connection, but not always.
        /// </remarks>
        [JsonProperty("connection")]
        public string Connection { get; set; }

        /// <summary>
        /// Indicates whether this is a social identity.
        /// </summary>
        [JsonProperty("isSocial")]
        public bool? IsSocial { get; set; }

        /// <summary>
        /// The type of identity provider.
        /// </summary>
        [JsonProperty("provider")]
        public string Provider { get; set; }

        /// <summary>
        /// The user's identifier.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        
    }
}