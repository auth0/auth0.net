using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.EventStreams;

[Serializable]
public record ListEventStreamDeliveriesRequestParameters
{
    /// <summary>
    /// Comma-separated list of statuses by which to filter
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Statuses { get; set; }

    /// <summary>
    /// Comma-separated list of event types by which to filter
    /// </summary>
    [JsonIgnore]
    public Optional<string?> EventTypes { get; set; }

    /// <summary>
    /// An RFC-3339 date-time for redelivery start, inclusive. Does not allow sub-second precision.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> DateFrom { get; set; }

    /// <summary>
    /// An RFC-3339 date-time for redelivery end, exclusive. Does not allow sub-second precision.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> DateTo { get; set; }

    /// <summary>
    /// Optional Id from which to start selection.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> From { get; set; }

    /// <summary>
    /// Number of results per page. Defaults to 50.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> Take { get; set; } = 50;

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
