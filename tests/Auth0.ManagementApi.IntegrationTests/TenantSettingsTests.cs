using System;
using System.Threading.Tasks;
using Auth0.ManagementApi.Tenants;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests;

public class TenantSettingsTestsFixture : TestBaseFixture
{
}

public class TenantSettingsTests : IClassFixture<TenantSettingsTestsFixture>
{
    private TenantSettingsTestsFixture fixture;

    public TenantSettingsTests(TenantSettingsTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Test_tenant_settings_sequence()
    {
        // Get the current settings
        var settings = await fixture.ApiClient.Tenants.Settings.GetAsync(new GetTenantSettingsRequestParameters());
        settings.Should().NotBeNull();

        try
        {
            // Update the tenant settings - do not set some properties as the tenant is pre-configured
            // to allow all the right logout urls etc.
            var settingsUpdateRequest = new UpdateTenantSettingsRequestContent
            {
                ChangePassword = new TenantSettingsPasswordPage
                {
                    Enabled = true,
                    Html = "<b>hi</b>",
                },
                ErrorPage = new TenantSettingsErrorPage
                {
                    Html = null,
                    ShowLogLink = false,
                    Url = $"www.{Guid.NewGuid():N}.aaa/error",
                },
                GuardianMfaPage = new TenantSettingsGuardianPage
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
                EnabledLocales = new[] { TenantSettingsSupportedLocalesEnum.En },
                Flags = new TenantSettingsFlags
                {
                    ChangePwdFlowV1 = false,
                    DisableClickjackProtectionHeaders = true,
                    EnableApisSection = true,
                    EnableClientConnections = false,
                    EnablePipeline2 = true,
                    RemoveAlgFromJwks = true
                },
                DeviceFlow = new TenantSettingsDeviceFlow
                {
                    Charset = TenantSettingsDeviceFlowCharset.Base20,
                    Mask = "***-***-***"
                },
                SessionCookie = new SessionCookieSchema { Mode = SessionCookieModeEnum.Persistent },
                AllowedLogoutUrls = new string[] { "https://app.com/logout", "http://localhost/logout" },
                SessionLifetime = 1080,
                IdleSessionLifetime = 720,
                CustomizeMfaInPostloginAction = true,
                AcrValuesSupported = new[] { "value1", "value2" },
                PushedAuthorizationRequestsSupported = true,
                Mtls = new TenantSettingsMtls { EnableEndpointAliases = true },
                DefaultTokenQuota = new DefaultTokenQuota
                {
                    Clients = new TokenQuotaConfiguration
                    {
                        ClientCredentials = new TokenQuotaClientCredentials
                        {
                            Enforce = true,
                            PerDay = 200,
                            PerHour = 100
                        }
                    },
                    Organizations = new TokenQuotaConfiguration
                    {
                        ClientCredentials = new TokenQuotaClientCredentials
                        {
                            Enforce = true,
                            PerDay = 200,
                            PerHour = 100
                        }
                    },
                },
                SandboxVersion = "12",
                DefaultRedirectionUri = "https://www.example-domain.com/login",
                Sessions = new TenantSettingsSessions
                {
                    OidcLogoutPromptEnabled = false
                },
                OidcLogout = new TenantOidcLogoutSettings
                {
                    RpLogoutEndSessionEndpointDiscovery = false
                },
                AllowOrganizationNameInAuthenticationApi = false
            };

            var settingsUpdateResponse = await fixture.ApiClient.Tenants.Settings.UpdateAsync(settingsUpdateRequest);

            settingsUpdateResponse.FriendlyName.Should().Be(settingsUpdateRequest.FriendlyName);
            settingsUpdateResponse.Flags.ChangePwdFlowV1.Should().BeFalse();
            settingsUpdateResponse.Flags.DisableClickjackProtectionHeaders.Should().BeTrue();
            settingsUpdateResponse.Flags.EnableApisSection.Should().BeTrue();
            settingsUpdateResponse.Flags.EnableClientConnections.Should().BeFalse();
            settingsUpdateResponse.Flags.EnablePipeline2.Should().BeTrue();
            settingsUpdateResponse.Flags.RemoveAlgFromJwks.Should().BeTrue();
            settingsUpdateResponse.CustomizeMfaInPostloginAction.Should().BeTrue();
            settingsUpdateResponse.SessionCookie.Value.Mode.Should().Be(SessionCookieModeEnum.Persistent);
        }
        finally
        {
            var resetUpdateRequest = new UpdateTenantSettingsRequestContent
            {
                ChangePassword = new TenantSettingsPasswordPage
                {
                    Html = null,
                    Enabled = false,
                },
                ErrorPage = new TenantSettingsErrorPage
                {
                    Html = null,
                    Url = "",
                },
                GuardianMfaPage = new TenantSettingsGuardianPage
                {
                    Html = null,
                    Enabled = false,
                },
                Flags = new TenantSettingsFlags
                {
                    RemoveAlgFromJwks = false
                },
                FriendlyName = "Auth0.NET SDK integration test",
                PictureUrl = "",
                SupportEmail = "sdks@auth0.com",
                SupportUrl = "",
                AcrValuesSupported = null,
                PushedAuthorizationRequestsSupported = false,
                Mtls = null,
                DefaultTokenQuota = new DefaultTokenQuota
                {
                    Clients = new TokenQuotaConfiguration
                    {
                        ClientCredentials = new TokenQuotaClientCredentials
                        {
                            Enforce = false
                        }
                    },
                    Organizations = new TokenQuotaConfiguration
                    {
                        ClientCredentials = new TokenQuotaClientCredentials
                        {
                            Enforce = false
                        }
                    },
                },
                SandboxVersion = null,
                DefaultRedirectionUri = null,
                Sessions = null,
                OidcLogout = null,
                AllowOrganizationNameInAuthenticationApi = null
            };
            await fixture.ApiClient.Tenants.Settings.UpdateAsync(resetUpdateRequest);
        }
    }
}
