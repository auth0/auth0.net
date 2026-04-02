using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Branding;

[Serializable]
public record CreateBrandingThemeRequestContent
{
    [JsonPropertyName("borders")]
    public required BrandingThemeBorders Borders { get; set; }

    [JsonPropertyName("colors")]
    public required BrandingThemeColors Colors { get; set; }

    /// <summary>
    /// Display Name
    /// </summary>
    [Optional]
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("fonts")]
    public required BrandingThemeFonts Fonts { get; set; }

    [JsonPropertyName("page_background")]
    public required BrandingThemePageBackground PageBackground { get; set; }

    [JsonPropertyName("widget")]
    public required BrandingThemeWidget Widget { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
