using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record ListAculsResponseContentItem : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Tenant ID
    /// </summary>
    [Optional]
    [JsonPropertyName("tenant")]
    public string? Tenant { get; set; }

    /// <summary>
    /// Name of the prompt
    /// </summary>
    [Optional]
    [JsonPropertyName("prompt")]
    public string? Prompt { get; set; }

    /// <summary>
    /// Name of the screen
    /// </summary>
    [Optional]
    [JsonPropertyName("screen")]
    public string? Screen { get; set; }

    /// <summary>
    /// Rendering mode
    /// </summary>
    [Optional]
    [JsonPropertyName("rendering_mode")]
    public AculRenderingModeEnum? RenderingMode { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("context_configuration")]
    public Optional<IEnumerable<AculContextConfigurationItem>?> ContextConfiguration { get; set; }

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
    [Nullable, Optional]
    [JsonPropertyName("head_tags")]
    public Optional<IEnumerable<AculHeadTag>?> HeadTags { get; set; }

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
