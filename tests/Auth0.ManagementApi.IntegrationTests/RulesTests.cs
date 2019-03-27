using System;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class RulesTests : TestBase, IAsyncLifetime
    {
        private ManagementApiClient _apiClient;

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            _apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async Task Test_rules_crud_sequence()
        {
            // Get all rules
            var rulesBefore = await _apiClient.Rules.GetAllAsync(new GetRulesRequest(), new PaginationInfo());

            // Add a new rule
            var newRuleRequest = new RuleCreateRequest
            {
                Name = $"integration-test-rule-{Guid.NewGuid():N}",
                Script = @"function (user, context, callback) {
                              // TODO: implement your rule
                              callback(null, user, context);
                            }"
            };
            var newRuleResponse = await _apiClient.Rules.CreateAsync(newRuleRequest);
            newRuleResponse.Should().NotBeNull();
            newRuleResponse.Name.Should().Be(newRuleRequest.Name);

            // Get all the rules again, and check that we now have one more
            var rulesAfter = await _apiClient.Rules.GetAllAsync(new GetRulesRequest(), new PaginationInfo());
            rulesAfter.Count.Should().Be(rulesBefore.Count + 1);

            // Update the Rule
            var updateRuleRequest = new RuleUpdateRequest
            {
                Name = $"integration-test-rule-{Guid.NewGuid():N}"
            };
            var updateRuleResponse = await _apiClient.Rules.UpdateAsync(newRuleResponse.Id, updateRuleRequest);
            updateRuleResponse.Should().NotBeNull();
            updateRuleResponse.Name.Should().Be(updateRuleRequest.Name);

            // Get a single rule
            var rule = await _apiClient.Rules.GetAsync(newRuleResponse.Id);
            rule.Should().NotBeNull();
            rule.Name.Should().Be(updateRuleRequest.Name);

            // Delete the rule, and ensure we get exception when trying to fetch it again
            await _apiClient.Rules.DeleteAsync(rule.Id);
            Func<Task> getFunc = async () => await _apiClient.Rules.GetAsync(rule.Id);
            getFunc.Should().Throw<ApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_rule");
        }
        
        [Fact]
        public async Task Test_when_paging_not_specified_does_not_include_totals()
        {
            // Act
            var rules = await _apiClient.Rules.GetAllAsync(new GetRulesRequest(), new PaginationInfo());
            
            // Assert
            Assert.Null(rules.Paging);
        }

        [Fact]
        public async Task Test_paging_does_not_include_totals()
        {
            // Act
            var rules = await _apiClient.Rules.GetAllAsync(new GetRulesRequest(), new PaginationInfo(0, 50, false));
            
            // Assert
            Assert.Null(rules.Paging);
        }

        [Fact]
        public async Task Test_paging_includes_totals()
        {
            // Act
            var rules = await _apiClient.Rules.GetAllAsync(new GetRulesRequest(), new PaginationInfo(0, 50, true));
            
            // Assert
            Assert.NotNull(rules.Paging);
        }
    }
}