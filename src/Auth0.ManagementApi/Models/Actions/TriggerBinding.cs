using System;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions
{
    /// <summary>
    /// Represents a Trigger Binding in Auth0
    /// </summary>
    public class TriggerBinding
    {
        /// <summary>
        /// The unique ID of this binding.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The actions extensibility point.
        /// </summary>
        [JsonProperty("trigger_id")]
        public string TriggerId { get; set; }

        /// <summary>
        /// The connected action.
        /// </summary>
        [JsonProperty("action")]
        public Action Action { get; set; }

        /// <summary>
        /// The time when the binding was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The time when the binding was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// The name of the binding.
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
    }
}