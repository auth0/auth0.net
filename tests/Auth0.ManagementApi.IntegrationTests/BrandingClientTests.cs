using System;
using System.Threading.Tasks;
using Auth0.ManagementApi.Branding;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class BrandingClientTestsFixture : TestBaseFixture
{
}

public class BrandingClientTests : IClassFixture<BrandingClientTestsFixture>
{
    private BrandingClientTestsFixture fixture;

    public BrandingClientTests(BrandingClientTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Test_Branding_Read_And_Update()
    {
        try
        {
            // Update branding
            await fixture.ApiClient.Branding.UpdateAsync(new UpdateBrandingRequestContent
            {
                LogoUrl = "https://cdn.auth0.com/website/press/resources/auth0-logo-monotone-white.svg",
                FaviconUrl = "https://cdn.auth0.com/website/press/resources/auth0-logo-monotone-black.svg",
                Colors = new UpdateBrandingColors
                {
                    PageBackground = "#ffffff",
                    Primary = "#ff0000"
                },
                Font = new UpdateBrandingFont
                {
                    Url = "https://fonts.googleapis.com/css2?family=Open+Sans&display=swap"
                }
            });

            var updatedBranding = await fixture.ApiClient.Branding.GetAsync();

            Assert.Equal("https://cdn.auth0.com/website/press/resources/auth0-logo-monotone-white.svg",
                updatedBranding.LogoUrl);
            Assert.Equal("https://cdn.auth0.com/website/press/resources/auth0-logo-monotone-black.svg",
                updatedBranding.FaviconUrl);
            Assert.NotNull(updatedBranding.Font);
            Assert.Equal("#ff0000", updatedBranding.Colors?.Primary);
        }
        finally
        {
            // Rollback
            await fixture.ApiClient.Branding.UpdateAsync(new UpdateBrandingRequestContent
            {
                Colors = new UpdateBrandingColors
                {
                    Primary = "#0059d6",
                    PageBackground = "#000000"
                },
                LogoUrl = "https://cdn.auth0.com/website/press/resources/auth0-logo-monotone-black.svg",
                FaviconUrl = "https://cdn2.auth0.com/styleguide/latest/lib/logos/img/favicon.png",
                Font = new UpdateBrandingFont
                {
                    Url = "https://fonts.googleapis.com/css2?family=Roboto&display=swap"
                },
            });
        }
    }

    [Fact(Skip = "Enable when migrated to new Tenant because missing permissions on current")]
    public async Task Test_Branding_ULPTemplate_Read_Update_Delete()
    {
        try
        {
            var newTemplateBody = @"<!DOCTYPE html><html>
                  <head>
                    {%- auth0:head -%}
                  </head>
                  <body>
                    {%- auth0:widget -%}
                  </body></html> ";

            await fixture.ApiClient.Branding.Templates.UpdateUniversalLoginAsync(
                new UpdateUniversalLoginTemplateRequestContentTemplate
                {
                    Template = newTemplateBody
                });

            var updatedTemplate = await fixture.ApiClient.Branding.Templates.GetUniversalLoginAsync();

            // The result is a union type, get the template from it
            updatedTemplate.Visit(
                template => Assert.Equal(newTemplateBody, template.Body),
                str => Assert.True(false, "Expected template object, got string")
            );
        }
        finally
        {
            await fixture.ApiClient.Branding.Templates.DeleteUniversalLoginAsync();

            await Assert.ThrowsAsync<NotFoundError>(() =>
                fixture.ApiClient.Branding.Templates.GetUniversalLoginAsync());
        }
    }

    [Fact]
    public async void Test_BrandingTheme_crud_sequence()
    {
        // Create a branding theme
        var createBrandingThemeRequest = new CreateBrandingThemeRequestContent
        {
            Borders = new BrandingThemeBorders
            {
                ButtonBorderRadius = 1,
                ButtonBorderWeight = 2,
                ButtonsStyle = BrandingThemeBordersButtonsStyleEnum.Rounded,
                InputBorderRadius = 3,
                InputBorderWeight = 3,
                InputsStyle = BrandingThemeBordersInputsStyleEnum.Pill,
                ShowWidgetShadow = true,
                WidgetBorderWeight = 5,
                WidgetCornerRadius = 5
            },
            Colors = new BrandingThemeColors
            {
                BaseFocusColor = "#abcabc",
                BaseHoverColor = "#abcabc",
                BodyText = "#abcabc",
                CaptchaWidgetTheme = BrandingThemeColorsCaptchaWidgetThemeEnum.Dark,
                Error = "#abcabc",
                Header = "#abcabc",
                Icons = "#abcabc",
                InputBackground = "#abcabc",
                InputBorder = "#abcabc",
                InputFilledText = "#abcabc",
                InputLabelsPlaceholders = "#abcabc",
                LinksFocusedComponents = "#abcabc",
                PrimaryButton = "#abcabc",
                PrimaryButtonLabel = "#abcabc",
                SecondaryButtonBorder = "#abcabc",
                SecondaryButtonLabel = "#abcabc",
                Success = "#abaabc",
                WidgetBackground = "#abcaba",
                WidgetBorder = "#abcabc"
            },
            DisplayName = "Test branding Theme",
            Fonts = new BrandingThemeFonts
            {
                BodyText = new BrandingThemeFontBodyText
                {
                    Bold = true,
                    Size = 3
                },
                ButtonsText = new BrandingThemeFontButtonsText
                {
                    Size = 10,
                    Bold = false
                },
                FontUrl = "https://some.randomurl.com/",
                InputLabels = new BrandingThemeFontInputLabels
                {
                    Bold = true,
                    Size = 14
                },
                Links = new BrandingThemeFontLinks
                {
                    Bold = false,
                    Size = 14
                },
                LinksStyle = BrandingThemeFontLinksStyleEnum.Normal,
                ReferenceTextSize = 12,
                Subtitle = new BrandingThemeFontSubtitle
                {
                    Bold = true,
                    Size = 5
                },
                Title = new BrandingThemeFontTitle
                {
                    Bold = true,
                    Size = 75
                }
            },
            PageBackground = new BrandingThemePageBackground
            {
                BackgroundColor = "#abcabc",
                BackgroundImageUrl = "https://another-random-url.com/",
                PageLayout = BrandingThemePageBackgroundPageLayoutEnum.Left
            },
            Widget = new BrandingThemeWidget
            {
                HeaderTextAlignment = BrandingThemeWidgetHeaderTextAlignmentEnum.Center,
                LogoHeight = 10,
                LogoPosition = BrandingThemeWidgetLogoPositionEnum.Center,
                LogoUrl = "https://logo-url.com/",
                SocialButtonsLayout = BrandingThemeWidgetSocialButtonsLayoutEnum.Bottom
            }
        };
        var createdBrandingTheme =
            await fixture.ApiClient.Branding.Themes.CreateAsync(createBrandingThemeRequest);

        try
        {
            createdBrandingTheme.Should().NotBeNull();
            createdBrandingTheme.ThemeId.Should().NotBeNull();

            // Get the default branding theme
            var defaultBrandingTheme =
                await fixture.ApiClient.Branding.Themes.GetDefaultAsync();
            defaultBrandingTheme.Should().NotBeNull();

            // Update a branding theme
            var updateRequest = new UpdateBrandingThemeRequestContent
            {
                Borders = new BrandingThemeBorders
                {
                    ButtonBorderRadius = 1,
                    ButtonBorderWeight = 2,
                    ButtonsStyle = BrandingThemeBordersButtonsStyleEnum.Pill,
                    InputBorderRadius = 3,
                    InputBorderWeight = 3,
                    InputsStyle = BrandingThemeBordersInputsStyleEnum.Pill,
                    ShowWidgetShadow = true,
                    WidgetBorderWeight = 5,
                    WidgetCornerRadius = 5
                },
                Colors = new BrandingThemeColors
                {
                    BaseFocusColor = "#abcabc",
                    BaseHoverColor = "#abcabc",
                    BodyText = "#abcabc",
                    CaptchaWidgetTheme = BrandingThemeColorsCaptchaWidgetThemeEnum.Dark,
                    Error = "#accabc",
                    Header = "#abcabc",
                    Icons = "#abcabc",
                    InputBackground = "#abcabc",
                    InputBorder = "#abcabc",
                    InputFilledText = "#abcabc",
                    InputLabelsPlaceholders = "#abcabc",
                    LinksFocusedComponents = "#abcabc",
                    PrimaryButton = "#abcabc",
                    PrimaryButtonLabel = "#abcabc",
                    SecondaryButtonBorder = "#abcabc",
                    SecondaryButtonLabel = "#abcabc",
                    Success = "#abaabc",
                    WidgetBackground = "#abcaba",
                    WidgetBorder = "#abcabc"
                },
                DisplayName = "Test branding Theme Updated",
                Fonts = new BrandingThemeFonts
                {
                    BodyText = new BrandingThemeFontBodyText
                    {
                        Bold = true,
                        Size = 3
                    },
                    ButtonsText = new BrandingThemeFontButtonsText
                    {
                        Size = 10,
                        Bold = false
                    },
                    FontUrl = "https://some.randomurl.com/",
                    InputLabels = new BrandingThemeFontInputLabels
                    {
                        Bold = true,
                        Size = 14
                    },
                    Links = new BrandingThemeFontLinks
                    {
                        Bold = false,
                        Size = 14
                    },
                    LinksStyle = BrandingThemeFontLinksStyleEnum.Normal,
                    ReferenceTextSize = 12,
                    Subtitle = new BrandingThemeFontSubtitle
                    {
                        Bold = true,
                        Size = 5
                    },
                    Title = new BrandingThemeFontTitle
                    {
                        Bold = true,
                        Size = 75
                    }
                },
                PageBackground = new BrandingThemePageBackground
                {
                    BackgroundColor = "#abcabc",
                    BackgroundImageUrl = "https://another-random-url.com/",
                    PageLayout = BrandingThemePageBackgroundPageLayoutEnum.Left
                },
                Widget = new BrandingThemeWidget
                {
                    HeaderTextAlignment = BrandingThemeWidgetHeaderTextAlignmentEnum.Center,
                    LogoHeight = 10,
                    LogoPosition = BrandingThemeWidgetLogoPositionEnum.Left,
                    LogoUrl = "https://logo-url.com/",
                    SocialButtonsLayout = BrandingThemeWidgetSocialButtonsLayoutEnum.Bottom
                }
            };
            var updatedBrandingTheme =
                await fixture.ApiClient.Branding.Themes.UpdateAsync(createdBrandingTheme.ThemeId, updateRequest);

            updatedBrandingTheme.Widget.LogoPosition.Should().Be(BrandingThemeWidgetLogoPositionEnum.Left);

            // get the branding theme
            var fetchBrandingTheme = await fixture.ApiClient.Branding.Themes.GetAsync(createdBrandingTheme.ThemeId);
            fetchBrandingTheme.Should().NotBeNull();
        }
        finally
        {
            // delete the branding theme
            await fixture.ApiClient.Branding.Themes.DeleteAsync(createdBrandingTheme.ThemeId);
        }
    }
}
