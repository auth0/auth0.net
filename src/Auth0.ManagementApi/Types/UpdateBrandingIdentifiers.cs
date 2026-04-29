using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Identifier input display settings.
/// </summary>
[Serializable]
public record UpdateBrandingIdentifiers : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("login_display")]
    public UpdateBrandingLoginDisplayEnum? LoginDisplay { get; set; }

    /// <summary>
    /// Whether OTP autocomplete (autocomplete="one-time-code") is enabled.
    /// </summary>
    [Optional]
    [JsonPropertyName("otp_autocomplete")]
    public bool? OtpAutocomplete { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("phone_display")]
    public Optional<UpdateBrandingPhoneDisplay?> PhoneDisplay { get; set; }

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
