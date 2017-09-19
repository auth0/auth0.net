using Auth0.Core;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// 
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
        /// Gets or sets the user's password. This is mandatory on non-SMS connections.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

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

        /// <summary>
        /// Gets or sets whether the user's email change must be verified. True if it must be verified, otherwise false.
        /// </summary>
        [JsonProperty("verify_email")]
        public bool? VerifyEmail { get; set; }
    }
}