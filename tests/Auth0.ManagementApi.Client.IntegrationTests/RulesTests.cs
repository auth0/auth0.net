using System;
using System.Threading.Tasks;
using Auth0.Core.Models;
using Auth0.ManagementApi.Client.Exceptions;
using FluentAssertions;
using NUnit.Framework;

namespace Auth0.ManagementApi.Client.IntegrationTests
{
    [TestFixture]
    public class RulesTests : TestBase
    {
        [Test]
        public async Task Test_rules_crud_sequence()
        {
            var apiClient = new ManagementApiClient(GetVariable("AUTH0_TOKEN_RULES"), new Uri(GetVariable("AUTH0_API_URL")));

            // Get all rules
            var rulesBefore = await apiClient.Rules.GetAll();

            // Add a new rule
            var newRuleRequest = new RuleCreateRequest
            {
                Name = $"integration-test-rule-{Guid.NewGuid().ToString("N")}",
                Script = @"function (user, context, callback) {
                              // TODO: implement your rule
                              callback(null, user, context);
                            }"
            };
            var newRuleResponse = await apiClient.Rules.Create(newRuleRequest);
            newRuleResponse.Should().NotBeNull();
            newRuleResponse.Name.Should().Be(newRuleRequest.Name);

            // Get all the rules again, and check that we now have one more
            var rulesAfter = await apiClient.Rules.GetAll();
            rulesAfter.Count.Should().Be(rulesBefore.Count + 1);

            // Update the Rule
            var updateRuleRequest = new RuleUpdateRequest
            {
                Name = $"integration-test-rule-{Guid.NewGuid().ToString("N")}"
            };
            var updateRuleResponse = await apiClient.Rules.Update(newRuleResponse.Id, updateRuleRequest);
            updateRuleResponse.Should().NotBeNull();
            updateRuleResponse.Name.Should().Be(updateRuleRequest.Name);

            // Get a single rule
            var rule = await apiClient.Rules.Get(newRuleResponse.Id);
            rule.Should().NotBeNull();
            rule.Name.Should().Be(updateRuleRequest.Name);

            // Delete the rule, and ensure we get exception when trying to fetch it again
            await apiClient.Rules.Delete(rule.Id);
            Func<Task> getFunc = async () => await apiClient.Rules.Get(rule.Id);
            getFunc.ShouldThrow<ApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_rule");
        }
    }
}