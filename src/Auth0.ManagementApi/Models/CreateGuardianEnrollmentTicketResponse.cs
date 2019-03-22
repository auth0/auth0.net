using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class CreateGuardianEnrollmentTicketResponse
    {
        /// <summary>
        /// The ticket ID used to identify the enrollment.
        /// </summary>
        [JsonProperty("ticket_id")]
        public string TicketId { get; set; }

        /// <summary>
        /// The URL you can use to start enrollment.
        /// </summary>
        [JsonProperty("ticket_url")]
        public string TicketUrl { get; set; }
    }
}