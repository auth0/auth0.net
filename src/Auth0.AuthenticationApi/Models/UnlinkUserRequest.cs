using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request to unlink a secondary user account from a primary user account.
    /// </summary>
    public class UnlinkUserRequest
    {
        /// <summary>
        /// Access token for the primary user account.
        /// </summary>
        [JsonProperty("access_token")]
        public string Token { get; set; }

        /// <summary>
        /// ID of the secondary user account in the format `provider|id`.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}