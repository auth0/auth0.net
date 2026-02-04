using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record BrandingThemeFonts : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("body_text")]
    public required BrandingThemeFontBodyText BodyText { get; set; }

    [JsonPropertyName("buttons_text")]
    public required BrandingThemeFontButtonsText ButtonsText { get; set; }

    /// <summary>
    /// Font URL
    /// </summary>
    [JsonPropertyName("font_url")]
    public required string FontUrl { get; set; }

    [JsonPropertyName("input_labels")]
    public required BrandingThemeFontInputLabels InputLabels { get; set; }

    [JsonPropertyName("links")]
    public required BrandingThemeFontLinks Links { get; set; }

    [JsonPropertyName("links_style")]
    public required BrandingThemeFontLinksStyleEnum LinksStyle { get; set; }

    /// <summary>
    /// Reference text size
    /// </summary>
    [JsonPropertyName("reference_text_size")]
    public required double ReferenceTextSize { get; set; }

    [JsonPropertyName("subtitle")]
    public required BrandingThemeFontSubtitle Subtitle { get; set; }

    [JsonPropertyName("title")]
    public required BrandingThemeFontTitle Title { get; set; }

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
