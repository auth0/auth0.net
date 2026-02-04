using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateLogStreamRequestContent
{
    /// <summary>
    /// log stream name
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Optional]
    [JsonPropertyName("status")]
    public LogStreamStatusEnum? Status { get; set; }

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
    public LogStreamSinkPatch? Sink { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
