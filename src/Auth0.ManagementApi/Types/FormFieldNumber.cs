using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record FormFieldNumber : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("category")]
    public string Category { get; set; } = "FIELD";

    [JsonPropertyName("type")]
    public string Type { get; set; } = "NUMBER";

    [Optional]
    [JsonPropertyName("config")]
    public FormFieldNumberConfig? Config { get; set; }

    [Optional]
    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [Optional]
    [JsonPropertyName("hint")]
    public string? Hint { get; set; }

    [Optional]
    [JsonPropertyName("required")]
    public bool? Required { get; set; }

    [Optional]
    [JsonPropertyName("sensitive")]
    public bool? Sensitive { get; set; }

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
