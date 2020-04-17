using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a Passwordless email response.
    /// </summary>
    public class PasswordlessEmailResponse
    {
        /// <summary>
        /// Identifier of this request.
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }

        /// <summary>
        /// Email to which the request was sent.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Whether the email address has been verified (true) or has not been verified (false).
        /// </summary>
        [JsonProperty("email_verified")]
        public bool? EmailVerified { get; set; }
    }
}