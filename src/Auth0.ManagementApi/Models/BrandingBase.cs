using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class BrandingBase
    {
        /// <summary>
        /// Custom color settings.
        /// </summary>
        [JsonProperty("colors")]
        public BrandingColors Colors { get; set; }

        /// <summary>
        /// URL for the favicon. Must use HTTPS.
        /// </summary>
        [JsonProperty("favicon_url")]
        public string FaviconUrl { get; set; }

        /// <summary>
        /// URL for the logo. Must use HTTPS.
        /// </summary>
        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }

        /// <summary>
        /// Custom font settings.
        /// </summary>
        [JsonProperty("font")]
        public BrandingFont Font{ get; set; }
    }
}