using System;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions
{
    /// <summary>
    /// Captures the results of a single action being executed.
    /// </summary>
    public class ActionExecutionResult
    {
        /// <summary>
        /// The name of the action that was executed.
        /// </summary>
        [JsonProperty("action_name")]
        public string ActionName { get; set; }

        /// <summary>
        /// The time when the action was started.
        /// </summary>
        [JsonProperty("started_at")]
        public DateTime StartedAt { get; set; }

        /// <summary>
        /// The time when the action finished executing.
        /// </summary>
        [JsonProperty("ended_at")]
        public DateTime EndedAt { get; set; }
    }
}