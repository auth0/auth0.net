using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents the request to update a <see cref="User"/>.
    /// </summary>
    public class UserUpdateRequest : UserBase
    {
        /// <summary>
        /// Gets or sets the connection the user belongs to.
        /// </summary>
        [JsonProperty("connection")]
        public string Connection { get; set; }

        /// <summary>
        /// Gets or sets the user's password. This is mandatory on non-SMS connections.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets whether the user's email change must be verified. True if it must be verified, otherwise false.
        /// </summary>
        [JsonProperty("verify_email")]
        public bool? VerifyEmail { get; set; }

        /// <summary>
        /// Gets or sets whether the user's password change needs to be verified via email. True if it must be verified, otherwise false.
        /// </summary>
        [JsonProperty("verify_password")]
        public bool? VerifyPassword { get; set; }

        /// <summary>
        /// Gets or sets whether the user's phone number change needs to be verified via email. True if it must be verified, otherwise false.
        /// </summary>
        [JsonProperty("verify_phone_number")]
        public bool? VerifyPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the Auth0 clientID. Only useful when updating the email.
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
    }
}