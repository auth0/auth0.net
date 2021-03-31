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
        public IDictionary<string, string> Metadata { get; set; }
    }

    public class OrganizationBrandingColors
    {
        [JsonProperty("primary")]
        public string Primary { get; set; }
        [JsonProperty("page_background")]
        public IList<string> PageBackground { get; set; }
    }

    public class OrganizationBranding
    {
        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }
        [JsonProperty("colors")]
        public OrganizationBrandingColors Colors { get; set; }
    }
    public class Organization : OrganizationBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("enabled_connections")]
        public IList<string> EnabledConnections { get; set; }
    }
}
