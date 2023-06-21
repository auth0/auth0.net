using Auth0.Tests.Shared;
using FluentAssertions;
using System.Threading.Tasks;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models.Prompts;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class PromptsTests : ManagementTestBase, IAsyncLifetime
    {
        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            ApiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 }));
        }

        [Fact]
        public async Task Test_get_and_update_prompts()
        {
            var prompts = await ApiClient.Prompts.GetAsync();
            prompts.Should().NotBeNull();

            var originalExperience = prompts.UniversalLoginExperience;
            var newExperience = originalExperience == "classic" ? "new" : "classic";

            await ApiClient.Prompts.UpdateAsync(new PromptUpdateRequest {UniversalLoginExperience = newExperience });

            prompts = await ApiClient.Prompts.GetAsync();
            prompts.Should().NotBeNull();
            prompts.UniversalLoginExperience.Should().Be(newExperience);

            await ApiClient.Prompts.UpdateAsync(new PromptUpdateRequest { UniversalLoginExperience = originalExperience });

            prompts = await ApiClient.Prompts.GetAsync();
            prompts.Should().NotBeNull();
            prompts.UniversalLoginExperience.Should().Be(originalExperience);
        }
    }
}
