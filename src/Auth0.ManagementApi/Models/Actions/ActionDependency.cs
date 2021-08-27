using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions
{
    /// <summary>
    /// Represent an npm dependency for an action or an action's version.
    /// </summary>
    public class ActionDependency
    {
        /// <summary>
        /// The name of the npm module, e.g. 'lodash'
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The version of the npm module, e.g. '4.17.1'
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}