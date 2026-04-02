using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Branding.Phone;

[Serializable]
public record UpdateBrandingPhoneProviderRequestContent
{
    [Optional]
    [JsonPropertyName("name")]
    public PhoneProviderNameEnum? Name { get; set; }

    /// <summary>
    /// Whether the provider is enabled (false) or disabled (true).
    /// </summary>
    [Optional]
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    [Optional]
    [JsonPropertyName("credentials")]
    public PhoneProviderCredentials? Credentials { get; set; }

    [Optional]
    [JsonPropertyName("configuration")]
    public PhoneProviderConfiguration? Configuration { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
