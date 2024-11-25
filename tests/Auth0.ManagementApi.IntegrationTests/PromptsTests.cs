using System.Collections.Generic;
using FluentAssertions;
using System.Threading.Tasks;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models.Prompts;
using Newtonsoft.Json;
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
        
        [Fact]
        public async Task Test_set_and_get_custom_text_for_prompt()
        {
            var customText = new Dictionary<string, Dictionary<string,string>>()
            {
                { "login", new Dictionary<string, string>()
                    {
                        { "title", "welcome to auth0" }
                    } 
                }
            };
            await ApiClient.Prompts.SetCustomTextForPromptAsync("login", "en", customText);
            
            var updatedCustomText = await ApiClient.Prompts.GetCustomTextForPromptAsync("login", "en");

            updatedCustomText.Should().NotBeNull();
            var udpatedCustomTextObject = 
                JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string,string>>>(
                    updatedCustomText?.ToString()); 
            customText.Should().BeEquivalentTo(udpatedCustomTextObject);
        }
        
        [Fact]
        public async Task Test_set_and_get_partials()
        {
            string token = await GenerateBruckeManagementApiToken();

            using (var apiClient = new ManagementApiClient(token, GetVariable("BRUCKE_MANAGEMENT_API_URL")))
            {
                var partial = new Dictionary<string, Dictionary<string,string>>()
                {
                    { "signup-id", new Dictionary<string, string>()
                        {
                            { "form-content-start", "<div>HTML or Liquid</div>" },
                            { "form-content-end", "<div>HTML or Liquid</div>" }
                        } 
                    }
                };
                await apiClient.Prompts.SetPartialsAsync("signup-id", partial);
            
                var updatedPartials = await apiClient.Prompts.GetPartialsAsync("signup-id");

                updatedPartials.Should().NotBeNull();
                var updatedPartialsObject = 
                    JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string,string>>>(
                        updatedPartials?.ToString()); 
                partial.Should().BeEquivalentTo(updatedPartialsObject);
            }
        }
    }
}
