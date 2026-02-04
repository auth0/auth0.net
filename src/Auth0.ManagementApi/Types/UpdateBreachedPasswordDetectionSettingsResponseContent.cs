using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateBreachedPasswordDetectionSettingsResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Whether or not breached password detection is active.
    /// </summary>
    [Optional]
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Action to take when a breached password is detected during a login.
    ///       Possible values: <code>block</code>, <code>user_notification</code>, <code>admin_notification</code>.
    /// </summary>
    [Optional]
    [JsonPropertyName("shields")]
    public IEnumerable<BreachedPasswordDetectionShieldsEnum>? Shields { get; set; }

    /// <summary>
    /// When "admin_notification" is enabled, determines how often email notifications are sent.
    ///         Possible values: <code>immediately</code>, <code>daily</code>, <code>weekly</code>, <code>monthly</code>.
    /// </summary>
    [Optional]
    [JsonPropertyName("admin_notification_frequency")]
    public IEnumerable<BreachedPasswordDetectionAdminNotificationFrequencyEnum>? AdminNotificationFrequency { get; set; }

    [Optional]
    [JsonPropertyName("method")]
    public BreachedPasswordDetectionMethodEnum? Method { get; set; }

    [Optional]
    [JsonPropertyName("stage")]
    public BreachedPasswordDetectionStage? Stage { get; set; }

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
