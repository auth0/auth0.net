using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record FlowActionAuth0SendRequestParams : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("connection_id")]
    public required string ConnectionId { get; set; }

    [JsonPropertyName("pathname")]
    public required string Pathname { get; set; }

    [Optional]
    [JsonPropertyName("method")]
    public FlowActionAuth0SendRequestParamsMethod? Method { get; set; }

    [Optional]
    [JsonPropertyName("headers")]
    public Dictionary<string, object?>? Headers { get; set; }

    [Optional]
    [JsonPropertyName("params")]
    public Dictionary<
        string,
        FlowActionAuth0SendRequestParamsQueryParamsValue?
    >? Params { get; set; }

    [Optional]
    [JsonPropertyName("payload")]
    public FlowActionAuth0SendRequestParamsPayload? Payload { get; set; }

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
