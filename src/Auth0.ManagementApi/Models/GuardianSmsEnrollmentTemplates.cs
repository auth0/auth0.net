using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class GuardianSmsEnrollmentTemplates
    {
        /// <summary>
        /// Message sent to the user when they are invited to enroll with a phone number.
        /// </summary>
        [JsonProperty("enrollment_message")]
        public string EnrollmentMessage { get; set; }

        /// <summary>
        /// Message sent to the user when they are prompted to verify their account.
        /// </summary>
        [JsonProperty("verification_message")]
        public string VerificationMessage { get; set; }
    }
}