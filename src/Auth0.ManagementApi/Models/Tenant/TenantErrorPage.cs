using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Tenant error page customization.
    /// </summary>
    public class TenantErrorPage
    {
        /// <summary>
        /// Replace default error page with custom HTML (Liquid syntax is supported).
        /// </summary>
        [JsonProperty("html")]
        public string Html { get; set; }

        /// <summary>
        /// True to show link to log as part of the default error page, false otherwise (default: true).
        /// </summary>
        [JsonProperty("show_log_link")]
        public bool ShowLogLink { get; set; }

        /// <summary>
        /// Redirect to specified url instead of show the default error page.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}