using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record GetBruteForceSettingsResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
    public IEnumerable<GetBruteForceSettingsResponseContentShieldsItem>? Shields { get; set; }

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
    public GetBruteForceSettingsResponseContentMode? Mode { get; set; }

    /// <summary>
    /// Maximum number of unsuccessful attempts.
    /// </summary>
    [Optional]
    [JsonPropertyName("max_attempts")]
    public int? MaxAttempts { get; set; }

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
