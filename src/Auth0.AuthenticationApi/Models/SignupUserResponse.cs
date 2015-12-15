using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents the response from signing up a new user.
    /// </summary>
    public class SignupUserResponse
    {
        /// <summary>
        /// Gets or sets the identifier of the response..
        /// </summary>
        [JsonProperty("Id")]
        public string Id { get; set; }

        /// <summary>
        /// Indicates whether the email has been verified..
        /// </summary>
        /// <value><c>true</c> if the email is verified; otherwise, <c>false</c>.</value>
        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; }

        /// <summary>
        /// The email address of the new user.
        /// </summary>
        [JsonProperty("Email")]
        public string Email { get; set; }

        /// <summary>
        /// The username of the user.
        /// </summary>
        [JsonProperty("username")]
        public object Username { get; set; }
    }
}