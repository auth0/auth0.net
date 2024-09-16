using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class ScimConfigurationUpdateRequest
    {
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
    }
}