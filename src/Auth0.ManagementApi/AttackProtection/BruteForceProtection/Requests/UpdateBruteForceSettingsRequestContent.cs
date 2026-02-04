using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

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
    ///         Possible values: <code>block</code>, <code>user_notification</code>.
    /// </summary>
    [Optional]
    [JsonPropertyName("shields")]
    public IEnumerable<UpdateBruteForceSettingsRequestContentShieldsItem>? Shields { get; set; }

    /// <summary>
    /// List of trusted IP addresses that will not have attack protection enforced against them.
    /// </summary>
    [Optional]
    [JsonPropertyName("allowlist")]
    public IEnumerable<string>? Allowlist { get; set; }

    /// <summary>
    /// Account Lockout: Determines whether or not IP address is used when counting failed attempts.
    ///           Possible values: <code>count_per_identifier_and_ip</code>, <code>count_per_identifier</code>.
    /// </summary>
    [Optional]
    [JsonPropertyName("mode")]
    public UpdateBruteForceSettingsRequestContentMode? Mode { get; set; }

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
