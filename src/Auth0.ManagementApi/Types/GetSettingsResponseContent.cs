using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record GetSettingsResponseContent : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [Optional]
    [JsonPropertyName("universal_login_experience")]
    public UniversalLoginExperienceEnum? UniversalLoginExperience { get; set; }

    /// <summary>
    /// Whether identifier first is enabled or not
    /// </summary>
    [Optional]
    [JsonPropertyName("identifier_first")]
    public bool? IdentifierFirst { get; set; }

    /// <summary>
    /// Use WebAuthn with Device Biometrics as the first authentication factor
    /// </summary>
    [Optional]
    [JsonPropertyName("webauthn_platform_first_factor")]
    public bool? WebauthnPlatformFirstFactor { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
