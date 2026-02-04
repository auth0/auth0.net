using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Branding.Phone;

[Serializable]
public record ListPhoneTemplatesRequestParameters
{
    /// <summary>
    /// Whether the template is enabled (false) or disabled (true).
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> Disabled { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
