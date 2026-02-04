using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record BrandingThemeColors : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Base Focus Color
    /// </summary>
    [Optional]
    [JsonPropertyName("base_focus_color")]
    public string? BaseFocusColor { get; set; }

    /// <summary>
    /// Base Hover Color
    /// </summary>
    [Optional]
    [JsonPropertyName("base_hover_color")]
    public string? BaseHoverColor { get; set; }

    /// <summary>
    /// Body text
    /// </summary>
    [JsonPropertyName("body_text")]
    public required string BodyText { get; set; }

    [Optional]
    [JsonPropertyName("captcha_widget_theme")]
    public BrandingThemeColorsCaptchaWidgetThemeEnum? CaptchaWidgetTheme { get; set; }

    /// <summary>
    /// Error
    /// </summary>
    [JsonPropertyName("error")]
    public required string Error { get; set; }

    /// <summary>
    /// Header
    /// </summary>
    [JsonPropertyName("header")]
    public required string Header { get; set; }

    /// <summary>
    /// Icons
    /// </summary>
    [JsonPropertyName("icons")]
    public required string Icons { get; set; }

    /// <summary>
    /// Input background
    /// </summary>
    [JsonPropertyName("input_background")]
    public required string InputBackground { get; set; }

    /// <summary>
    /// Input border
    /// </summary>
    [JsonPropertyName("input_border")]
    public required string InputBorder { get; set; }

    /// <summary>
    /// Input filled text
    /// </summary>
    [JsonPropertyName("input_filled_text")]
    public required string InputFilledText { get; set; }

    /// <summary>
    /// Input labels & placeholders
    /// </summary>
    [JsonPropertyName("input_labels_placeholders")]
    public required string InputLabelsPlaceholders { get; set; }

    /// <summary>
    /// Links & focused components
    /// </summary>
    [JsonPropertyName("links_focused_components")]
    public required string LinksFocusedComponents { get; set; }

    /// <summary>
    /// Primary button
    /// </summary>
    [JsonPropertyName("primary_button")]
    public required string PrimaryButton { get; set; }

    /// <summary>
    /// Primary button label
    /// </summary>
    [JsonPropertyName("primary_button_label")]
    public required string PrimaryButtonLabel { get; set; }

    /// <summary>
    /// Read only background
    /// </summary>
    [Optional]
    [JsonPropertyName("read_only_background")]
    public string? ReadOnlyBackground { get; set; }

    /// <summary>
    /// Secondary button border
    /// </summary>
    [JsonPropertyName("secondary_button_border")]
    public required string SecondaryButtonBorder { get; set; }

    /// <summary>
    /// Secondary button label
    /// </summary>
    [JsonPropertyName("secondary_button_label")]
    public required string SecondaryButtonLabel { get; set; }

    /// <summary>
    /// Success
    /// </summary>
    [JsonPropertyName("success")]
    public required string Success { get; set; }

    /// <summary>
    /// Widget background
    /// </summary>
    [JsonPropertyName("widget_background")]
    public required string WidgetBackground { get; set; }

    /// <summary>
    /// Widget border
    /// </summary>
    [JsonPropertyName("widget_border")]
    public required string WidgetBorder { get; set; }

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
