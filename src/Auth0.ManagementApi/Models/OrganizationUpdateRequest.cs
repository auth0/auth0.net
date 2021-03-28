using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Requests structure for updating an organization.
    /// </summary>
    public class OrganizationUpdateRequest
    {
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        [JsonProperty("branding")]
        public OrganizationBranding Branding { get; set; }
        [JsonProperty("metadata")]
        public IDictionary<string, string> Metadata { get; set; }
    }
}