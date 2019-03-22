using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class CreateGuardianEnrollmentTicketRequest
    {
        /// <summary>
        /// Alternate email to which the enrollment email will be sent. Optional - by default, the email will be sent to the
        /// user's default address
        /// </summary>
        [JsonProperty("email")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Indicates whether an email must be sent to the user to start the enrollment.
        /// </summary>
        [JsonProperty("send_mail")]
        public bool? MustSendMail { get; set; }

        /// <summary>
        /// The User ID for the enrollment ticket.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}