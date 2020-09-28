using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents the identity object that can be sent on requests to create an email verification ticket or job.
    /// </summary>
    public class EmailVerificationIdentity
    {
        /// <summary>
        /// Identity provider name of the identity (e.g. google-oauth).
        /// </summary>
        [JsonProperty("provider")]
        public string Provider { get; set; }

        /// <summary>
        /// UserId of the identity to be verified.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}
