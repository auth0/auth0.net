using System;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.ManagementApi.Paging;
using System.Collections.Generic;
using Auth0.IntegrationTests.Shared.CleanUp;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class RulesTestsFixture : TestBaseFixture
    {
        public readonly List<LogStream> TestCreatedStreams = new List<LogStream>();

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
        RulesTestsFixture fixture;

        public RulesTests(RulesTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task Test_rules_crud_sequence()
        {
            // Get all rules
            var rulesBefore = await fixture.ApiClient.Rules.GetAllAsync(new GetRulesRequest(), new PaginationInfo());

            // Add a new rule
            var newRuleRequest = new RuleCreateRequest
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
            var rulesAfter = await fixture.ApiClient.Rules.GetAllAsync(new GetRulesRequest(), new PaginationInfo());
            rulesAfter.Count.Should().Be(rulesBefore.Count + 1);

            // Update the Rule
            var updateRuleRequest = new RuleUpdateRequest
            {
                Name = $"{TestingConstants.RulesRefix}-{Guid.NewGuid():N}"
            };
            var updateRuleResponse = await fixture.ApiClient.Rules.UpdateAsync(newRuleResponse.Id, updateRuleRequest);
            updateRuleResponse.Should().NotBeNull();
            updateRuleResponse.Name.Should().Be(updateRuleRequest.Name);

            // Get a single rule
            var rule = await fixture.ApiClient.Rules.GetAsync(newRuleResponse.Id);
            rule.Should().NotBeNull();
            rule.Name.Should().Be(updateRuleRequest.Name);

            // Delete the rule, and ensure we get exception when trying to fetch it again
            await fixture.ApiClient.Rules.DeleteAsync(rule.Id);
            Func<Task> getFunc = async () => await fixture.ApiClient.Rules.GetAsync(rule.Id);
            getFunc.Should().Throw<ErrorApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_rule");
            fixture.UnTrackIdentifier(CleanUpType.Rules, newRuleResponse.Id);
        }
        
        [Fact]
        public async Task Test_when_paging_not_specified_does_not_include_totals()
        {
            // Act
            var rules = await fixture.ApiClient.Rules.GetAllAsync(new GetRulesRequest(), new PaginationInfo());
            
            // Assert
            Assert.Null(rules.Paging);
        }

        [Fact]
        public async Task Test_paging_does_not_include_totals()
        {
            // Act
            var rules = await fixture.ApiClient.Rules.GetAllAsync(new GetRulesRequest(), new PaginationInfo(0, 50, false));
            
            // Assert
            Assert.Null(rules.Paging);
        }

        [Fact]
        public async Task Test_paging_includes_totals()
        {
            // Act
            var rules = await fixture.ApiClient.Rules.GetAllAsync(new GetRulesRequest(), new PaginationInfo(0, 50, true));
            
            // Assert
            Assert.NotNull(rules.Paging);
        }

        [Fact]
        public async Task Test_without_paging()
        {
            // Add a new rule
            var newRule = await fixture.ApiClient.Rules.CreateAsync(new RuleCreateRequest
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
            var rules = await fixture.ApiClient.Rules.GetAllAsync(new GetRulesRequest());

            // Assert
            rules.Paging.Should().BeNull();
            rules.Count.Should().BeGreaterThan(0);

            await fixture.ApiClient.Rules.DeleteAsync(newRule.Id);
            fixture.UnTrackIdentifier(CleanUpType.Rules, newRule.Id);
        }
    }
}