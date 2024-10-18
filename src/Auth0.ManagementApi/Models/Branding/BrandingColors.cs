using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class BrandingColors
    {
        /// <summary>
        /// Accent color.
        /// </summary>
        [JsonProperty("primary")]
        public string Primary { get; set; }

        /// <summary>
        /// Page Background Color or Gradient.
        /// </summary>
        [JsonProperty("page_background")]
        public string PageBackground { get; set; }
    }
}