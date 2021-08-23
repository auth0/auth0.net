using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents the request to create a <see cref="User"/>.
    /// </summary>
    public class UserCreateRequest : UserBase
    {
        /// <summary>
        /// Gets or sets the connection the user belongs to.
        /// </summary>
        [JsonProperty("connection")]
        public string Connection { get; set; }
        
        /// <summary>
        /// Gets or sets the (optional) id of the user
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the user's password. This is mandatory only for auth0 connection strategy.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets whether the user's email change must be verified. True if it must be verified, otherwise false.
        /// </summary>
        [JsonProperty("verify_email")]
        public bool? VerifyEmail { get; set; }
    }
}
