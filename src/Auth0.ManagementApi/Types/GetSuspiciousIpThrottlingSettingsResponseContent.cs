using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record GetSuspiciousIpThrottlingSettingsResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
