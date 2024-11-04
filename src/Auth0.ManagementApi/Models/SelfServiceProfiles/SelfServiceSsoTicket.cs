using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.SelfServiceProfiles
{
    /// <summary>
    /// SSO-access ticket
    /// </summary>
    public class SelfServiceSsoTicket
    {
        /// <summary>
        /// The URL for the created ticket.
        /// </summary>
        [JsonProperty("ticket")]
        public string Ticket { get; set; }
    }
}