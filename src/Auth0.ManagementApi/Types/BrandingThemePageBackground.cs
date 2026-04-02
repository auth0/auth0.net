using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record BrandingThemePageBackground : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Background color
    /// </summary>
    [JsonPropertyName("background_color")]
    public required string BackgroundColor { get; set; }

    /// <summary>
    /// Background image url
    /// </summary>
    [JsonPropertyName("background_image_url")]
    public required string BackgroundImageUrl { get; set; }

    [JsonPropertyName("page_layout")]
    public required BrandingThemePageBackgroundPageLayoutEnum PageLayout { get; set; }

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
