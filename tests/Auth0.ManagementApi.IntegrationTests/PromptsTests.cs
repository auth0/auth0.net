using System.Collections.Generic;
using FluentAssertions;
using System.Threading.Tasks;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.Tests.Shared;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class PromptsTestsFixture : TestBaseFixture
{
    public override Task DisposeAsync()
    {
        ApiClient.Dispose();
        return Task.CompletedTask;
    }
}

public class PromptsTests : IClassFixture<PromptsTestsFixture>
{
    private PromptsTestsFixture fixture;

    public PromptsTests(PromptsTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Test_get_and_update_prompts()
    {
        var prompts = await fixture.ApiClient.Prompts.GetSettingsAsync();
        prompts.Should().NotBeNull();

        var originalExperience = prompts.UniversalLoginExperience;
        var newExperience = originalExperience == UniversalLoginExperienceEnum.Classic
            ? UniversalLoginExperienceEnum.New
            : UniversalLoginExperienceEnum.Classic;

        await fixture.ApiClient.Prompts.UpdateSettingsAsync(new UpdateSettingsRequestContent { UniversalLoginExperience = newExperience });

        prompts = await fixture.ApiClient.Prompts.GetSettingsAsync();
        prompts.Should().NotBeNull();
        prompts.UniversalLoginExperience.Should().Be(newExperience);

        await fixture.ApiClient.Prompts.UpdateSettingsAsync(new UpdateSettingsRequestContent { UniversalLoginExperience = originalExperience });

        prompts = await fixture.ApiClient.Prompts.GetSettingsAsync();
        prompts.Should().NotBeNull();
        prompts.UniversalLoginExperience.Should().Be(originalExperience);
    }

    [Fact]
    public async Task Test_set_and_get_custom_text_for_prompt()
    {
        var customText = new Dictionary<string, object?>
        {
            { "login", new Dictionary<string, object?>
                {
                    { "title", "welcome to auth0" }
                }
            }
        };
        await fixture.ApiClient.Prompts.CustomText.SetAsync(PromptGroupNameEnum.Login, PromptLanguageEnum.En, customText);

        var updatedCustomText = await fixture.ApiClient.Prompts.CustomText.GetAsync(PromptGroupNameEnum.Login, PromptLanguageEnum.En);

        updatedCustomText.Should().NotBeNull();
        updatedCustomText.Should().ContainKey("login");
    }

    [Fact(Skip = "Requires BRUCKE_MANAGEMENT_API credentials")]
    public async Task Test_set_and_get_partials()
    {
        var managementApiUrl = TestBaseUtils.GetVariable("BRUCKE_MANAGEMENT_API_URL");
        var domain = managementApiUrl.Replace("https://", "").TrimEnd('/');

        using (var apiClient = new ManagementClient(new ManagementClientOptions
        {
            Domain = domain,
            TokenProvider = new ClientCredentialsTokenProvider(domain, TestBaseUtils.GetVariable("BRUCKE_MANAGEMENT_API_CLIENT_ID"), TestBaseUtils.GetVariable("BRUCKE_MANAGEMENT_API_CLIENT_SECRET"))
        }))
        {
            var partial = new Dictionary<string, object?>
            {
                { "signup-id", new Dictionary<string, object?>
                    {
                        { "form-content-start", "<div>HTML or Liquid</div>" },
                        { "form-content-end", "<div>HTML or Liquid</div>" }
                    }
                }
            };
            await apiClient.Prompts.Partials.SetAsync(PartialGroupsEnum.SignupId, partial);

            var updatedPartials = await apiClient.Prompts.Partials.GetAsync(PartialGroupsEnum.SignupId);

            updatedPartials.Should().NotBeNull();
            updatedPartials.Should().ContainKey("signup-id");
        }
    }
}
