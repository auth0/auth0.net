using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models;

public class BrandingPhoneNotificationTemplateCreateRequest
{
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public BrandingPhoneNotificationTemplateType? Type { get; set; }
        
    /// <summary>
    /// Whether the template is enabled (false) or disabled (true).
    /// </summary>
    [JsonProperty("disabled")]
    public bool? Disabled { get; set; }
        
    [JsonProperty("content")]
    public Content Content { get; set; }
}