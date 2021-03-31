using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        [JsonProperty("branding")]
        public OrganizationBranding Branding { get; set; }
        [JsonProperty("metadata")]
        public dynamic Metadata { get; set; }
    }
}
