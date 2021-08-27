using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions
{
    /// <summary>
    /// Represents a version for an action in Auth0
    /// </summary>
    public class ActionVersion
    {
        /// <summary>
        /// The unique id of an action version.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The source code of this specific version of the action.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// The Node runtime. For example: `node12`
        /// </summary>
        [JsonProperty("runtime")]
        public string Runtime { get; set; }

        /// <summary>
        /// The index of this version in list of versions for the action.
        /// </summary>
        [JsonProperty("number")]
        public int Number { get; set; }

        /// <summary>
        /// Indicates if this specific version is the currently one deployed.
        /// </summary>
        [JsonProperty("deployed")]
        public bool? Deployed { get; set; }

        /// <summary>
        /// The list of third party npm modules, and their versions, that this specific version depends on.
        /// </summary>
        [JsonProperty("dependencies")]
        public IList<ActionDependency> Dependencies { get; set; }

        /// <summary>
        /// The build status of this specific version.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// The time when this version was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The time when a version was updated. Versions are never updated externally. Only Auth0 will update an action version as it is being built.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// The action to which this version belongs.
        /// </summary>
        [JsonProperty("action")]
        public Action Action { get; set; }

        /// <summary>
        /// The list of secrets that are included in the version.
        /// </summary>
        [JsonProperty("secrets")]
        public IList<ActionDependency> Secrets { get; set; }

        /// <summary>
        /// Any errors that occurred while the version was being built.
        /// </summary>
        [JsonProperty("errors")]
        public IList<ActionError> Errors { get; set; }
    }
}