using System;
using System.Threading.Tasks;
using Auth0.Core;
using FluentAssertions;
using NUnit.Framework;
using Auth0.ManagementApi.Client.Models;

namespace Auth0.ManagementApi.Client.IntegrationTests
{
    [TestFixture]
    public class TenantSettingsTests : TestBase
    {
        [Test]
        public async Task Test_tenant_settings_sequence()
        {
            var apiClient = new ManagementApiClient(GetVariable("AUTH0_TOKEN_TENANT_SETTINGS"), new Uri(GetVariable("AUTH0_API_URL")));

            // Get the current settings
            var settings = apiClient.TenantSettings.Get();
            settings.Should().NotBeNull();

            // Update the tenant settings
            var settingsUpdateRequest = new TenantSettingsUpdateRequest
            {
                ErrorPage = new TenantErrorPage
                {
                    Html = null,
                    ShowLogLink = false,
                    Url = $"www.{Guid.NewGuid().ToString("N")}.aaa/error"
                },
                FriendlyName = Guid.NewGuid().ToString("N"),
                PictureUrl = $"www.{Guid.NewGuid().ToString("N")}.aaa/picture.png",
                SupportEmail = $"support@{Guid.NewGuid().ToString("N")}.aaa",
                SupportUrl = $"www.{Guid.NewGuid().ToString("N")}.aaa/support"
            };
            var settingsUpdateResponse = await apiClient.TenantSettings.Update(settingsUpdateRequest);
            settingsUpdateResponse.ShouldBeEquivalentTo(settingsUpdateRequest);
        }
    }
}