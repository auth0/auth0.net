using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class AccountLinkResponseProfileData
    {

        /// <summary>
        /// The email address for the profile.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Indicates whether the <see cref="Email"/> is verified.
        /// </summary>
        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; }

    }

}