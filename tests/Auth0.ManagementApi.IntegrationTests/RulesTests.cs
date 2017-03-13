using System;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class RulesTests : TestBase
    {
        [Fact]
        public async Task Test_rules_crud_sequence()
        {
            string token = await GenerateManagementApiToken();

            var apiClient = new ManagementApiClient(token, new Uri(GetVariable("AUTH0_MANAGEMENT_API_URL")));

            // Get all rules
            var rulesBefore = await apiClient.Rules.GetAllAsync();

            // Add a new rule
            var newRuleRequest = new RuleCreateRequest
            {
                Name = $"integration-test-rule-{Guid.NewGuid().ToString("N")}",
                Script = @"function (user, context, callback) {
                              // TODO: implement your rule
                              callback(null, user, context);
                            }"
            };
            var newRuleResponse = await apiClient.Rules.CreateAsync(newRuleRequest);
            newRuleResponse.Should().NotBeNull();
            newRuleResponse.Name.Should().Be(newRuleRequest.Name);

            // Get all the rules again, and check that we now have one more
            var rulesAfter = await apiClient.Rules.GetAllAsync();
            rulesAfter.Count.Should().Be(rulesBefore.Count + 1);

            // Update the Rule
            var updateRuleRequest = new RuleUpdateRequest
            {
                Name = $"integration-test-rule-{Guid.NewGuid().ToString("N")}"
            };
            var updateRuleResponse = await apiClient.Rules.UpdateAsync(newRuleResponse.Id, updateRuleRequest);
            updateRuleResponse.Should().NotBeNull();
            updateRuleResponse.Name.Should().Be(updateRuleRequest.Name);

            // Get a single rule
            var rule = await apiClient.Rules.GetAsync(newRuleResponse.Id);
            rule.Should().NotBeNull();
            rule.Name.Should().Be(updateRuleRequest.Name);

            // Delete the rule, and ensure we get exception when trying to fetch it again
            await apiClient.Rules.DeleteAsync(rule.Id);
            Func<Task> getFunc = async () => await apiClient.Rules.GetAsync(rule.Id);
            getFunc.ShouldThrow<ApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_rule");
        }
    }
}