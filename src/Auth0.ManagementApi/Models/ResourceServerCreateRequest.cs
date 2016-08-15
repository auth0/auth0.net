using Auth0.Core;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Request structure for creating a new resource server
    /// </summary>
    public class ResourceServerCreateRequest : ResourceServer
    {
        /// <summary>
        /// The identifier of the resource server
        /// </summary>
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
    }
}