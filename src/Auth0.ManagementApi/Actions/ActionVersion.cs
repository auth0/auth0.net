using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Actions
{
    public class ActionVersion
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("runtime")]
        public string Runtime { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("deployed")]
        public bool? Deployed { get; set; }

        [JsonProperty("dependencies")]
        public IList<ActionDependency> Dependencies { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("action")]
        public Action Action { get; set; }

        [JsonProperty("secrets")]
        public IList<ActionDependency> Secrets { get; set; }

        [JsonProperty("errors")]
        public IList<ActionError> Errors { get; set; }
    }
}