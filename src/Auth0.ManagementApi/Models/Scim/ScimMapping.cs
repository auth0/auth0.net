using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents the mapping between SCIM and Auth0
    /// </summary>
    public class ScimMapping
    {
        /// <summary>
        /// The field location in the auth0 schema
        /// </summary>
        [JsonProperty("auth0")]
        public string Auth0 { get; set; }
        
        /// <summary>
        /// The field location in the SCIM schema
        /// </summary>
        [JsonProperty("scim")]
        public string Scim { get; set; }
    }
}