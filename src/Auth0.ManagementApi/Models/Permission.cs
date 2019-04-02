using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents a permission.
    /// </summary>
    public class Permission : PermissionIdentity
    {
        /// <summary>
        /// The name of the resource server.
        /// </summary>
        [JsonProperty("resource_server_name")]
        public string ResourceServerName { get; set; }

        /// <summary>
        /// The description of the permission.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}