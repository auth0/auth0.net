using System;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.Tests.Shared;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class BrandingClientTests : TestBase, IAsyncLifetime
    {
        private ManagementApiClient _apiClient;

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            _apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async Task Test_Branding_Reand_And_Update()
        {
            // Get initial branding
            var branding = await _apiClient.Branding.GetAsync();

            try
            {
                // Update branding
                await _apiClient.Branding.UpdateAsync(new Models.BrandingUpdateRequest
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

                var updatedBranding = await _apiClient.Branding.GetAsync();

                Assert.Equal("https://cdn.auth0.com/website/press/resources/auth0-logo-monotone-white.svg", updatedBranding.LogoUrl);
                Assert.Equal("https://cdn.auth0.com/website/press/resources/auth0-logo-monotone-black.svg", updatedBranding.FaviconUrl);
                Assert.Equal("https://fonts.googleapis.com/css2?family=Open+Sans&display=swap", updatedBranding.Font.Url);
                Assert.Equal("#ff0000", updatedBranding.Colors.Primary);
                Assert.Equal("#ffffff", updatedBranding.Colors.PageBackground);

            }
            finally
            {
                // Rollback
                await _apiClient.Branding.UpdateAsync(new Models.BrandingUpdateRequest
                {
                    Colors = branding.Colors,
                    LogoUrl = branding.LogoUrl,
                    FaviconUrl = branding.FaviconUrl,
                    Font = branding.Font,
                });
            }
        }

        [Fact(Skip = "Enable when migrated to new Tenant because missing permissions on current")]
        public async Task Test_Branding_ULPTemplate_Reand_Update_Delete()
        {
            // var temp = await _apiClient.Branding.GetUniversalLoginTemplateAsync();
            try
            {
                var newTemplateBody = @"<!DOCTYPE html><html>
                  <head>
                    {%- auth0:head -%}
                  </head>
                  <body>
                    {%- auth0:widget -%}
                  </body></html> ";

                await _apiClient.Branding.SetUniversalLoginTemplateAsync(new Models.UniversalLoginTemplateUpdateRequest
                {
                    Template = newTemplateBody
                });

                var updatedTemplate = await _apiClient.Branding.GetUniversalLoginTemplateAsync();

                Assert.Equal(newTemplateBody, updatedTemplate.Body);
            }
            finally
            {
                await _apiClient.Branding.DeleteUniversalLoginTemplateAsync();

                await Assert.ThrowsAsync<ErrorApiException>(() => _apiClient.Branding.GetUniversalLoginTemplateAsync());
            }
        }
    }
}