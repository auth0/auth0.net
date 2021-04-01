using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationBranding
    {
        /// <summary>
        /// URL for the logo. Must use HTTPS.
        /// </summary>
        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }

        /// <summary>
        /// Custom color settings.
        /// </summary>
        [JsonProperty("colors")]
        public BrandingColors Colors { get; set; }
    }
}
