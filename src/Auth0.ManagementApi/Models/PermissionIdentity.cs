using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents the properties of a permission that give it its unique identity.
    /// </summary>
    public class PermissionIdentity
    {
        /// <summary>
        /// The resource server that the permission is attached to.
        /// </summary>
        [JsonProperty("resource_server_identifier")]
        public string Identifier { get; set; }

        /// <summary>
        /// The name of the permission.
        /// </summary>
        [JsonProperty("permission_name")]
        public string Name { get; set; }
    }
}