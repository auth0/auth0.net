using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record FlowActionJwtSignJwtParams : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("connection_id")]
    public required string ConnectionId { get; set; }

    [Optional]
    [JsonPropertyName("payload")]
    public Dictionary<string, object?>? Payload { get; set; }

    [Optional]
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [Optional]
    [JsonPropertyName("issuer")]
    public string? Issuer { get; set; }

    [Optional]
    [JsonPropertyName("audience")]
    public string? Audience { get; set; }

    [Optional]
    [JsonPropertyName("expires_in")]
    public string? ExpiresIn { get; set; }

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
