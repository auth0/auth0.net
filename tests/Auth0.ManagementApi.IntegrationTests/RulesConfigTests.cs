using Auth0.Tests.Shared;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class RulesConfigTestsFixture : TestBaseFixture
{
}

/// <summary>
/// Tests functionality of the RulesConfigsClient in the ManagementClient.
/// </summary>
public class RulesConfigTests : IClassFixture<RulesConfigTestsFixture>
{
    private RulesConfigTestsFixture fixture;

    public RulesConfigTests(RulesConfigTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    /// <summary>
    /// Tests that a rules config variable can be created and then deleted
    /// </summary>
    [Fact]
    public async Task Test_ruleConfigs_limited_crud_sequence()
    {
        //NOTE: cannot read config, so create a unique name and just test PUT + DELETE
        var key = TestBaseUtils.MakeRandomName();

        // Add a new rule config
        var newRuleConfigResponse = await fixture.ApiClient.RulesConfigs.SetAsync(key, new SetRulesConfigRequestContent
        {
            Value = "i am iron man!"
        });
        newRuleConfigResponse.Key.Should().Be(key);
        newRuleConfigResponse.Value.Should().NotBeNullOrEmpty();

        // delete the rule config
        await fixture.ApiClient.RulesConfigs.DeleteAsync(key);
    }

    /// <summary>
    /// Tests that the same method can be used to create a new variable and also update an existing variable.
    /// This is necessary because we cannot use the API to get existing variables, so it cannot be known if we are creating or updating an entry.
    /// </summary>
    [Fact]
    public async Task Test_ruleConfigs_can_update_existing()
    {
        var key = TestBaseUtils.MakeRandomName();

        // Add a new rule config
        var newRuleConfigResponse = await fixture.ApiClient.RulesConfigs.SetAsync(key, new SetRulesConfigRequestContent
        {
            Value = "i am iron man!"
        });
        newRuleConfigResponse.Key.Should().Be(key);
        newRuleConfigResponse.Value.Should().NotBeNullOrEmpty();

        // update the rule config
        var updateRuleConfigResponse = await fixture.ApiClient.RulesConfigs.SetAsync(key, new SetRulesConfigRequestContent
        {
            Value = "avengers assemble!"
        });
        updateRuleConfigResponse.Key.Should().Be(key);
        updateRuleConfigResponse.Value.Should().NotBeNullOrEmpty();
        updateRuleConfigResponse.Value.Should().NotBe(newRuleConfigResponse.Value);

        // delete the rule config
        await fixture.ApiClient.RulesConfigs.DeleteAsync(key);
    }
}
