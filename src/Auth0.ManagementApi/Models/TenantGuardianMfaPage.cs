using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Guardian page customization.
    /// </summary>
    public class TenantGuardianMfaPage
    {
        /// <summary>
        /// true to use the custom html for Guardian page, false otherwise (default: false).
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Replace default Guardian page with custom HTML (Liquid syntax is supported).
        /// </summary>
        [JsonProperty("html")]
        public string Html { get; set; }
    }
}
