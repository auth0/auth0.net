using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Users
{
    public class AuthenticationMethodsUpdateRequest
    {
        /// <summary>
        /// The type of the authentication method
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// A human-readable label to identify the authentication method.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("totp_secret")]
        public string TOTPSecret { get; set; }

        /// <summary>
        /// Applies to phone authentication methods only. The destination phone number used to send verification codes via text and voice.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Applies to email authentication methods only. The email address used to send verification messages.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// The preferred authentication method for phone authentication method.
        /// </summary>
        [JsonProperty("preferred_authentication_method")]
        public string PreferredAuthenticationMethod { get; set; }
    }
}

