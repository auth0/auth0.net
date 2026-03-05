using System.Text.Json.Serialization;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Prompts;

[Serializable]
public record UpdateAculRequestContent
{
    /// <summary>
    /// Rendering mode
    /// </summary>
    [Optional]
    [JsonPropertyName("rendering_mode")]
    public AculRenderingModeEnum? RenderingMode { get; set; }

    [Optional]
    [JsonPropertyName("context_configuration")]
    public IEnumerable<AculContextConfigurationItem>? ContextConfiguration { get; set; }

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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
