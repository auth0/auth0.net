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

        /// <summary>
        /// The Nickname of the user.
        /// </summary>
        [JsonProperty("nickname")]
        public string NickName { get; set; }

        /// <summary>
        /// The first name of the user (if available).
        /// </summary>
        /// <remarks>
        /// This is the given_name attribute supplied by the underlying API.
        /// </remarks>
        [JsonProperty("given_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// The full name of the user (e.g.: John Foo). ALWAYS GENERATED.
        /// </summary>
        /// <remarks>
        /// This is the name attribute supplied by the underlying API.
        /// </remarks>
        [JsonProperty("name")]
        public string FullName { get; set; }

        /// <summary>
        /// The last name of the user (if available).
        /// </summary>
        /// <remarks>
        /// This is the family_name attribute supplied by the underlying API.
        /// </remarks>
        [JsonProperty("family_name")]
        public string LastName { get; set; }

        /// <summary>
        /// URL pointing to the user picture (if not available, will use gravatar.com with the email). ALWAYS GENERATED
        /// </summary>
        [JsonProperty("picture")]
        public string Picture { get; set; }
    }

}