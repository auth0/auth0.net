using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateEventStreamRedeliveryResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
