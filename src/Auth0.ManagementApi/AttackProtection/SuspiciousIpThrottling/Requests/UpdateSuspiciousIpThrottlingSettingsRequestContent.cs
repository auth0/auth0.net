using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.AttackProtection;

[Serializable]
public record UpdateSuspiciousIpThrottlingSettingsRequestContent
{
    /// <summary>
    /// Whether or not suspicious IP throttling attack protections are active.
    /// </summary>
    [Optional]
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Action to take when a suspicious IP throttling threshold is violated.
    ///           Possible values: <c>block</c>, <c>admin_notification</c>.
    /// </summary>
    [Optional]
    [JsonPropertyName("shields")]
    public IEnumerable<SuspiciousIpThrottlingShieldsEnum>? Shields { get; set; }

    [Optional]
    [JsonPropertyName("allowlist")]
    public IEnumerable<string>? Allowlist { get; set; }

    [Optional]
    [JsonPropertyName("stage")]
    public SuspiciousIpThrottlingStage? Stage { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
