using System.Text.Json.Serialization;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Branding.Phone;

[Serializable]
public record CreateBrandingPhoneProviderRequestContent
{
    [JsonPropertyName("name")]
    public required PhoneProviderNameEnum Name { get; set; }

    /// <summary>
    /// Whether the provider is enabled (false) or disabled (true).
    /// </summary>
    [Optional]
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    [Optional]
    [JsonPropertyName("configuration")]
    public PhoneProviderConfiguration? Configuration { get; set; }

    [JsonPropertyName("credentials")]
    public required PhoneProviderCredentials Credentials { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
