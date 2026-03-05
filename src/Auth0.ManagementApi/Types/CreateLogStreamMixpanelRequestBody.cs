using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateLogStreamMixpanelRequestBody : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// log stream name
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("type")]
    public required LogStreamMixpanelEnum Type { get; set; }

    /// <summary>
    /// True for priority log streams, false for non-priority
    /// </summary>
    [Optional]
    [JsonPropertyName("isPriority")]
    public bool? IsPriority { get; set; }

    /// <summary>
    /// Only logs events matching these filters will be delivered by the stream. If omitted or empty, all events will be delivered.
    /// </summary>
    [Optional]
    [JsonPropertyName("filters")]
    public IEnumerable<LogStreamFilter>? Filters { get; set; }

    [Optional]
    [JsonPropertyName("pii_config")]
    public LogStreamPiiConfig? PiiConfig { get; set; }

    [JsonPropertyName("sink")]
    public required LogStreamMixpanelSink Sink { get; set; }

    /// <summary>
    /// The optional datetime (ISO 8601) to start streaming logs from
    /// </summary>
    [Optional]
    [JsonPropertyName("startFrom")]
    public string? StartFrom { get; set; }

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
