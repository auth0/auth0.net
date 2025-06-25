using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    public class BrandingThemeBase
    {
        /// <summary>
        /// Borders
        /// </summary>
        [JsonProperty("borders")]
        public BrandingThemeBorder Borders { get; set; }
        
        /// <summary>
        /// Colors
        /// </summary>
        [JsonProperty("colors")]
        public BrandingThemeColors Colors { get; set; }
        
        /// <summary>
        /// Display Name
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
        
        /// <summary>
        /// Fonts
        /// </summary>
        [JsonProperty("fonts")]
        public BrandingThemeFonts Fonts { get; set; }
        
        /// <summary>
        /// Page Background
        /// </summary>
        [JsonProperty("page_background")]
        public BrandingThemePageBackground PageBackground { get; set; }
        
        /// <summary>
        /// Widget
        /// </summary>
        [JsonProperty("widget")]
        public BrandingThemeWidget Widget { get; set; }
    }

    public class BrandingThemeBorder
    {
        /// <summary>
        /// Button border radius
        /// </summary>
        [JsonProperty("button_border_radius")]
        public float ButtonBorderRadius { get; set; }
        
        /// <summary>
        /// Button border weight
        /// </summary>
        [JsonProperty("button_border_weight")]
        public float ButtonBorderWeight { get; set; }
        
        /// <summary>
        /// Possible values: [pill, rounded, sharp]
        /// Buttons style
        /// </summary>
        [JsonProperty("buttons_style")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ButtonsStyle ButtonsStyle { get; set; }
        
        /// <summary>
        /// Input border radius
        /// </summary>
        [JsonProperty("input_border_radius")]
        public float InputBorderRadius { get; set; }
        
        /// <summary>
        /// Input border weight
        /// </summary>
        [JsonProperty("input_border_weight")]
        public float InputBorderWeight { get; set; }
        
        /// <summary>
        /// Possible values: [pill, rounded, sharp]
        /// Inputs style
        /// </summary>
        [JsonProperty("inputs_style")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ButtonsStyle InputsStyle { get; set; }
        
        /// <summary>
        /// Show widget shadow
        /// </summary>
        [JsonProperty("show_widget_shadow")]
        public bool? ShowWidgetShadow { get; set; }
        
        /// <summary>
        /// Widget border weight
        /// </summary>
        [JsonProperty("widget_border_weight")]
        public float WidgetBorderWeight { get; set; }
        
        /// <summary>
        /// Widget corner radius
        /// </summary>
        [JsonProperty("widget_corner_radius")]
        public float WidgetCornerRadius { get; set; }
    }

    public class BrandingThemeColors
    {
        /// <summary>
        /// Base Focus Color
        /// </summary>
        [JsonProperty("base_focus_color")]
        public string BaseFocusColor { get; set; }
        
        /// <summary>
        /// Base Hover Color
        /// </summary>
        [JsonProperty("base_hover_color")]
        public string BaseHoverColor { get; set; }
        
        /// <summary>
        /// Body text
        /// </summary>
        [JsonProperty("body_text")]
        public string BodyText { get; set; }
        
        /// <summary>
        /// Captcha Widget Theme
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("captcha_widget_theme")]
        public CaptchaWidgetTheme CaptchaWidgetTheme { get; set; }
        
        /// <summary>
        /// Error
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }
        
        /// <summary>
        /// Header
        /// </summary>
        [JsonProperty("header")]
        public string Header { get; set; }
        
        /// <summary>
        /// Icons
        /// </summary>
        [JsonProperty("icons")]
        public string Icons { get; set; }
        
        /// <summary>
        /// Input background
        /// </summary>
        [JsonProperty("input_background")]
        public string InputBackground { get; set; }
        
        /// <summary>
        /// Input border
        /// </summary>
        [JsonProperty("input_border")]
        public string InputBorder { get; set; }
        
        /// <summary>
        /// Input filled text
        /// </summary>
        [JsonProperty("input_filled_text")]
        public string InputFilledText { get; set; }
        
        /// <summary>
        /// Input labels & placeholders
        /// </summary>
        [JsonProperty("input_labels_placeholders")]
        public string InputLabelsPlaceholders { get; set; }
        
        /// <summary>
        /// Links & focused components
        /// </summary>
        [JsonProperty("links_focused_components")]
        public string LinksFocusedComponents { get; set; }
        
        /// <summary>
        /// Primary button
        /// </summary>
        [JsonProperty("primary_button")]
        public string PrimaryButton { get; set; }
        
        /// <summary>
        /// Primary button label
        /// </summary>
        [JsonProperty("primary_button_label")]
        public string PrimaryButtonLabel { get; set; }
        
        /// <summary>
        /// Secondary button border
        /// </summary>
        [JsonProperty("secondary_button_border")]
        public string SecondaryButtonBorder { get; set; }
        
        /// <summary>
        /// Secondary button label
        /// </summary>
        [JsonProperty("secondary_button_label")]
        public string SecondaryButtonLabel { get; set; }
        
        /// <summary>
        /// Success
        /// </summary>
        [JsonProperty("success")]
        public string Success { get; set; }
        
        /// <summary>
        /// Widget background
        /// </summary>
        [JsonProperty("widget_background")]
        public string WidgetBackground { get; set; }
        
        /// <summary>
        /// Widget border
        /// </summary>
        [JsonProperty("widget_border")]
        public string WidgetBorder { get; set; }
    }

    public class BrandingThemeFonts
    {
        /// <summary>
        /// Body text
        /// </summary>
        [JsonProperty("body_text")]
        public BodyText BodyText { get; set; }
        
        /// <summary>
        /// Body text
        /// </summary>
        [JsonProperty("buttons_text")]
        public ButtonsText ButtonsText { get; set; }
        
        /// <summary>
        /// Font URL
        /// </summary>
        [JsonProperty("font_url")]
        public string FontUrl { get; set; }
        
        /// <summary>
        /// Input Labels
        /// </summary>
        [JsonProperty("input_labels")]
        public InputLabels InputLabels { get; set; }
        
        /// <summary>
        /// Links
        /// </summary>
        [JsonProperty("links")]
        public Links Links { get; set; }
        
        /// <summary>
        /// Links style
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("links_style")]
        public LinksStyle LinksStyle { get; set; }
        
        /// <summary>
        /// Reference text size
        /// </summary>
        [JsonProperty("reference_text_size")]
        public float ReferenceTextSize { get; set; }
        
        /// <summary>
        /// Subtitle
        /// </summary>
        [JsonProperty("subtitle")]
        public Subtitle Subtitle { get; set; }
        
        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public Title Title { get; set; }
    }

    public class BrandingThemePageBackground
    {
        /// <summary>
        /// Background color
        /// </summary>
        [JsonProperty("background_color")]
        public string BackgroundColor { get; set; }
        
        /// <summary>
        /// Background image url
        /// </summary>
        [JsonProperty("background_image_url")]
        public string BackgroundImageUrl { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("page_layout")]
        public PageLayout PageLayout { get; set; }
    }

    public class BrandingThemeWidget
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("header_text_alignment")]
        public HeaderTextAlignment HeaderTextAlignment { get; set; }
        
        /// <summary>
        /// Logo height
        /// </summary>
        [JsonProperty("logo_height")]
        public float LogoHeight { get; set; }
        
        /// <summary>
        /// Logo Position
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("logo_position")]
        public LogoPosition LogoPosition { get; set; }
        
        /// <summary>
        /// Logo url
        /// </summary>
        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }
        
        /// <summary>
        /// Social buttons layout
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("social_buttons_layout")]
        public SocialButtonsLayout SocialButtonsLayout { get; set; }
    }
    
    public class BrandingThemeFontsBase
    {
        [JsonProperty("bold")]
        public bool? Bold { get; set; }
        
        [JsonProperty("size")]
        public float Size { get; set; }
    }
    
    public class BodyText : BrandingThemeFontsBase
    {
    }
    
    public class ButtonsText : BrandingThemeFontsBase
    {
    }
    
    public class InputLabels : BrandingThemeFontsBase
    {
    }
    
    public class Links : BrandingThemeFontsBase
    {
    }
    
    public class Subtitle : BrandingThemeFontsBase
    {
    }
    
    public class Title : BrandingThemeFontsBase
    {
    }
    
    /// <summary>
    /// Buttons Style
    /// </summary>
    public enum ButtonsStyle
    {
        [EnumMember(Value = "pill")]
        Pill,
        
        [EnumMember(Value = "rounded")]
        Rounded,
        
        [EnumMember(Value = "sharp")]
        Sharp,
    }
    
    /// <summary>
    /// Captcha Widget Theme
    /// </summary>
    public enum CaptchaWidgetTheme
    {
        [EnumMember(Value = "auto")]
        Auto,
        
        [EnumMember(Value = "dark")]
        Dark,
        
        [EnumMember(Value = "light")]
        Light,
    }
    
    /// <summary>
    /// Links style
    /// </summary>
    public enum LinksStyle
    {
        [EnumMember(Value = "normal")]
        Normal,
        
        [EnumMember(Value = "underlined")]
        Underlined,
    }
    
    /// <summary>
    /// Page Layout
    /// </summary>
    public enum PageLayout
    {
        [EnumMember(Value = "center")]
        Center,
        
        [EnumMember(Value = "left")]
        Left,
        
        [EnumMember(Value = "right")]
        Right,
    }
    
    /// <summary>
    /// Header text alignment 
    /// </summary>
    public enum HeaderTextAlignment
    {
        [EnumMember(Value = "center")]
        Center,
        
        [EnumMember(Value = "left")]
        Left,
        
        [EnumMember(Value = "right")]
        Right,
    }
    
    /// <summary>
    /// Logo Position 
    /// </summary>
    public enum LogoPosition
    {
        [EnumMember(Value = "center")]
        Center,
        
        [EnumMember(Value = "left")]
        Left,
        
        [EnumMember(Value = "right")]
        Right,
        
        [EnumMember(Value = "none")]
        None,
    }
    
    /// <summary>
    /// Social buttons layout 
    /// </summary>
    public enum SocialButtonsLayout
    {
        [EnumMember(Value = "bottom")]
        Bottom,
        
        [EnumMember(Value = "top")]
        Top,
    }
}