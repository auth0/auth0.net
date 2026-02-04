using System.Text.Json.Serialization;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Branding.Phone;

[Serializable]
public record CreatePhoneTemplateRequestContent
{
    [Optional]
    [JsonPropertyName("type")]
    public PhoneTemplateNotificationTypeEnum? Type { get; set; }

    /// <summary>
    /// Whether the template is enabled (false) or disabled (true).
    /// </summary>
    [Optional]
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    [Optional]
    [JsonPropertyName("content")]
    public PhoneTemplateContent? Content { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
