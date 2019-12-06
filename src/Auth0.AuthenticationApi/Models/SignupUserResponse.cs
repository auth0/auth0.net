using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents the response from signing up a new user.
    /// </summary>
    public class SignupUserResponse
    {
        /// <summary>
        /// The email address of the new user.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Indicates whether the email has been verified..
        /// </summary>
        /// <value><c>true</c> if the email is verified; otherwise, <c>false</c>.</value>
        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the response..
        /// </summary>
        /// <remarks>
        /// The server can return `_id`, `id` or `user_id` depending on various factors.
        /// For convenience we expose it here as just one.
        /// </remarks>
        public string Id
        {
            get { return _id ?? id ?? user_id; }
            set { _id = value; }
        }

        [JsonProperty("_id")]
        private string _id;        // Standard connection

        [JsonProperty("id")]
        private string id;         // Custom connection

        [JsonProperty("user_id")]
        private string user_id;    // Custom connection external

        /// <summary>
        /// Contains user meta data.
        /// </summary>
        [JsonProperty("user_metadata")]
        public dynamic UserMetadata { get; set; }

        /// <summary>
        /// The username of the user.
        /// </summary>
        [JsonProperty("username")]
        public object Username { get; set; }
    }
}