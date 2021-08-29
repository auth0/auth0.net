using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions
{
    public class ActionExecution
    {
        /// <summary>
        /// Identifies a specific execution.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The actions extensibility point.
        /// </summary>
        [JsonProperty("trigger_id")]
        public string TriggerId { get; set; }

        /// <summary>
        /// The overall status of an execution.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Captures the results of a single action being executed.
        /// </summary>
        [JsonProperty("results")]
        public IList<ActionExecutionResult> Results { get; set; }

        /// <summary>
        /// The time that the execution was started.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The time that the execution finished executing.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}