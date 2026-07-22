using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record BrandingThemeIdentifiers : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("login_display")]
    public required BrandingThemeIdentifiersLoginDisplayEnum LoginDisplay { get; set; }

    /// <summary>
    /// OTP autocomplete
    /// </summary>
    [JsonPropertyName("otp_autocomplete")]
    public required bool OtpAutocomplete { get; set; }

    [JsonPropertyName("phone_display")]
    public required BrandingThemeIdentifiersPhoneDisplay PhoneDisplay { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
