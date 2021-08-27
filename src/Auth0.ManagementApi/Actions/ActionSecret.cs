using System;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Actions
{
    public class ActionSecret
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}