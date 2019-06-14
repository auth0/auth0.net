using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Change Password page customization.
    /// </summary>
    public class TenantChangePassword
    {
        /// <summary>
        /// true to use the custom change password html, false otherwise (default: false).
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Replace default change password page with custom HTML (Liquid syntax is supported).
        /// </summary>
        [JsonProperty("html")]
        public string Html { get; set; }
    }
}
