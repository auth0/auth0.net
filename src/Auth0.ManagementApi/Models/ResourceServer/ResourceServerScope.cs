using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Defines a scope for a resource server
    /// </summary>
    public class ResourceServerScope
    {
        /// <summary>
        /// The scope value
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// A user-friendly description of the scope
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}