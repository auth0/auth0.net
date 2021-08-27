using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions
{
    /// <summary>
    /// Represents an action in Auth0
    /// </summary>
    public class Action : ActionBase
    {
        /// <summary>
        /// The unique ID of the action.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The build status of this action.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// The version of the action that is currently deployed.
        /// </summary>
        [JsonProperty("deployed_version")]
        public ActionVersion DeployedVersion { get; set; }

        /// <summary>
        /// True if all of an Action's contents have been deployed.
        /// </summary>
        [JsonProperty("all_changes_deployed")]
        public bool AllChangesDeployed { get; set; }

        /// <summary>
        /// The time when this action was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The time when this action was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// The list of triggers that this action supports.
        /// </summary>
        [JsonProperty("supported_triggers")]
        public IList<ActionSupportedTrigger> SupportedTriggers { get; set; }
    }
}