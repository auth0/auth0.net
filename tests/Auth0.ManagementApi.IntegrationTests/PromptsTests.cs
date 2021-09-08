using Auth0.Tests.Shared;
using FluentAssertions;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models.Prompts;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class PromptsTests : TestBase, IAsyncLifetime
    {
        private ManagementApiClient _apiClient;
        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            _apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 }));
        }

        public Task DisposeAsync()
        {
            _apiClient.Dispose();
            return Task.CompletedTask;
        }

        [Fact]
        public async Task Test_get_and_update_prompts()
        {
            var prompts = await _apiClient.Prompts.GetAsync();
            prompts.Should().NotBeNull();

            var originalExperience = prompts.UniversalLoginExperience;
            var newExperience = originalExperience == "classic" ? "new" : "classic";

            await _apiClient.Prompts.UpdateAsync(new PromptUpdateRequest {UniversalLoginExperience = newExperience });

            prompts = await _apiClient.Prompts.GetAsync();
            prompts.Should().NotBeNull();
            prompts.UniversalLoginExperience.Should().Be(newExperience);

            await _apiClient.Prompts.UpdateAsync(new PromptUpdateRequest { UniversalLoginExperience = originalExperience });

            prompts = await _apiClient.Prompts.GetAsync();
            prompts.Should().NotBeNull();
            prompts.UniversalLoginExperience.Should().Be(originalExperience);
        }
    }
}
