using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Branding.Phone;

[Serializable]
public record ListBrandingPhoneProvidersRequestParameters
{
    /// <summary>
    /// Whether the provider is enabled (false) or disabled (true).
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> Disabled { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
