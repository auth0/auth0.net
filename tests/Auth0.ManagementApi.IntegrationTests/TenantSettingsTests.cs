using System;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class TenantSettingsTests : TestBase
    {
        [Fact]
        public async Task Test_tenant_settings_sequence()
        {
            string token = await GenerateManagementApiToken();

            var apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));

            // Get the current settings
            var settings = apiClient.TenantSettings.GetAsync();
            settings.Should().NotBeNull();

            // Update the tenant settings - do not set some properties as the tenant is pre-configured
            // to allow all the right logout urls etc.
            var settingsUpdateRequest = new TenantSettingsUpdateRequest
            {
                ChangePassword = new TenantChangePassword
                {
                    Enabled = true,
                    Html = "<b>hi</b>",
                },
                ErrorPage = new TenantErrorPage
                {
                    Html = null,
                    ShowLogLink = false,
                    Url = $"www.{Guid.NewGuid():N}.aaa/error",
                },
                GuardianMfaPage = new TenantGuardianMfaPage
                {
                    Html = "<b>hi</b>",
                    Enabled = true,
                },
                FriendlyName = Guid.NewGuid().ToString("N"),
                PictureUrl = $"www.{Guid.NewGuid():N}.aaa/picture.png",
                SupportEmail = $"support@{Guid.NewGuid():N}.aaa",
                SupportUrl = $"www.{Guid.NewGuid():N}.aaa/support",
                DefaultAudience = "",
                DefaultDirectory = "Username-Password-Authentication",
                EnabledLocales = new[] { "en" },
                Flags = new TenantFlags()
                {
                    ChangePwdFlowV1 = false,
                    DisableClickjackProtectionHeaders = true,
                    EnableAPIsSection = true,
                    EnableClientConnections = false,
                    EnablePipeline2 = true
                },
                DeviceFlow = new TenantDeviceFlow()
                {
                     Charset = TenantDeviceFlowCharset.Base20,
                     Mask = "***-***-***"
                }
            };

            var settingsUpdateResponse = await apiClient.TenantSettings.UpdateAsync(settingsUpdateRequest);
            settingsUpdateResponse.Should().BeEquivalentTo(settingsUpdateRequest, options => options.Excluding(p => p.SandboxVersion).Excluding(p => p.SandboxVersionsAvailable));

            var resetUpdateRequest = new TenantSettingsUpdateRequest
            {
                ChangePassword = new TenantChangePassword
                {
                    Html = null,
                    Enabled = false,
                },
                ErrorPage = new TenantErrorPage
                {
                    Html = null,
                    Url = "",
                },
                GuardianMfaPage = new TenantGuardianMfaPage
                {
                    Html = null,
                    Enabled = false,
                },
                FriendlyName = "Auth0.NET SDK integration test",
                PictureUrl = "",
                SupportEmail = "sdks@auth0.com",
                SupportUrl = "",
            };

            await apiClient.TenantSettings.UpdateAsync(resetUpdateRequest);
        }
    }
}