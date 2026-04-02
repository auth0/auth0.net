using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.AttackProtection;

[Serializable]
public record UpdateBotDetectionSettingsRequestContent
{
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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
