using System;
using System.Linq;
using System.Threading.Tasks;
using Auth0.ManagementApi.IntegrationTests.Testing;
using FluentAssertions;
using Xunit;
using System.Collections.Generic;
using Auth0.IntegrationTests.Shared.CleanUp;

namespace Auth0.ManagementApi.IntegrationTests;

public class RulesTestsFixture : TestBaseFixture
{
    public override async Task DisposeAsync()
    {
        foreach (KeyValuePair<CleanUpType, IList<string>> entry in identifiers)
        {
            await ManagementTestBaseUtils.CleanupAsync(ApiClient, entry.Key, entry.Value);
        }

        ApiClient.Dispose();
    }
}

public class RulesTests : IClassFixture<RulesTestsFixture>
{
    private RulesTestsFixture fixture;

    public RulesTests(RulesTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact(Skip = "Rules have been deprecated as on 18th November 2024")]
    public async Task Test_rules_crud_sequence()
    {
        // Get all rules
        var rulesBeforePager = await fixture.ApiClient.Rules.ListAsync(new ListRulesRequestParameters());
        var rulesBefore = rulesBeforePager.CurrentPage.Items.ToList();

        // Add a new rule
        var newRuleRequest = new CreateRuleRequestContent
        {
            Name = $"{TestingConstants.RulesRefix}-{Guid.NewGuid():N}",
            Script = @"function (user, context, callback) {
                              // TODO: implement your rule
                              callback(null, user, context);
                            }"
        };
        var newRuleResponse = await fixture.ApiClient.Rules.CreateAsync(newRuleRequest);
        fixture.TrackIdentifier(CleanUpType.Rules, newRuleResponse.Id);

        newRuleResponse.Should().NotBeNull();
        newRuleResponse.Name.Should().Be(newRuleRequest.Name);

        // Get all the rules again, and check that we now have one more
        var rulesAfterPager = await fixture.ApiClient.Rules.ListAsync(new ListRulesRequestParameters());
        var rulesAfter = rulesAfterPager.CurrentPage.Items.ToList();
        rulesAfter.Count.Should().Be(rulesBefore.Count + 1);

        // Update the Rule
        var updateRuleRequest = new UpdateRuleRequestContent
        {
            Name = $"{TestingConstants.RulesRefix}-{Guid.NewGuid():N}"
        };
        var updateRuleResponse = await fixture.ApiClient.Rules.UpdateAsync(newRuleResponse.Id, updateRuleRequest);
        updateRuleResponse.Should().NotBeNull();
        updateRuleResponse.Name.Should().Be(updateRuleRequest.Name);

        // Get a single rule
        var rule = await fixture.ApiClient.Rules.GetAsync(newRuleResponse.Id, new GetRuleRequestParameters());
        rule.Should().NotBeNull();
        rule.Name.Should().Be(updateRuleRequest.Name);

        // Delete the rule, and ensure we get exception when trying to fetch it again
        await fixture.ApiClient.Rules.DeleteAsync(rule.Id);
        Func<Task> getFunc = async () => await fixture.ApiClient.Rules.GetAsync(rule.Id, new GetRuleRequestParameters());
        await getFunc.Should().ThrowAsync<NotFoundError>();
        fixture.UnTrackIdentifier(CleanUpType.Rules, newRuleResponse.Id);
    }

    [Fact]
    public async Task Test_when_paging_not_specified_does_not_include_totals()
    {
        // Act
        var rulesPager = await fixture.ApiClient.Rules.ListAsync(new ListRulesRequestParameters());

        // Assert
        rulesPager.CurrentPage.Items.Should().NotBeNull();
    }

    [Fact]
    public async Task Test_paging_with_totals()
    {
        // Act
        var rulesPager = await fixture.ApiClient.Rules.ListAsync(new ListRulesRequestParameters
        {
            Page = 0,
            PerPage = 50,
            IncludeTotals = true
        });

        // Assert
        rulesPager.CurrentPage.Items.Should().NotBeNull();
    }

    [Fact]
    public async Task Test_paging_includes_totals()
    {
        // Act
        var rulesPager = await fixture.ApiClient.Rules.ListAsync(new ListRulesRequestParameters
        {
            Page = 0,
            PerPage = 50,
            IncludeTotals = true
        });

        // Assert
        rulesPager.CurrentPage.Items.Should().NotBeNull();
    }

    [Fact(Skip = "Rules have been deprecated as on 18th November 2024")]
    public async Task Test_without_paging()
    {
        // Add a new rule
        var newRule = await fixture.ApiClient.Rules.CreateAsync(new CreateRuleRequestContent
        {
            Name = $"i{TestingConstants.RulesRefix}-{Guid.NewGuid():N}",
            Script = @"function (user, context, callback) {
                              // TODO: implement your rule
                              callback(null, user, context);
                            }"
        });
        fixture.TrackIdentifier(CleanUpType.Rules, newRule.Id);

        newRule.Should().NotBeNull();

        // Act
        var rulesPager = await fixture.ApiClient.Rules.ListAsync(new ListRulesRequestParameters());

        // Assert
        var rules = rulesPager.CurrentPage.Items.ToList();
        rules.Count.Should().BeGreaterThan(0);

        await fixture.ApiClient.Rules.DeleteAsync(newRule.Id);
        fixture.UnTrackIdentifier(CleanUpType.Rules, newRule.Id);
    }
}
