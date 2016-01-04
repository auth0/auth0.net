using System;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using NUnit.Framework;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    [TestFixture]
    public class TenantSettingsTests : TestBase
    {
        [Test]
        public async Task Test_tenant_settings_sequence()
        {
            var scopes = new
            {
                tenant_settings = new
                {
                    actions = new string[] { "read", "update" }
                }
            };
            string token = GenerateToken(scopes);

            var apiClient = new ManagementApiClient(token, new Uri(GetVariable("AUTH0_MANAGEMENT_API_URL")));

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