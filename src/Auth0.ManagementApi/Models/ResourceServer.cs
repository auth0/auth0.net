using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents a resource server
    /// </summary>
    public class ResourceServer : ResourceServerBase
    {
        /// <summary>
        /// The unique id of the resource server
        /// </summary>
        /// <remarks>
        /// Use this id to retrieve or delete a resource server
        /// </remarks>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The identifier of the resource server
        /// </summary>
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
    }
}