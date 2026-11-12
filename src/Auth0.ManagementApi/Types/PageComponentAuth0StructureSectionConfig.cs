using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record PageComponentAuth0StructureSectionConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Heading displayed at the top of the section.
    /// </summary>
    [Optional]
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Optional description displayed below the title.
    /// </summary>
    [Optional]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("variant")]
    public required PageComponentAuth0StructureSectionVariantEnum Variant { get; set; }

    /// <summary>
    /// Components to render inside the section.
    /// </summary>
    [JsonPropertyName("children")]
    public IEnumerable<PageComponentNoChildren> Children { get; set; } =
        new List<PageComponentNoChildren>();

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
