using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record AculConfigsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("prompt")]
    public required PromptGroupNameEnum Prompt { get; set; }

    [JsonPropertyName("screen")]
    public required ScreenGroupNameEnum Screen { get; set; }

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
