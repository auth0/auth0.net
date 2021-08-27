using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Actions
{
    /// <summary>
    /// Represents an action in Auth0
    /// </summary>
    public class Action : ActionBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("all_changes_deployed")]
        public bool AllChangesDeployed { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("supported_triggers")]
        public IList<ActionSupportedTrigger> SupportedTriggers { get; set; }
    }
}