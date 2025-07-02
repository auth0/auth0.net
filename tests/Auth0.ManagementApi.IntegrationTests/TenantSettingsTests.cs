using System;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests;

public class TenantSettingsTests : TestBase
{
    [Fact]
    public async Task Test_tenant_settings_sequence()
    {
        string token = await GenerateManagementApiToken();

        using (var apiClient = 
               new ManagementApiClient(
                   token, 
                   GetVariable("AUTH0_MANAGEMENT_API_URL"),
                   new HttpClientManagementConnection(
                       options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 })))
        {
            // Get the current settings
            var settings = await apiClient.TenantSettings.GetAsync();
            settings.Should().NotBeNull();

            try
            {
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
                        RemoveAlgFromJwks = true
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
                    CustomizeMfaInPostLoginAction = true,
                    AcrValuesSupported = new[] { "value1", "value2" },
                    PushedAuthorizationRequestsSupported = true,
                    Mtls = new TenantMtls() { EnableEndpointAliases = true },
                    DefaultTokenQuota = new DefaultTokenQuota()
                    {
                        Clients = new TokenQuota()
                        {
                            ClientCredentials = new Quota()
                            {
                                Enforce = true,
                                PerDay = 200,
                                PerHour = 100
                            }
                        },
                        Organizations = new TokenQuota()
                        {
                            ClientCredentials = new Quota()
                            {
                                Enforce = true,
                                PerDay = 200,
                                PerHour = 100
                            }
                        },
                    },
                    LegacySandboxVersion = "12",
                    DefaultRedirectionUri = "https://www.example-domain.com/login",
                    Sessions = new Session()
                    {
                        OidcLogoutPromptEnabled = false
                    },
                    OidcLogout = new OidcLogout()
                    {
                        RpLogoutEndSessionEndpointDiscovery = false
                    },
                    AllowOrganizationNameInAuthenticationApi = false,
                    AuthorizationResponseIssParameterSupported = false
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
                settingsUpdateResponse.Flags.RemoveAlgFromJwks.Should().BeTrue();
                settingsUpdateResponse.CustomizeMfaInPostLoginAction.Should().BeTrue();
                settingsUpdateResponse.SessionCookie.Mode.Should().Be("persistent");
            }
            finally
            {
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
                    Flags = new TenantFlags()
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
                    DefaultTokenQuota = new DefaultTokenQuota()
                    {
                        Clients = new TokenQuota()
                        {
                            ClientCredentials = new Quota()
                            {
                                Enforce = false
                            }
                        },
                        Organizations = new TokenQuota()
                        {
                            ClientCredentials = new Quota()
                            {
                                Enforce = false
                            }
                        },
                    },
                    LegacySandboxVersion = null,
                    DefaultRedirectionUri = null,
                    Sessions = null,
                    OidcLogout = null,
                    AllowOrganizationNameInAuthenticationApi = null,
                    AuthorizationResponseIssParameterSupported = null
                }; 
                await apiClient.TenantSettings.UpdateAsync(resetUpdateRequest);
            }
        }
    }
}