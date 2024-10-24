using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// The valid authorization_detail definition
    /// </summary>
    public class ResourceServerAuthorizationDetail
    {
        /// <summary>
        /// The authorization_detail type identifier
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } 
    }
}