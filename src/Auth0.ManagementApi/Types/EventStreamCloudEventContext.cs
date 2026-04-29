using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Information about the context in which the event was produced. This may include things like
/// HTTP request details, client information, connection information, etc.
///
/// Note: This field may not be present on all events, depending on the event type and the
/// context in which it was generated.
/// </summary>
[Serializable]
public record EventStreamCloudEventContext : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("client")]
    public EventStreamCloudEventContextClient? Client { get; set; }

    [Optional]
    [JsonPropertyName("connection")]
    public EventStreamCloudEventContextConnection? Connection { get; set; }

    [Optional]
    [JsonPropertyName("request")]
    public EventStreamCloudEventContextRequest? Request { get; set; }

    [JsonPropertyName("tenant")]
    public required EventStreamCloudEventContextTenant Tenant { get; set; }

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
