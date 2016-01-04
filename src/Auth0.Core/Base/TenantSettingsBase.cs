using Auth0.Core;
using Newtonsoft.Json;

namespace Auth0.Core
{

    /// <summary>
    /// 
    /// </summary>
    public class TenantSettingsBase
    {

        /// <summary>
        /// An <see cref="TenantErrorPage"/> object containing the settings for the error page.
        /// </summary>
        [JsonProperty("error_page")]
        public TenantErrorPage ErrorPage { get; set; }

        /// <summary>
        /// The friendly name of the tenant.
        /// </summary>
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }

        /// <summary>
        /// The URL of the tenant logo (recommended size: 150x150).
        /// </summary>
        [JsonProperty("picture_url")]
        public string PictureUrl { get; set; }

        /// <summary>
        /// User support email.
        /// </summary>
        [JsonProperty("support_email")]
        public string SupportEmail { get; set; }

        /// <summary>
        /// User support URL.
        /// </summary>
        [JsonProperty("support_url")]
        public string SupportUrl { get; set; }

    }

}