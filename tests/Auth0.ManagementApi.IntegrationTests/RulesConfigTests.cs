using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;


namespace Auth0.ManagementApi.IntegrationTests
{
    /// <summary>
    /// Tests functionality of the <see cref="RulesConfigClient"/> in the <see cref="ManagementApiClient"/>.
    /// </summary>
    public class RulesConfigTests : ManagementTestBase, IAsyncLifetime
    {
        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            ApiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 }));
        }

        /// <summary>
        /// Tests that a rules config variable can be created and then deleted
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test_ruleConfigs_limited_crud_sequence()
        {
            //NOTE: cannot read config, so create a unique name and just test PUT + DELETE

            // Add a new rule
            var newRuleConfigRequest = new RulesConfigCreateOrUpdateRequest
            {
                Key = MakeRandomName(),
                Value = "i am iron man!"
            };
            var newRuleConfigResponse = await ApiClient.RulesConfig.CreateOrUpdateAsync(newRuleConfigRequest);
            newRuleConfigResponse.Should().NotBeNull();
            newRuleConfigResponse.Key.Should().Be(newRuleConfigRequest.Key);
            newRuleConfigResponse.Value.Should().NotBeNullOrEmpty();

            // delete the rule
            await ApiClient.RulesConfig.DeleteAsync(newRuleConfigRequest.Key);
        }

        /// <summary>
        /// Tests that the same method can be used to create a new variable and also update an existing variable.
        /// This is necessary because we cannot use the API to get existing variables, so it cannot be known if we are creating or updating an entry.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test_ruleConfigs_can_update_existing()
        {
            // Add a new rule
            var newRuleConfigRequest = new RulesConfigCreateOrUpdateRequest
            {
                Key = MakeRandomName(),
                Value = "i am iron man!"
            };
            var newRuleConfigResponse = await ApiClient.RulesConfig.CreateOrUpdateAsync(newRuleConfigRequest);
            newRuleConfigResponse.Should().NotBeNull();
            newRuleConfigResponse.Key.Should().Be(newRuleConfigRequest.Key);
            newRuleConfigResponse.Value.Should().NotBeNullOrEmpty();

            // update the rule
            var updateRuleConfigRequest = new RulesConfigCreateOrUpdateRequest
            {
                Key = newRuleConfigResponse.Key,
                Value = "avengers assemble!"
            };
            var updateRuleConfigResponse = await ApiClient.RulesConfig.CreateOrUpdateAsync(updateRuleConfigRequest);
            updateRuleConfigResponse.Should().NotBeNull();
            updateRuleConfigResponse.Key.Should().Be(newRuleConfigRequest.Key);
            updateRuleConfigResponse.Value.Should().NotBeNullOrEmpty();
            updateRuleConfigResponse.Value.Should().NotBe(newRuleConfigRequest.Value);

            // delete the rule
            await ApiClient.RulesConfig.DeleteAsync(newRuleConfigRequest.Key);

        }
    }
}
