using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions
{
    public abstract class ActionBase
    {
        /// <summary>
        /// The name of an action.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The source code of the action.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// The list of third party npm modules, and their versions, that this action depends on.
        /// </summary>
        [JsonProperty("dependencies")]
        public IList<ActionDependency> Dependencies { get; set; }

        /// <summary>
        /// The Node runtime. For example: node12, defaults to node12
        /// </summary>
        [JsonProperty("runtime")]
        public string Runtime { get; set; }

        /// <summary>
        /// The list of secrets that are included in an action or a version of an action.
        /// </summary>
        [JsonProperty("secrets")]
        public IList<ActionSecret> Secrets { get; set; }
    }
}