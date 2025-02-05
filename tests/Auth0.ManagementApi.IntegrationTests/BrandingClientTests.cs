using System;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
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
    }
}