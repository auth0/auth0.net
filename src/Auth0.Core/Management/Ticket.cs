using Newtonsoft.Json;

namespace Auth0.Core
{
    public class Ticket
    {
        /// <summary>
        /// The URL that represents the ticket.
        /// </summary>
        [JsonProperty("ticket")]
        public string Value { get; set; } 
    }
}