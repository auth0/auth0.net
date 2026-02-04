using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Branding;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
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
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Branding.Themes.GetAsync("themeId");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
