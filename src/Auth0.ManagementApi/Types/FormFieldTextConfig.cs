using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record FormFieldTextConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("multiline")]
    public bool? Multiline { get; set; }

    [Optional]
    [JsonPropertyName("default_value")]
    public string? DefaultValue { get; set; }

    [Optional]
    [JsonPropertyName("placeholder")]
    public string? Placeholder { get; set; }

    [Optional]
    [JsonPropertyName("min_length")]
    public int? MinLength { get; set; }

    [Optional]
    [JsonPropertyName("max_length")]
    public int? MaxLength { get; set; }

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
