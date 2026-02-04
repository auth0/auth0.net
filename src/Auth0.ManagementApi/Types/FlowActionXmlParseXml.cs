using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record FlowActionXmlParseXml : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [Optional]
    [JsonPropertyName("alias")]
    public string? Alias { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; } = "XML";

    [JsonPropertyName("action")]
    public string Action { get; set; } = "PARSE_XML";

    [Optional]
    [JsonPropertyName("allow_failure")]
    public bool? AllowFailure { get; set; }

    [Optional]
    [JsonPropertyName("mask_output")]
    public bool? MaskOutput { get; set; }

    [JsonPropertyName("params")]
    public required FlowActionXmlParseXmlParams Params { get; set; }

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
