using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record FormFieldFileConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("multiple")]
    public bool? Multiple { get; set; }

    [Optional]
    [JsonPropertyName("storage")]
    public FormFieldFileConfigStorage? Storage { get; set; }

    [Optional]
    [JsonPropertyName("categories")]
    public IEnumerable<FormFieldFileConfigCategoryEnum>? Categories { get; set; }

    [Optional]
    [JsonPropertyName("extensions")]
    public IEnumerable<string>? Extensions { get; set; }

    [Optional]
    [JsonPropertyName("maxSize")]
    public int? MaxSize { get; set; }

    [Optional]
    [JsonPropertyName("maxFiles")]
    public int? MaxFiles { get; set; }

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
