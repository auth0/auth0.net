using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record FlowActionHttpSendRequestParams : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("connection_id")]
    public string? ConnectionId { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }

    [Optional]
    [JsonPropertyName("method")]
    public FlowActionHttpSendRequestParamsMethod? Method { get; set; }

    [Optional]
    [JsonPropertyName("headers")]
    public Dictionary<string, object?>? Headers { get; set; }

    [Optional]
    [JsonPropertyName("basic")]
    public FlowActionHttpSendRequestParamsBasicAuth? Basic { get; set; }

    [Optional]
    [JsonPropertyName("params")]
    public Dictionary<
        string,
        FlowActionHttpSendRequestParamsQueryParamsValue?
    >? Params { get; set; }

    [Optional]
    [JsonPropertyName("payload")]
    public FlowActionHttpSendRequestParamsPayload? Payload { get; set; }

    [Optional]
    [JsonPropertyName("content_type")]
    public FlowActionHttpSendRequestParamsContentType? ContentType { get; set; }

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
