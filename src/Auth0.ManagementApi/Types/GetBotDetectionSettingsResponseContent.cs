using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record GetBotDetectionSettingsResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("bot_detection_level")]
    public required BotDetectionLevelEnum BotDetectionLevel { get; set; }

    [JsonPropertyName("challenge_password_policy")]
    public required BotDetectionChallengePolicyPasswordFlowEnum ChallengePasswordPolicy { get; set; }

    [JsonPropertyName("challenge_passwordless_policy")]
    public required BotDetectionChallengePolicyPasswordlessFlowEnum ChallengePasswordlessPolicy { get; set; }

    [JsonPropertyName("challenge_password_reset_policy")]
    public required BotDetectionChallengePolicyPasswordResetFlowEnum ChallengePasswordResetPolicy { get; set; }

    [JsonPropertyName("allowlist")]
    public IEnumerable<string> Allowlist { get; set; } = new List<string>();

    [JsonPropertyName("monitoring_mode_enabled")]
    public required bool MonitoringModeEnabled { get; set; }

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
