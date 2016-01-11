using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request to unlink a secondary user account from a primary user account.
    /// </summary>
    public class UnlinkUserRequest
    {
        /// <summary>
        /// The access token for the primary user account
        /// </summary>
        [JsonProperty("access_token")]
        public string Token { get; set; }

        /// <summary>
        /// The ID of the secondary user account.
        /// </summary>
        /// <remarks>
        /// Should be in the format provider|id
        /// </remarks>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}