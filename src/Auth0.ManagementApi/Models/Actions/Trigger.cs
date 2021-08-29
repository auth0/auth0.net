using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions
{
    /// <summary>
    /// Represents a Trigger in Auth0
    /// </summary>
    public class Trigger
    {
        /// <summary>
        /// The actions extensibility point.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Runtimes supported by this trigger.
        /// </summary>
        [JsonProperty("runtimes")]
        public IList<string> Runtimes { get; set; }

        /// <summary>
        /// Runtime that will be used when none is specified when creating an action.
        /// </summary>
        [JsonProperty("default_runtime")]
        public string DefaultRuntime { get; set; }

        /// <summary>
        /// The version of a trigger. v1, v2, etc.
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }

        /// <summary>
        /// The trigger's status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}