using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateAculResponseContent : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [Optional]
    [JsonPropertyName("rendering_mode")]
    public AculRenderingModeEnum? RenderingMode { get; set; }

    /// <summary>
    /// Context values to make available
    /// </summary>
    [Optional]
    [JsonPropertyName("context_configuration")]
    public IEnumerable<string>? ContextConfiguration { get; set; }

    /// <summary>
    /// Override Universal Login default head tags
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("default_head_tags_disabled")]
    public Optional<bool?> DefaultHeadTagsDisabled { get; set; }

    /// <summary>
    /// Use page template with ACUL
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("use_page_template")]
    public Optional<bool?> UsePageTemplate { get; set; }

    /// <summary>
    /// An array of head tags
    /// </summary>
    [Optional]
    [JsonPropertyName("head_tags")]
    public IEnumerable<AculHeadTag>? HeadTags { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("filters")]
    public Optional<AculFilters?> Filters { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
