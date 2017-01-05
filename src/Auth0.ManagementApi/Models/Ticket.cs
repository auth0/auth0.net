using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents a ticket. Tickets can be for either email verification or a password change.
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// The URL that represents the ticket.
        /// </summary>
        [JsonProperty("ticket")]
        public string Value { get; set; } 
    }
}