using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;


namespace Auth0.ManagementApi.IntegrationTests
{
    public class RuleConfigsTests : TestBase, IAsyncLifetime
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
        public async Task Test_ruleConfigs_limited_crud_sequence()
        {
            //NOTE: cannot read config, so create a unique name and just test PUT + DELETE

            // Add a new rule
            var newRuleConfigRequest = new RuleConfigCreateRequest
            {
                Key = MakeRandomName(),
                Value = "i am iron man!"
            };
            var newRuleConfigResponse = await _apiClient.RuleConfigs.CreateAsync(newRuleConfigRequest);
            newRuleConfigResponse.Should().NotBeNull();
            newRuleConfigResponse.Key.Should().Be(newRuleConfigRequest.Key);
            newRuleConfigResponse.Value.Should().NotBeNullOrEmpty();

            // delete the rule
            await _apiClient.RuleConfigs.DeleteAsync(newRuleConfigRequest.Key);

        }
    }
}
