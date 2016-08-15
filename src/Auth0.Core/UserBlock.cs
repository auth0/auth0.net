using Newtonsoft.Json;

namespace Auth0.Core
{
    /// <summary>
    /// Represents a user block
    /// </summary>
    public class UserBlock
    {
        /// <summary>
        /// The identifier of the user
        /// </summary>
        /// <remarks>
        /// Can be the user's email address, username or phone number
        /// </remarks>
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        /// <summary>
        /// The blocked IP address
        /// </summary>
        [JsonProperty("ip")]
        public string IpAddress { get; set; }
    }
}