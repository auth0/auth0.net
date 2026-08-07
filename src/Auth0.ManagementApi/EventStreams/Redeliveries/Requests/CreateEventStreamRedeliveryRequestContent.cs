using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Globalization;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.EventStreams;

[Serializable]
public record CreateEventStreamRedeliveryRequestContent
{
    /// <summary>
    /// An RFC-3339 date-time for redelivery start, inclusive. Does not allow sub-second precision.
    /// </summary>
    [Optional]
    [JsonPropertyName("date_from")]
    [JsonConverter(typeof(RedeliveryDateTimeSerializer))]
    public DateTime? DateFrom { get; set; }

    /// <summary>
    /// An RFC-3339 date-time for redelivery end, exclusive. Does not allow sub-second precision.
    /// </summary>
    [Optional]
    [JsonPropertyName("date_to")]
    [JsonConverter(typeof(RedeliveryDateTimeSerializer))]
    public DateTime? DateTo { get; set; }

    /// <summary>
    /// Filter by status
    /// </summary>
    [Optional]
    [JsonPropertyName("statuses")]
    public IEnumerable<EventStreamDeliveryStatusEnum>? Statuses { get; set; }

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

    private class RedeliveryDateTimeSerializer : JsonConverter<DateTime>
    {
        public override DateTime Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return DateTime.Parse(reader.GetString()!, null, DateTimeStyles.RoundtripKind);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ssK"));
        }
    }
}
