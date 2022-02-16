using System;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;
using Auth0.ManagementApi.Paging;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class RulesTests : ManagementTestBase, IAsyncLifetime
    {
        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();
            ApiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 }));
        }

        public override Task DisposeAsync()
        {
            return CleanupAndDisposeAsync();
        }

        [Fact]
        public async Task Test_rules_crud_sequence()
        {
            // Get all rules
            var rulesBefore = await ApiClient.Rules.GetAllAsync(new GetRulesRequest(), new PaginationInfo());

            // Add a new rule
            var newRuleRequest = new RuleCreateRequest
            {
                Name = $"integration-test-rule-{Guid.NewGuid():N}",
                Script = @"function (user, context, callback) {
                              // TODO: implement your rule
                              callback(null, user, context);
                            }"
            };
            var newRuleResponse = await ApiClient.Rules.CreateAsync(newRuleRequest);
            newRuleResponse.Should().NotBeNull();
            newRuleResponse.Name.Should().Be(newRuleRequest.Name);

            // Get all the rules again, and check that we now have one more
            var rulesAfter = await ApiClient.Rules.GetAllAsync(new GetRulesRequest(), new PaginationInfo());
            rulesAfter.Count.Should().Be(rulesBefore.Count + 1);

            // Update the Rule
            var updateRuleRequest = new RuleUpdateRequest
            {
                Name = $"integration-test-rule-{Guid.NewGuid():N}"
            };
            var updateRuleResponse = await ApiClient.Rules.UpdateAsync(newRuleResponse.Id, updateRuleRequest);
            updateRuleResponse.Should().NotBeNull();
            updateRuleResponse.Name.Should().Be(updateRuleRequest.Name);

            // Get a single rule
            var rule = await ApiClient.Rules.GetAsync(newRuleResponse.Id);
            rule.Should().NotBeNull();
            rule.Name.Should().Be(updateRuleRequest.Name);

            // Delete the rule, and ensure we get exception when trying to fetch it again
            await ApiClient.Rules.DeleteAsync(rule.Id);
            Func<Task> getFunc = async () => await ApiClient.Rules.GetAsync(rule.Id);
            getFunc.Should().Throw<ErrorApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_rule");
        }
        
        [Fact]
        public async Task Test_when_paging_not_specified_does_not_include_totals()
        {
            // Act
            var rules = await ApiClient.Rules.GetAllAsync(new GetRulesRequest(), new PaginationInfo());
            
            // Assert
            Assert.Null(rules.Paging);
        }

        [Fact]
        public async Task Test_paging_does_not_include_totals()
        {
            // Act
            var rules = await ApiClient.Rules.GetAllAsync(new GetRulesRequest(), new PaginationInfo(0, 50, false));
            
            // Assert
            Assert.Null(rules.Paging);
        }

        [Fact]
        public async Task Test_paging_includes_totals()
        {
            // Act
            var rules = await ApiClient.Rules.GetAllAsync(new GetRulesRequest(), new PaginationInfo(0, 50, true));
            
            // Assert
            Assert.NotNull(rules.Paging);
        }

        [Fact]
        public async Task Test_without_paging()
        {
            // Add a new rule
            var newRule = await ApiClient.Rules.CreateAsync(new RuleCreateRequest
            {
                Name = $"integration-test-rule-{Guid.NewGuid():N}",
                Script = @"function (user, context, callback) {
                              // TODO: implement your rule
                              callback(null, user, context);
                            }"
            });

            newRule.Should().NotBeNull();

            // Act
            var rules = await ApiClient.Rules.GetAllAsync(new GetRulesRequest());

            // Assert
            rules.Paging.Should().BeNull();
            rules.Count.Should().BeGreaterThan(0);

            await ApiClient.Rules.DeleteAsync(newRule.Id);
        }
    }
}