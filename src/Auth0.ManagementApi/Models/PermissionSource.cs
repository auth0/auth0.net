using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents the source of a permission assignment
    /// </summary>
    public class PermissionSource
    {
        /// <summary>
        /// Gets or sets the ID of the source of the permission. Empty for direct assignment.
        /// </summary>
        [JsonProperty("source_id")]
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the source of the permission. Empty for direct assignment.
        /// </summary>
        [JsonProperty("source_name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the permission source (direct assignment or role assignment)
        /// </summary>
        [JsonProperty("source_type")]
        public PermissionSourceType Type { get; set; }
    }
}
