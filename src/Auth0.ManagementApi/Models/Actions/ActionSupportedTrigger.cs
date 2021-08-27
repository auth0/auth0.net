using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions
{
    public class ActionSupportedTrigger
    {
        /// <summary>
        /// The actions extensibility point
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The version of a trigger. v1, v2, etc.
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}