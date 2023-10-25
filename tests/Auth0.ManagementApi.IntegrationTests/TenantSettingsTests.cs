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

            using (var apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 })))
            {
                // Get the current settings
                var settings = await apiClient.TenantSettings.GetAsync();
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
                        EnablePipeline2 = true,
                    },
                    DeviceFlow = new TenantDeviceFlow()
                    {
                        Charset = TenantDeviceFlowCharset.Base20,
                        Mask = "***-***-***"
                    },
                    SessionCookie = new SessionCookie { Mode = "persistent" },
                    AllowedLogoutUrls = new string[] { "https://app.com/logout", "http://localhost/logout" },
                    SessionLifetime = 1080,
                    IdleSessionLifetime = 720,
                    CustomizeMfaInPostLoginAction = true
                };

                var settingsUpdateResponse = await apiClient.TenantSettings.UpdateAsync(settingsUpdateRequest);

                settingsUpdateResponse.Should().BeEquivalentTo(settingsUpdateRequest, options => options
                    .Excluding(p => p.Flags)
                    .Excluding(p => p.SandboxVersion)
                    .Excluding(p => p.SandboxVersionsAvailable)
                );

                settingsUpdateResponse.Flags.ChangePwdFlowV1.Should().BeFalse();
                settingsUpdateResponse.Flags.DisableClickjackProtectionHeaders.Should().BeTrue();
                settingsUpdateResponse.Flags.EnableAPIsSection.Should().BeTrue();
                settingsUpdateResponse.Flags.EnableClientConnections.Should().BeFalse();
                settingsUpdateResponse.Flags.EnablePipeline2.Should().BeTrue();
                settingsUpdateResponse.CustomizeMfaInPostLoginAction.Should().BeTrue();
                settingsUpdateResponse.SessionCookie.Mode.Should().Be("persistent");

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
}