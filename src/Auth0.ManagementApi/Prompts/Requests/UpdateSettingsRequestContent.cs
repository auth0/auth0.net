using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateSettingsRequestContent
{
    [Optional]
    [JsonPropertyName("universal_login_experience")]
    public UniversalLoginExperienceEnum? UniversalLoginExperience { get; set; }

    /// <summary>
    /// Whether identifier first is enabled or not
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("identifier_first")]
    public Optional<bool?> IdentifierFirst { get; set; }

    /// <summary>
    /// Use WebAuthn with Device Biometrics as the first authentication factor
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("webauthn_platform_first_factor")]
    public Optional<bool?> WebauthnPlatformFirstFactor { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
