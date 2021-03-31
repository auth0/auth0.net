using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationBranding
    {
        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }
        [JsonProperty("colors")]
        public OrganizationBrandingColors Colors { get; set; }
    }
}
