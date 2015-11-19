using Newtonsoft.Json;

namespace Auth0.Core.Models
{
    public class Job
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("connection")]
        public string Connection { get; set; }

    }
}