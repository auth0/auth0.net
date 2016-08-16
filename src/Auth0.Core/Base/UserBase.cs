using Newtonsoft.Json;

namespace Auth0.Core
{

    /// <summary>
    /// Contains common elements used for both constructing <see cref="User"/>-related requests, and comprising <see cref="User"/>-related responses.
    /// </summary>
    public abstract class UserBase
    {

        /// <summary>
        /// Contains user meta data. The user has read-only access to this.
        /// </summary>
        [JsonProperty("app_metadata")]
        public dynamic AppMetadata { get; set; }

        /// <summary>
        /// Gets or sets the user's email address.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets whether the user's email address is verified.
        /// </summary>
        /// <remarks>
        /// True if the email address is verified, otherwise false.
        /// </remarks>
        [JsonProperty("email_verified")]
        public bool? EmailVerified { get; set; }

        /// <summary>
        /// Gets or sets the user's phone number.
        /// </summary>
        /// <remarks>
        /// This is only valid for users from SMS connections.
        /// </remarks>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Contains user meta data. The user has read/write access to this.
        /// </summary>
        [JsonProperty("user_metadata")]
        public dynamic UserMetadata { get; set; }

        /// <summary>
        /// Gets or sets the user' username.
        /// </summary>
        [JsonProperty("username")]
        public string UserName { get; set; }
    }

}