using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record EventStreamEventBridgeResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the event stream.
    /// </summary>
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

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
    public EventStreamEventBridgeDestination? Destination { get; set; }

    [Optional]
    [JsonPropertyName("status")]
    public EventStreamStatusEnum? Status { get; set; }

    /// <summary>
    /// Timestamp when the event stream was created.
    /// </summary>
    [Optional]
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Timestamp when the event stream was last updated.
    /// </summary>
    [Optional]
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

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
