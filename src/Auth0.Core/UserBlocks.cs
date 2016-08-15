using Newtonsoft.Json;

namespace Auth0.Core
{
    /// <summary>
    /// Contains a list of blocks for a user
    /// </summary>
    public class UserBlocks
    {
        /// <summary>
        /// An array of the blocks for the user
        /// </summary>
        [JsonProperty("blocked_for")]
        public UserBlock[] BlockedFor { get; set; }
    }
}