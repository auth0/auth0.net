using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents an SCIM Configuration
    /// </summary>
    public class ScimConfiguration
    {
        /// <summary>
        /// The connection's identifier
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }
        
        /// <summary>
        /// The connection's identifier
        /// </summary>
        [JsonProperty("connection_name")]
        public string ConnectionName { get; set; }
        
        /// <summary>
        /// The connection's strategy
        /// </summary>
        [JsonProperty("strategy")]
        public string Strategy  { get; set; }
        
        /// <summary>
        /// The tenant's name
        /// </summary>
        [JsonProperty("tenant_name")]
        public string TenantName { get; set; }
        
        /// <summary>
        /// User ID attribute for generating unique user ids
        /// </summary>
        [JsonProperty("user_id_attribute")]
        public string UserIdAttribute { get; set; }
        
        /// <summary>
        /// The mapping between auth0 and SCIM
        /// </summary>
        [JsonProperty("mapping")]
        public List<ScimMapping> Mapping { get; set; }
        
        /// <summary>
        /// The Date Time SCIM Configuration was created
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
        
        /// <summary>
        /// The Date Time SCIM Configuration was last updated
        /// </summary>
        [JsonProperty("updated_on")]
        public string UpdatedOn { get; set; }
    }
}