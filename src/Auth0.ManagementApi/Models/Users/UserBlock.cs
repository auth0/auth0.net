using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
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
        /// The the connection for which the user is blocked
        /// </summary>
        [JsonProperty("connection")]
        public string Connection { get; set; }

        /// <summary>
        /// The blocked IP address
        /// </summary>
        [JsonProperty("ip")]
        public string IpAddress { get; set; }
    }
}
