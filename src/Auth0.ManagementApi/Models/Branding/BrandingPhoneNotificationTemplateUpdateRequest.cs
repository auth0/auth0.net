using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class BrandingPhoneNotificationTemplateUpdateRequest
    {
        [JsonProperty("content")]
        public Content Content { get; set; }
        
        /// <summary>
        /// Whether the template is enabled (false) or disabled (true).
        /// </summary>
        [JsonProperty("disabled")]
        public bool? Disabled { get; set; }
    }
}