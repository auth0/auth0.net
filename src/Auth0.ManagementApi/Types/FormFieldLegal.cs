using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record FormFieldLegal : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("category")]
    public required FormComponentCategoryFieldConst Category { get; set; }

    [JsonPropertyName("type")]
    public required FormFieldTypeLegalConst Type { get; set; }

    [Optional]
    [JsonPropertyName("config")]
    public FormFieldLegalConfig? Config { get; set; }

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
