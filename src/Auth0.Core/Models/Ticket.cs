using Newtonsoft.Json;

namespace Auth0.Core.Models
{
    public class Ticket
    {
        [JsonProperty("ticket")]
        public string Value { get; set; } 
    }
}