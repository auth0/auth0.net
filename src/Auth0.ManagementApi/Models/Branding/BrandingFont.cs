using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class BrandingFont
    {
        /// <summary>
        /// URL for the custom font. The URL must point to a font file and not a stylesheet. Must use HTTPS.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}