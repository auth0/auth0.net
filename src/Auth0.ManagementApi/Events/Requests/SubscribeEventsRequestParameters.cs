using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record SubscribeEventsRequestParameters
{
    /// <summary>
    /// Opaque token representing position in the stream. If not provided, stream will start from the latest events.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> From { get; set; }

    /// <summary>
    /// RFC-3339 timestamp indicating where to start streaming events from. This should only be used on the initial query when a cursor may not be available. Subsequent requests should use the cursor (from) as it will be more accurate.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> FromTimestamp { get; set; }

    /// <summary>
    /// Event type(s) to listen for. Specify multiple times for multiple types (e.g., ?event_type=user.created&event_type=user.updated). If not provided, all event types will be streamed.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<EventStreamSubscribeEventsEventTypeEnum?> EventType { get; set; } =
        new List<EventStreamSubscribeEventsEventTypeEnum?>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
