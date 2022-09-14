using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class RulesConfigTestsFixture : TestBaseFixture
    {
        public readonly List<LogStream> TestCreatedStreams = new List<LogStream>();

        public override async Task DisposeAsync()
        {
            // Clean up any log stream entities on the tenant after every test executes
            var deleteTasks = TestCreatedStreams.Select(stream => ApiClient.LogStreams.DeleteAsync(stream.Id));

            await Task.WhenAll(deleteTasks.ToArray());
            await base.DisposeAsync();
        }
    }

    /// <summary>
    /// Tests functionality of the <see cref="RulesConfigClient"/> in the <see cref="ManagementApiClient"/>.
    /// </summary>
    public class RulesConfigTests : IClassFixture<RulesConfigTestsFixture>
    {
        RulesConfigTestsFixture fixture;

        public RulesConfigTests(RulesConfigTestsFixture fixture)
        {
            this.fixture = fixture;
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
                Key = TestBaseUtils.MakeRandomName(),
                Value = "i am iron man!"
            };
            var newRuleConfigResponse = await fixture.ApiClient.RulesConfig.CreateOrUpdateAsync(newRuleConfigRequest);
            newRuleConfigResponse.Should().NotBeNull();
            newRuleConfigResponse.Key.Should().Be(newRuleConfigRequest.Key);
            newRuleConfigResponse.Value.Should().NotBeNullOrEmpty();

            // delete the rule
            await fixture.ApiClient.RulesConfig.DeleteAsync(newRuleConfigRequest.Key);
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
                Key = TestBaseUtils.MakeRandomName(),
                Value = "i am iron man!"
            };
            var newRuleConfigResponse = await fixture.ApiClient.RulesConfig.CreateOrUpdateAsync(newRuleConfigRequest);
            newRuleConfigResponse.Should().NotBeNull();
            newRuleConfigResponse.Key.Should().Be(newRuleConfigRequest.Key);
            newRuleConfigResponse.Value.Should().NotBeNullOrEmpty();

            // update the rule
            var updateRuleConfigRequest = new RulesConfigCreateOrUpdateRequest
            {
                Key = newRuleConfigResponse.Key,
                Value = "avengers assemble!"
            };
            var updateRuleConfigResponse = await fixture.ApiClient.RulesConfig.CreateOrUpdateAsync(updateRuleConfigRequest);
            updateRuleConfigResponse.Should().NotBeNull();
            updateRuleConfigResponse.Key.Should().Be(newRuleConfigRequest.Key);
            updateRuleConfigResponse.Value.Should().NotBeNullOrEmpty();
            updateRuleConfigResponse.Value.Should().NotBe(newRuleConfigRequest.Value);

            // delete the rule
            await fixture.ApiClient.RulesConfig.DeleteAsync(newRuleConfigRequest.Key);

        }
    }
}
