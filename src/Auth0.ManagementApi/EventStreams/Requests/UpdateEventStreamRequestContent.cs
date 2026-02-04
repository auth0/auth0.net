using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateEventStreamRequestContent
{
    /// <summary>
    /// Name of the event stream.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// List of event types subscribed to in this stream.
    /// </summary>
    [Optional]
    [JsonPropertyName("subscriptions")]
    public IEnumerable<EventStreamSubscription>? Subscriptions { get; set; }

    [Optional]
    [JsonPropertyName("destination")]
    public EventStreamDestinationPatch? Destination { get; set; }

    [Optional]
    [JsonPropertyName("status")]
    public EventStreamStatusEnum? Status { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
