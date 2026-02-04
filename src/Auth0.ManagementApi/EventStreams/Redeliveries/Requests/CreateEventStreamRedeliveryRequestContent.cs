using System.Text.Json.Serialization;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.EventStreams;

[Serializable]
public record CreateEventStreamRedeliveryRequestContent
{
    /// <summary>
    /// An RFC-3339 date-time for redelivery start, inclusive. Does not allow sub-second precision.
    /// </summary>
    [Optional]
    [JsonPropertyName("date_from")]
    public DateTime? DateFrom { get; set; }

    /// <summary>
    /// An RFC-3339 date-time for redelivery end, exclusive. Does not allow sub-second precision.
    /// </summary>
    [Optional]
    [JsonPropertyName("date_to")]
    public DateTime? DateTo { get; set; }

    /// <summary>
    /// Filter by status
    /// </summary>
    [Optional]
    [JsonPropertyName("statuses")]
    public IEnumerable<string>? Statuses { get; set; }

    /// <summary>
    /// Filter by event type
    /// </summary>
    [Optional]
    [JsonPropertyName("event_types")]
    public IEnumerable<EventStreamEventTypeEnum>? EventTypes { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
