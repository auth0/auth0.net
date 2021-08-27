using System;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Actions
{
    public class ActionExecutionResult
    {
        [JsonProperty("action_name")]
        public string ActionName { get; set; }

        [JsonProperty("started_at")]
        public DateTime StartedAt { get; set; }

        [JsonProperty("ended_at")]
        public DateTime EndedAt { get; set; }
    }
}