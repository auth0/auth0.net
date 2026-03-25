using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

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
    ///       Possible values: <c>block</c>, <c>user_notification</c>, <c>admin_notification</c>.
    /// </summary>
    [Optional]
    [JsonPropertyName("shields")]
    public IEnumerable<BreachedPasswordDetectionShieldsEnum>? Shields { get; set; }

    /// <summary>
    /// When "admin_notification" is enabled, determines how often email notifications are sent.
    ///         Possible values: <c>immediately</c>, <c>daily</c>, <c>weekly</c>, <c>monthly</c>.
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
