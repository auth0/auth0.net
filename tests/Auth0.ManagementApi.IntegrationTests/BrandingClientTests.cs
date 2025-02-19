using System;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using FluentAssertions.Common;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class BrandingClientTestsFixture : TestBaseFixture
    {
    }

    public class BrandingClientTests : IClassFixture<BrandingClientTestsFixture>
    {
        BrandingClientTestsFixture fixture;

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
                await fixture.ApiClient.Branding.UpdateAsync(new Models.BrandingUpdateRequest
                {
                    LogoUrl = "https://cdn.auth0.com/website/press/resources/auth0-logo-monotone-white.svg",
                    FaviconUrl = "https://cdn.auth0.com/website/press/resources/auth0-logo-monotone-black.svg",
                    Colors = new Models.BrandingColors
                    {
                        PageBackground = "#ffffff",
                        Primary = "#ff0000"
                    },
                    Font = new Models.BrandingFont
                    {
                        Url = "https://fonts.googleapis.com/css2?family=Open+Sans&display=swap"
                    }
                });

                var updatedBranding = await fixture.ApiClient.Branding.GetAsync();

                Assert.Equal("https://cdn.auth0.com/website/press/resources/auth0-logo-monotone-white.svg",
                    updatedBranding.LogoUrl);
                Assert.Equal("https://cdn.auth0.com/website/press/resources/auth0-logo-monotone-black.svg",
                    updatedBranding.FaviconUrl);
                Assert.Equal("https://fonts.googleapis.com/css2?family=Open+Sans&display=swap",
                    updatedBranding.Font.Url);
                Assert.Equal("#ff0000", updatedBranding.Colors.Primary);
                Assert.Equal("#ffffff", updatedBranding.Colors.PageBackground);
            }
            finally
            {
                // Rollback
                await fixture.ApiClient.Branding.UpdateAsync(new Models.BrandingUpdateRequest
                {
                    Colors = new Models.BrandingColors
                    {
                        Primary = "#0059d6",
                        PageBackground = "#000000"
                    },
                    LogoUrl = "https://cdn.auth0.com/website/press/resources/auth0-logo-monotone-black.svg",
                    FaviconUrl = "https://cdn2.auth0.com/styleguide/latest/lib/logos/img/favicon.png",
                    Font = new Models.BrandingFont
                    {
                        Url = "https://fonts.googleapis.com/css2?family=Roboto&display=swap"
                    },
                });
            }
        }

        [Fact(Skip = "Enable when migrated to new Tenant because missing permissions on current")]
        public async Task Test_Branding_ULPTemplate_Read_Update_Delete()
        {
            // var temp = await ApiClient.Branding.GetUniversalLoginTemplateAsync();
            try
            {
                var newTemplateBody = @"<!DOCTYPE html><html>
                  <head>
                    {%- auth0:head -%}
                  </head>
                  <body>
                    {%- auth0:widget -%}
                  </body></html> ";

                await fixture.ApiClient.Branding.SetUniversalLoginTemplateAsync(
                    new Models.UniversalLoginTemplateUpdateRequest
                    {
                        Template = newTemplateBody
                    });

                var updatedTemplate = await fixture.ApiClient.Branding.GetUniversalLoginTemplateAsync();

                Assert.Equal(newTemplateBody, updatedTemplate.Body);
            }
            finally
            {
                await fixture.ApiClient.Branding.DeleteUniversalLoginTemplateAsync();

                await Assert.ThrowsAsync<ErrorApiException>(() =>
                    fixture.ApiClient.Branding.GetUniversalLoginTemplateAsync());
            }
        }

        [Fact]
        public async void Test_BrandingPhoneProvider_crud_sequence()
        {
            BrandingPhoneProvider newBrandingPhoneProvider = null;
            try
            {
                // Create a BrandingPhoneProvider
                var brandingCreateRequest = new BrandingPhoneProviderCreateRequest()
                {
                    Credentials = new BrandingCredential()
                    {
                        AuthToken = "ThisIsAToken"
                    },
                    Disabled = true,
                    Name = "twilio",
                    Configuration = new
                    {
                        delivery_methods = new[] { "text" },
                    }
                };

                newBrandingPhoneProvider =
                    await fixture.ApiClient.Branding.CreatePhoneProviderAsync(brandingCreateRequest);
                newBrandingPhoneProvider.Should().NotBeNull();
                newBrandingPhoneProvider.Id.Should().NotBeNull();
                newBrandingPhoneProvider.Should().BeEquivalentTo(
                    brandingCreateRequest,
                    options => options.Excluding(
                        x => x.Credentials).ExcludingMissingMembers());

                // Update the BrandingPhoneProvider
                var updateRequest = new BrandingPhoneProviderUpdateRequest()
                {
                    Disabled = false
                };

                var updatedBrandingPhoneProvider =
                    await fixture.ApiClient.Branding.UpdatePhoneProviderAsync(newBrandingPhoneProvider.Id,
                        updateRequest);
                updatedBrandingPhoneProvider.Should().NotBeNull();
                updatedBrandingPhoneProvider.Id.Should().Be(newBrandingPhoneProvider.Id);
                updatedBrandingPhoneProvider.Disabled.Should().Be(false);

                // Get a specific Branding Provider 
                var brandingPhoneProvider =
                    await fixture.ApiClient.Branding.GetPhoneProviderAsync(newBrandingPhoneProvider.Id);
                brandingPhoneProvider.Should().NotBeNull();
                brandingPhoneProvider.Id.Should().Be(newBrandingPhoneProvider.Id);

                // Get all available Branding Phone Providers
                var allBrandingPhoneProviders =
                    await fixture.ApiClient.Branding.GetAllPhoneProvidersAsync(new BrandingPhoneProviderGetRequest()
                        { Disabled = false });

                allBrandingPhoneProviders.Should().NotBeNull();
                allBrandingPhoneProviders.Count.Should().BeGreaterThan(0);
            }
            finally
            {
                // Delete existing Branding Phone Provider
                await fixture.ApiClient.Branding.DeletePhoneProviderAsync(newBrandingPhoneProvider.Id);
            }
        }

        [Fact]
        public async void Test_GetBrandingPhoneProvider_should_not_fail_for_null_input()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(
                () => fixture.ApiClient.Branding.GetPhoneProviderAsync(null));
        }
        
        [Fact]
        public async void Test_UpdateBrandingPhoneProvider_should_not_fail_for_null_input()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(
                () => fixture.ApiClient.Branding.UpdatePhoneProviderAsync(null, new BrandingPhoneProviderUpdateRequest()));
        }
        
        [Fact]
        public async void Test_DeleteBrandingPhoneProvider_should_not_fail_for_null_input()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(
                () => fixture.ApiClient.Branding.DeletePhoneProviderAsync(null));
        }
        
        [Fact]
        public async void Test_SendBrandingPhoneNotitication_should_not_fail_for_null_input()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(
                () => fixture.ApiClient.Branding.SendBrandingPhoneTestNotificationAsync(null, new BrandingPhoneTestNotificationRequest()));
        }
        
        [Fact]
        public async void Test_UpdateBrandingPhoneNotitication_should_not_fail_for_null_input()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(
                () => fixture.ApiClient.Branding.UpdateBrandingPhoneNotificationTemplate(null, new BrandingPhoneNotificationTemplateUpdateRequest()));
        }
        
        [Fact]
        public async void Test_DeleteBrandingPhoneNotitication_should_not_fail_for_null_input()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(
                () => fixture.ApiClient.Branding.DeleteBrandingPhoneNotificationTemplateAsync(null));
        }
        
        [Fact]
        public async void Test_ResetBrandingPhoneNotitication_should_not_fail_for_null_input()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(
                () => fixture.ApiClient.Branding.ResetBrandingPhoneNotificationTemplate(null));
        }
        
        [Fact]
        public async void Test_GetBrandingTheme_should_throw_for_null_input()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(
                () => fixture.ApiClient.Branding.GetBrandingThemeAsync(null));
        }
        
        [Fact]
        public async void Test_BrandingPhoneNotificationTemplate_crud_sequence()
        {
            BrandingPhoneNotificationTemplate createdBrandingPhoneNotificationTemplate = null;
            try
            {
                // Create a Branding Phone Notification Template 
                var createRequest = new BrandingPhoneNotificationTemplateCreateRequest()
                {
                    Content = new Content()
                    {
                        Syntax = "string",
                        Body = new ContentBody()
                        {
                            Text = "This is a text message",
                            Voice = "This is a voice message",
                        },
                        From = "1234567890",
                    },
                    Disabled = false,
                    Type = BrandingPhoneNotificationTemplateType.OtpVerify,
                };

                createdBrandingPhoneNotificationTemplate =
                    await fixture.ApiClient.Branding.CreateBrandingPhoneNotificationTemplateAsync(createRequest);

                createdBrandingPhoneNotificationTemplate.Should().NotBeNull();
                createdBrandingPhoneNotificationTemplate.Id.Should().NotBeNull();
                createdBrandingPhoneNotificationTemplate.Should()
                    .BeEquivalentTo(createRequest, options => options.ExcludingMissingMembers().Excluding( x => x.Content.Syntax));
                
                // Send a Test notification using the newly created Branding Phone Notification Template
                var testNotificationRequest = new BrandingPhoneTestNotificationRequest()
                {
                    To = "+911234567890",
                    DeliveryMethod = "text"
                };
                var testNotificationResponse = await fixture.ApiClient.Branding.SendBrandingPhoneTemplateTestNotificationAsync(
                    createdBrandingPhoneNotificationTemplate.Id, testNotificationRequest);
                testNotificationResponse.Should().NotBeNull();
                
                // Update the branding Phone Notification Template
                var updateRequest = new BrandingPhoneNotificationTemplateUpdateRequest()
                {
                    Content = new Content()
                    {
                        Body = new ContentBody()
                        {
                            Text = "This is an updated text message",
                            Voice = "This is an updated voice message",
                        },
                        From = "0987654321",
                    },
                };
                
                var updatedBrandingPhoneNotificationTemplate =
                    await fixture.ApiClient.Branding.UpdateBrandingPhoneNotificationTemplate(
                        createdBrandingPhoneNotificationTemplate.Id, updateRequest);
                updatedBrandingPhoneNotificationTemplate.Should().NotBeNull();
                
                // Get the Branding Phone Notification Template
                var retrievedBrandingPhoneNotificationTemplate =
                    await fixture.ApiClient.Branding.GetBrandingPhoneNotificationTemplateAsync(
                        updatedBrandingPhoneNotificationTemplate.Id);
                retrievedBrandingPhoneNotificationTemplate.Should().NotBeNull();
                retrievedBrandingPhoneNotificationTemplate.Should().BeEquivalentTo(
                    updatedBrandingPhoneNotificationTemplate, options => options.ExcludingMissingMembers());
            }
            finally
            {
                // Delete the Branding Phone Notification Template
                await fixture.ApiClient.Branding.DeleteBrandingPhoneNotificationTemplateAsync(
                    createdBrandingPhoneNotificationTemplate?.Id);
            }

            // Get All Branding Phone Notification Templates and ensure delete was successful
            var allBrandingPhoneNotificationTemplates = 
                await fixture.ApiClient.Branding.GetAllBrandingPhoneNotificationTemplatesAsync(
                    new BrandingPhoneNotificationTemplatesGetRequest());
            allBrandingPhoneNotificationTemplates.Should()
                .NotContain(x => x.Id == createdBrandingPhoneNotificationTemplate.Id);
        }

        [Fact]
        public async void Test_BrandingTheme_crud_sequence()
        {
            // Create a branding theme 
            var createBrandingThemeRequest = new BrandingThemeCreateRequest()
            {
                Borders = new BrandingThemeBorder()
                {
                    ButtonBorderRadius = 1,
                    ButtonBorderWeight = 2,
                    ButtonsStyle = ButtonsStyle.Rounded,
                    InputBorderRadius = 3,
                    InputBorderWeight = 3,
                    InputsStyle = ButtonsStyle.Pill,
                    ShowWidgetShadow = true,
                    WidgetBorderWeight = 5,
                    WidgetCornerRadius = 5
                },
                Colors = new BrandingThemeColors()
                {
                    BaseFocusColor = "#abcabc",
                    BaseHoverColor = "#abcabc",
                    BodyText = "#abcabc",
                    CaptchaWidgetTheme = CaptchaWidgetTheme.Dark,
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
                Fonts = new BrandingThemeFonts()
                {
                    BodyText = new BodyText()
                    {
                        Bold = true,
                        Size = 3
                    },
                    ButtonsText = new ButtonsText()
                    {
                        Size = 10,
                        Bold = false
                    },
                    FontUrl = "https://some.randomurl.com/",
                    InputLabels = new InputLabels()
                    {
                        Bold = true
                    },
                    Links = new Links()
                    {
                        Bold = false
                    },
                    LinksStyle = LinksStyle.Normal,
                    ReferenceTextSize = 12,
                    Subtitle = new Subtitle()
                    {
                        Bold = true,
                        Size = 5
                    },
                    Title = new Title()
                    {
                        Bold = true,
                        Size = 75
                    }
                },
                PageBackground = new BrandingThemePageBackground()
                {
                    BackgroundColor = "#abcabc",
                    BackgroundImageUrl = "https://another-random-url.com/",
                    PageLayout = PageLayout.Left
                },
                Widget = new BrandingThemeWidget()
                {
                    HeaderTextAlignment = HeaderTextAlignment.Center,
                    LogoHeight = 10,
                    LogoPosition = LogoPosition.Center,
                    LogoUrl = "https://logo-url.com/",
                    SocialButtonsLayout = SocialButtonsLayout.Bottom
                    
                }
            };
            var createdBrandingTheme =
                await fixture.ApiClient.Branding.CreateBrandingThemeAsync(createBrandingThemeRequest);

            try
            {
                createdBrandingTheme.Should().BeEquivalentTo(createBrandingThemeRequest, options => options.ExcludingMissingMembers());

                // Get the default branding theme
                var defaultBrandingTheme =
                    await fixture.ApiClient.Branding.GetDefaultBrandingThemeAsync();
                defaultBrandingTheme.Should().NotBeNull();

                // Update a branding theme 
                var updateRequest = new BrandingThemeUpdateRequest()
                {
                    Borders = new BrandingThemeBorder()
                    {
                        ButtonBorderRadius = 1,
                        ButtonBorderWeight = 2,
                        ButtonsStyle = ButtonsStyle.Pill,
                        InputBorderRadius = 3,
                        InputBorderWeight = 3,
                        InputsStyle = ButtonsStyle.Pill,
                        ShowWidgetShadow = true,
                        WidgetBorderWeight = 5,
                        WidgetCornerRadius = 5
                    },
                    Colors = new BrandingThemeColors()
                    {
                        BaseFocusColor = "#abcabc",
                        BaseHoverColor = "#abcabc",
                        BodyText = "#abcabc",
                        CaptchaWidgetTheme = CaptchaWidgetTheme.Dark,
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
                    DisplayName = "Test branding Theme",
                    Fonts = new BrandingThemeFonts()
                    {
                        BodyText = new BodyText()
                        {
                            Bold = true,
                            Size = 3
                        },
                        ButtonsText = new ButtonsText()
                        {
                            Size = 10,
                            Bold = false
                        },
                        FontUrl = "https://some.randomurl.com/",
                        InputLabels = new InputLabels()
                        {
                            Bold = true
                        },
                        Links = new Links()
                        {
                            Bold = false
                        },
                        LinksStyle = LinksStyle.Normal,
                        ReferenceTextSize = 12,
                        Subtitle = new Subtitle()
                        {
                            Bold = true,
                            Size = 5
                        },
                        Title = new Title()
                        {
                            Bold = true,
                            Size = 75
                        }
                    },
                    PageBackground = new BrandingThemePageBackground()
                    {
                        BackgroundColor = "#abcabc",
                        BackgroundImageUrl = "https://another-random-url.com/",
                        PageLayout = PageLayout.Left
                    },
                    Widget = new BrandingThemeWidget()
                    {
                        HeaderTextAlignment = HeaderTextAlignment.Center,
                        LogoHeight = 10,
                        LogoPosition = LogoPosition.Left,
                        LogoUrl = "https://logo-url.com/",
                        SocialButtonsLayout = SocialButtonsLayout.Bottom
                        
                    }
                };
                var updatedBrandingTheme =
                    await fixture.ApiClient.Branding.UpdateBrandingThemeAsync(createdBrandingTheme.ThemeId, updateRequest);
            
                updatedBrandingTheme.Widget.LogoPosition.Should().Be(LogoPosition.Left);
            
                // get the branding theme 
                var fetchBrandingTheme = await fixture.ApiClient.Branding.GetBrandingThemeAsync(createdBrandingTheme.ThemeId);
                fetchBrandingTheme.Should().BeEquivalentTo(updatedBrandingTheme, options => options.Excluding( x => x.ThemeId));

            }
            finally
            {
                // delete the branding theme
                await fixture.ApiClient.Branding.DeleteBrandingThemeAsync(createdBrandingTheme.ThemeId);
            }
        }
    }
}