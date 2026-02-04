using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateEventStreamWebHookRequestContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonPropertyName("destination")]
    public required EventStreamWebhookDestination Destination { get; set; }

    [Optional]
    [JsonPropertyName("status")]
    public EventStreamStatusEnum? Status { get; set; }

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
