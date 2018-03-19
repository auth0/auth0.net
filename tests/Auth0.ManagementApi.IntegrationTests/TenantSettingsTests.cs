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
        [Fact(Skip ="Need to add support for default directory")]
        public async Task Test_tenant_settings_sequence()
        {
            string token = await GenerateManagementApiToken();

            var apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));

            // Get the current settings
            var settings = apiClient.TenantSettings.GetAsync();
            settings.Should().NotBeNull();

            // Update the tenant settings
            var settingsUpdateRequest = new TenantSettingsUpdateRequest
            {
                ErrorPage = new TenantErrorPage
                {
                    Html = null,
                    ShowLogLink = false,
                    Url = $"www.{Guid.NewGuid():N}.aaa/error"
                },
                FriendlyName = Guid.NewGuid().ToString("N"),
                PictureUrl = $"www.{Guid.NewGuid():N}.aaa/picture.png",
                SupportEmail = $"support@{Guid.NewGuid():N}.aaa",
                SupportUrl = $"www.{Guid.NewGuid():N}.aaa/support"
            };
            var settingsUpdateResponse = await apiClient.TenantSettings.UpdateAsync(settingsUpdateRequest);
            settingsUpdateResponse.ShouldBeEquivalentTo(settingsUpdateRequest);
        }
    }
}