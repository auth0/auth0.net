using Auth0.ManagementApi;
using Auth0.ManagementApi.Branding;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Branding.Themes;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "borders": {
                "button_border_radius": 1.1,
                "button_border_weight": 1.1,
                "buttons_style": "pill",
                "input_border_radius": 1.1,
                "input_border_weight": 1.1,
                "inputs_style": "pill",
                "show_widget_shadow": true,
                "widget_border_weight": 1.1,
                "widget_corner_radius": 1.1
              },
              "colors": {
                "body_text": "body_text",
                "error": "error",
                "header": "header",
                "icons": "icons",
                "input_background": "input_background",
                "input_border": "input_border",
                "input_filled_text": "input_filled_text",
                "input_labels_placeholders": "input_labels_placeholders",
                "links_focused_components": "links_focused_components",
                "primary_button": "primary_button",
                "primary_button_label": "primary_button_label",
                "secondary_button_border": "secondary_button_border",
                "secondary_button_label": "secondary_button_label",
                "success": "success",
                "widget_background": "widget_background",
                "widget_border": "widget_border"
              },
              "fonts": {
                "body_text": {
                  "bold": true,
                  "size": 1.1
                },
                "buttons_text": {
                  "bold": true,
                  "size": 1.1
                },
                "font_url": "font_url",
                "input_labels": {
                  "bold": true,
                  "size": 1.1
                },
                "links": {
                  "bold": true,
                  "size": 1.1
                },
                "links_style": "normal",
                "reference_text_size": 1.1,
                "subtitle": {
                  "bold": true,
                  "size": 1.1
                },
                "title": {
                  "bold": true,
                  "size": 1.1
                }
              },
              "page_background": {
                "background_color": "background_color",
                "background_image_url": "background_image_url",
                "page_layout": "center"
              },
              "widget": {
                "header_text_alignment": "center",
                "logo_height": 1.1,
                "logo_position": "center",
                "logo_url": "logo_url",
                "social_buttons_layout": "bottom"
              }
            }
            """;

        const string mockResponse = """
            {
              "borders": {
                "button_border_radius": 1.1,
                "button_border_weight": 1.1,
                "buttons_style": "pill",
                "input_border_radius": 1.1,
                "input_border_weight": 1.1,
                "inputs_style": "pill",
                "show_widget_shadow": true,
                "widget_border_weight": 1.1,
                "widget_corner_radius": 1.1
              },
              "colors": {
                "base_focus_color": "base_focus_color",
                "base_hover_color": "base_hover_color",
                "body_text": "body_text",
                "captcha_widget_theme": "auto",
                "error": "error",
                "header": "header",
                "icons": "icons",
                "input_background": "input_background",
                "input_border": "input_border",
                "input_filled_text": "input_filled_text",
                "input_labels_placeholders": "input_labels_placeholders",
                "links_focused_components": "links_focused_components",
                "primary_button": "primary_button",
                "primary_button_label": "primary_button_label",
                "read_only_background": "read_only_background",
                "secondary_button_border": "secondary_button_border",
                "secondary_button_label": "secondary_button_label",
                "success": "success",
                "widget_background": "widget_background",
                "widget_border": "widget_border"
              },
              "displayName": "displayName",
              "fonts": {
                "body_text": {
                  "bold": true,
                  "size": 1.1
                },
                "buttons_text": {
                  "bold": true,
                  "size": 1.1
                },
                "font_url": "font_url",
                "input_labels": {
                  "bold": true,
                  "size": 1.1
                },
                "links": {
                  "bold": true,
                  "size": 1.1
                },
                "links_style": "normal",
                "reference_text_size": 1.1,
                "subtitle": {
                  "bold": true,
                  "size": 1.1
                },
                "title": {
                  "bold": true,
                  "size": 1.1
                }
              },
              "page_background": {
                "background_color": "background_color",
                "background_image_url": "background_image_url",
                "page_layout": "center"
              },
              "themeId": "themeId",
              "widget": {
                "header_text_alignment": "center",
                "logo_height": 1.1,
                "logo_position": "center",
                "logo_url": "logo_url",
                "social_buttons_layout": "bottom"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/branding/themes/themeId")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Branding.Themes.UpdateAsync(
            "themeId",
            new UpdateBrandingThemeRequestContent
            {
                Borders = new BrandingThemeBorders
                {
                    ButtonBorderRadius = 1.1,
                    ButtonBorderWeight = 1.1,
                    ButtonsStyle = BrandingThemeBordersButtonsStyleEnum.Pill,
                    InputBorderRadius = 1.1,
                    InputBorderWeight = 1.1,
                    InputsStyle = BrandingThemeBordersInputsStyleEnum.Pill,
                    ShowWidgetShadow = true,
                    WidgetBorderWeight = 1.1,
                    WidgetCornerRadius = 1.1,
                },
                Colors = new BrandingThemeColors
                {
                    BodyText = "body_text",
                    Error = "error",
                    Header = "header",
                    Icons = "icons",
                    InputBackground = "input_background",
                    InputBorder = "input_border",
                    InputFilledText = "input_filled_text",
                    InputLabelsPlaceholders = "input_labels_placeholders",
                    LinksFocusedComponents = "links_focused_components",
                    PrimaryButton = "primary_button",
                    PrimaryButtonLabel = "primary_button_label",
                    SecondaryButtonBorder = "secondary_button_border",
                    SecondaryButtonLabel = "secondary_button_label",
                    Success = "success",
                    WidgetBackground = "widget_background",
                    WidgetBorder = "widget_border",
                },
                Fonts = new BrandingThemeFonts
                {
                    BodyText = new BrandingThemeFontBodyText { Bold = true, Size = 1.1 },
                    ButtonsText = new BrandingThemeFontButtonsText { Bold = true, Size = 1.1 },
                    FontUrl = "font_url",
                    InputLabels = new BrandingThemeFontInputLabels { Bold = true, Size = 1.1 },
                    Links = new BrandingThemeFontLinks { Bold = true, Size = 1.1 },
                    LinksStyle = BrandingThemeFontLinksStyleEnum.Normal,
                    ReferenceTextSize = 1.1,
                    Subtitle = new BrandingThemeFontSubtitle { Bold = true, Size = 1.1 },
                    Title = new BrandingThemeFontTitle { Bold = true, Size = 1.1 },
                },
                PageBackground = new BrandingThemePageBackground
                {
                    BackgroundColor = "background_color",
                    BackgroundImageUrl = "background_image_url",
                    PageLayout = BrandingThemePageBackgroundPageLayoutEnum.Center,
                },
                Widget = new BrandingThemeWidget
                {
                    HeaderTextAlignment = BrandingThemeWidgetHeaderTextAlignmentEnum.Center,
                    LogoHeight = 1.1,
                    LogoPosition = BrandingThemeWidgetLogoPositionEnum.Center,
                    LogoUrl = "logo_url",
                    SocialButtonsLayout = BrandingThemeWidgetSocialButtonsLayoutEnum.Bottom,
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
