using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.SelfServiceProfiles
{
    public class Branding
    {
        /// <summary>
        /// Logo Url
        /// </summary>
        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }
        
        /// <summary>
        /// Branding Colors
        /// </summary>
        [JsonProperty("colors")]
        public Color Color { get; set; }
    }

    public class Color
    {
        [JsonProperty("primary")]
        public string Primary { get; set; }
    }
}