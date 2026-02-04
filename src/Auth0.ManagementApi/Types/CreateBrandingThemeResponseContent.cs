using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateBrandingThemeResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("borders")]
    public required BrandingThemeBorders Borders { get; set; }

    [JsonPropertyName("colors")]
    public required BrandingThemeColors Colors { get; set; }

    /// <summary>
    /// Display Name
    /// </summary>
    [JsonPropertyName("displayName")]
    public required string DisplayName { get; set; }

    [JsonPropertyName("fonts")]
    public required BrandingThemeFonts Fonts { get; set; }

    [JsonPropertyName("page_background")]
    public required BrandingThemePageBackground PageBackground { get; set; }

    /// <summary>
    /// Theme Id
    /// </summary>
    [JsonPropertyName("themeId")]
    public required string ThemeId { get; set; }

    [JsonPropertyName("widget")]
    public required BrandingThemeWidget Widget { get; set; }

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
