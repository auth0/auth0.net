using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record SetGuardianSettingsResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Determines whether to display the "Remember Me" checkbox on the MFA prompt in Universal Login.
    /// </summary>
    [JsonPropertyName("display_remember_me_checkbox")]
    public required bool DisplayRememberMeCheckbox { get; set; }

    /// <summary>
    /// Determines the default state of the "Remember Me" checkbox on the MFA prompt in Universal Login.
    /// </summary>
    [JsonPropertyName("remember_me_default_value")]
    public required bool RememberMeDefaultValue { get; set; }

    /// <summary>
    /// Duration of inactivity after which the user will be prompted for MFA. Represented as seconds. Minimum duration is 1 hour, maximum is 30 days, and cannot exceed the overall timeout.
    /// </summary>
    [JsonPropertyName("mfa_session_inactivity_timeout")]
    public required int MfaSessionInactivityTimeout { get; set; }

    /// <summary>
    /// Maximum duration after which the user will be prompted for MFA regardless of activity. Represented as seconds. Minimum duration is 1 hour, maximum is 90 days.
    /// </summary>
    [JsonPropertyName("mfa_session_overall_timeout")]
    public required int MfaSessionOverallTimeout { get; set; }

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
