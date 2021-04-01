using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationBase
    {
        /// <summary>
        /// The name of the organization
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The display name of the organization
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        /// <summary>
        /// Organization specific branding settings
        /// </summary>
        [JsonProperty("branding")]
        public OrganizationBranding Branding { get; set; }
        /// <summary>
        /// Organization specific metadata
        /// </summary>
        [JsonProperty("metadata")]
        public dynamic Metadata { get; set; }
    }
}
