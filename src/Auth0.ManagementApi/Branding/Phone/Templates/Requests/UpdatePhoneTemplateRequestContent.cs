using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Branding.Phone;

[Serializable]
public record UpdatePhoneTemplateRequestContent
{
    [Optional]
    [JsonPropertyName("content")]
    public PartialPhoneTemplateContent? Content { get; set; }

    /// <summary>
    /// Whether the template is enabled (false) or disabled (true).
    /// </summary>
    [Optional]
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
