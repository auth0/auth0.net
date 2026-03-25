using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record BrandingThemeWidget : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("header_text_alignment")]
    public required BrandingThemeWidgetHeaderTextAlignmentEnum HeaderTextAlignment { get; set; }

    /// <summary>
    /// Logo height
    /// </summary>
    [JsonPropertyName("logo_height")]
    public required double LogoHeight { get; set; }

    [JsonPropertyName("logo_position")]
    public required BrandingThemeWidgetLogoPositionEnum LogoPosition { get; set; }

    /// <summary>
    /// Logo url
    /// </summary>
    [JsonPropertyName("logo_url")]
    public required string LogoUrl { get; set; }

    [JsonPropertyName("social_buttons_layout")]
    public required BrandingThemeWidgetSocialButtonsLayoutEnum SocialButtonsLayout { get; set; }

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
