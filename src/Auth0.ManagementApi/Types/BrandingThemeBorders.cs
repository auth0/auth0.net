using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record BrandingThemeBorders : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Button border radius
    /// </summary>
    [JsonPropertyName("button_border_radius")]
    public required double ButtonBorderRadius { get; set; }

    /// <summary>
    /// Button border weight
    /// </summary>
    [JsonPropertyName("button_border_weight")]
    public required double ButtonBorderWeight { get; set; }

    [JsonPropertyName("buttons_style")]
    public required BrandingThemeBordersButtonsStyleEnum ButtonsStyle { get; set; }

    /// <summary>
    /// Input border radius
    /// </summary>
    [JsonPropertyName("input_border_radius")]
    public required double InputBorderRadius { get; set; }

    /// <summary>
    /// Input border weight
    /// </summary>
    [JsonPropertyName("input_border_weight")]
    public required double InputBorderWeight { get; set; }

    [JsonPropertyName("inputs_style")]
    public required BrandingThemeBordersInputsStyleEnum InputsStyle { get; set; }

    /// <summary>
    /// Show widget shadow
    /// </summary>
    [JsonPropertyName("show_widget_shadow")]
    public required bool ShowWidgetShadow { get; set; }

    /// <summary>
    /// Widget border weight
    /// </summary>
    [JsonPropertyName("widget_border_weight")]
    public required double WidgetBorderWeight { get; set; }

    /// <summary>
    /// Widget corner radius
    /// </summary>
    [JsonPropertyName("widget_corner_radius")]
    public required double WidgetCornerRadius { get; set; }

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
