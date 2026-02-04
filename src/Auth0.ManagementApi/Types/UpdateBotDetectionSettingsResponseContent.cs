using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateBotDetectionSettingsResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("bot_detection_level")]
    public BotDetectionLevelEnum? BotDetectionLevel { get; set; }

    [Optional]
    [JsonPropertyName("challenge_password_policy")]
    public BotDetectionChallengePolicyPasswordFlowEnum? ChallengePasswordPolicy { get; set; }

    [Optional]
    [JsonPropertyName("challenge_passwordless_policy")]
    public BotDetectionChallengePolicyPasswordlessFlowEnum? ChallengePasswordlessPolicy { get; set; }

    [Optional]
    [JsonPropertyName("challenge_password_reset_policy")]
    public BotDetectionChallengePolicyPasswordResetFlowEnum? ChallengePasswordResetPolicy { get; set; }

    [Optional]
    [JsonPropertyName("allowlist")]
    public IEnumerable<string>? Allowlist { get; set; }

    [Optional]
    [JsonPropertyName("monitoring_mode_enabled")]
    public bool? MonitoringModeEnabled { get; set; }

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
