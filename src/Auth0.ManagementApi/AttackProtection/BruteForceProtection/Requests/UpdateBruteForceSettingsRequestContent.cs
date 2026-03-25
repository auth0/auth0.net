using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.AttackProtection;

[Serializable]
public record UpdateBruteForceSettingsRequestContent
{
    /// <summary>
    /// Whether or not brute force attack protections are active.
    /// </summary>
    [Optional]
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Action to take when a brute force protection threshold is violated.
    ///         Possible values: <c>block</c>, <c>user_notification</c>.
    /// </summary>
    [Optional]
    [JsonPropertyName("shields")]
    public IEnumerable<BruteForceProtectionShieldsEnum>? Shields { get; set; }

    /// <summary>
    /// List of trusted IP addresses that will not have attack protection enforced against them.
    /// </summary>
    [Optional]
    [JsonPropertyName("allowlist")]
    public IEnumerable<string>? Allowlist { get; set; }

    [Optional]
    [JsonPropertyName("mode")]
    public BruteForceProtectionModeEnum? Mode { get; set; }

    /// <summary>
    /// Maximum number of unsuccessful attempts.
    /// </summary>
    [Optional]
    [JsonPropertyName("max_attempts")]
    public int? MaxAttempts { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
