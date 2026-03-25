using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record LogStreamHttpResponseSchema : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// The id of the log stream
    /// </summary>
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// log stream name
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Optional]
    [JsonPropertyName("status")]
    public LogStreamStatusEnum? Status { get; set; }

    [Optional]
    [JsonPropertyName("type")]
    public LogStreamHttpEnum? Type { get; set; }

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

    [Optional]
    [JsonPropertyName("sink")]
    public LogStreamHttpSink? Sink { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
