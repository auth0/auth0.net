using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record LogStreamPiiConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("log_fields")]
    public IEnumerable<LogStreamPiiLogFieldsEnum> LogFields { get; set; } =
        new List<LogStreamPiiLogFieldsEnum>();

    [Optional]
    [JsonPropertyName("method")]
    public LogStreamPiiMethodEnum? Method { get; set; }

    [Optional]
    [JsonPropertyName("algorithm")]
    public LogStreamPiiAlgorithmEnum? Algorithm { get; set; }

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
