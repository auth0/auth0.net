using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Metadata about a specific attempt to deliver an event
/// </summary>
[Serializable]
public record EventStreamDelivery : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the delivery
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Unique identifier for the event stream.
    /// </summary>
    [JsonPropertyName("event_stream_id")]
    public required string EventStreamId { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; } = "failed";

    [JsonPropertyName("event_type")]
    public required EventStreamDeliveryEventTypeEnum EventType { get; set; }

    /// <summary>
    /// Results of delivery attempts
    /// </summary>
    [JsonPropertyName("attempts")]
    public IEnumerable<EventStreamDeliveryAttempt> Attempts { get; set; } =
        new List<EventStreamDeliveryAttempt>();

    [Optional]
    [JsonPropertyName("event")]
    public EventStreamCloudEvent? Event { get; set; }

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
