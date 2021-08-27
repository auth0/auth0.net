using System;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Actions
{
    public class TriggerBinding
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("trigger_id")]
        public string TriggerId { get; set; }

        [JsonProperty("action")]
        public Action Action { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
    }
}