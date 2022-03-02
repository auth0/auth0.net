using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models.Actions;
using Auth0.ManagementApi.Paging;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class ActionsTests : ManagementTestBase, IAsyncLifetime
    {
        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            ApiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 }));
        }

        public override Task DisposeAsync()
        {
            return CleanupAndDisposeAsync(CleanUpType.Actions);
        }

        [Fact]
        public async Task Test_actions_crud_sequence()
        {
            var actionsBeforeCreate = await ApiClient.Actions.GetAllAsync(new GetActionsRequest(), new PaginationInfo());

            var createdAction = await ApiClient.Actions.CreateAsync(new CreateActionRequest
            {
                Name = $"{TestingConstants.ActionPrefix}-{Guid.NewGuid()}",
                Code = "module.exports = () => {}",
                Runtime = "node12",
                Secrets = new List<ActionSecret> { new ActionSecret { Name = "My_Secret", Value  = "Test123" } },
                SupportedTriggers = new List<ActionSupportedTrigger> { new ActionSupportedTrigger { Id = "post-login", Version = "v2"} }
            });

            var actionsAfterCreate = await ApiClient.Actions.GetAllAsync(new GetActionsRequest(), new PaginationInfo());

            actionsAfterCreate.Count.Should().Be(actionsBeforeCreate.Count + 1);
            createdAction.Should().BeEquivalentTo(actionsAfterCreate.Last(), options => options.Excluding(o => o.Status));

            var updatedAction = await ApiClient.Actions.UpdateAsync(createdAction.Id, new UpdateActionRequest
            {
                Code = "module.exports = () => { console.log(true); }"
            });

            updatedAction.Should().BeEquivalentTo(createdAction, options => options.Excluding(o => o.Code).Excluding(o => o.UpdatedAt));
            updatedAction.Code.Should().Be("module.exports = () => { console.log(true); }");

            var actionAfterUpdate = await ApiClient.Actions.GetAsync(updatedAction.Id);

            updatedAction.Should().BeEquivalentTo(actionAfterUpdate, options => options.Excluding(o => o.Status));
            actionAfterUpdate.Code.Should().Be("module.exports = () => { console.log(true); }");

            await ApiClient.Actions.DeleteAsync(actionAfterUpdate.Id);

            var actionsAfterDelete = await ApiClient.Actions.GetAllAsync(new GetActionsRequest(), new PaginationInfo());
            actionsAfterDelete.Count.Should().Be(actionsBeforeCreate.Count);
        }

        [Fact]
        public async Task Test_get_triggers()
        {
            var triggers = await ApiClient.Actions.GetAllTriggersAsync();

            triggers.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Test_get_and_update_trigger_bindings()
        {
            var triggerBindingsBeforeCreate = await ApiClient.Actions.GetAllTriggerBindingsAsync("post-login", new PaginationInfo());
            
            var createdAction = await ApiClient.Actions.CreateAsync(new CreateActionRequest
            {
                Name = $"{TestingConstants.ActionPrefix}-{Guid.NewGuid()}",
                Code = "module.exports = () => {}",
                Runtime = "node12",
                Secrets = new List<ActionSecret> { new ActionSecret { Name = "My_Secret", Value = "Test123" } },
                SupportedTriggers = new List<ActionSupportedTrigger> { new ActionSupportedTrigger { Id = "post-login", Version = "v2" } }
            });

            await ApiClient.Actions.DeployAsync(createdAction.Id);

            await ApiClient.Actions.UpdateTriggerBindingsAsync("post-login", new UpdateTriggerBindingsRequest
            {
                Bindings = new List<UpdateTriggerBindingEntry>
                {
                    new UpdateTriggerBindingEntry
                    {
                        Ref = new UpdateTriggerBindingEntry.BindingRef
                        {
                            Type = "action_id",
                            Value = createdAction.Id
                        },
                        DisplayName = "My Action"
                    }
                }
            });

            var triggerBindingsAfterCreate = await ApiClient.Actions.GetAllTriggerBindingsAsync("post-login", new PaginationInfo());

            triggerBindingsAfterCreate.Count.Should().Be(triggerBindingsBeforeCreate.Count + 1);

            await ApiClient.Actions.UpdateTriggerBindingsAsync("post-login", new UpdateTriggerBindingsRequest
            {
                Bindings = new List<UpdateTriggerBindingEntry>()
            });

            await ApiClient.Actions.DeleteAsync(createdAction.Id);
        }

        [Fact]
        public async Task Test_action_version_crud_sequence()
        {
            // 1. Create a new Action
            var createdAction = await ApiClient.Actions.CreateAsync(new CreateActionRequest
            {
                Name = $"{TestingConstants.ActionPrefix}-{Guid.NewGuid()}",
                Code = "module.exports = () => {}",
                Runtime = "node12",
                Secrets = new List<ActionSecret> { new ActionSecret { Name = "My_Secret", Value = "Test123" } },
                SupportedTriggers = new List<ActionSupportedTrigger> { new ActionSupportedTrigger { Id = "post-login", Version = "v2" } }
            });

            // 2. Get all the versions after the action was created
            var versionsAfterCreate = await ApiClient.Actions.GetAllVersionsAsync(createdAction.Id, new PaginationInfo());
            
            versionsAfterCreate.Count.Should().Be(0);

            // 3. Deploy the current version
            await ApiClient.Actions.DeployAsync(createdAction.Id);

            // 4. Get all the versions after the action was deployed
            var versionsAfterDeploy = await ApiClient.Actions.GetAllVersionsAsync(createdAction.Id, new PaginationInfo());
            
            versionsAfterDeploy.Count.Should().Be(1);

            // 5. Update the action
            await ApiClient.Actions.UpdateAsync(createdAction.Id, new UpdateActionRequest
            {
                Code = "module.exports = () => { console.log(true); }"
            });

            // 6. Deploy the latest version
            var deployedVersion = await ApiClient.Actions.DeployAsync(createdAction.Id);
            
            // 7. Get all the versions after the action was updated
            var versionsAfterSecondDeploy = await ApiClient.Actions.GetAllVersionsAsync(createdAction.Id, new PaginationInfo());

            versionsAfterSecondDeploy.Count.Should().Be(2);
            versionsAfterSecondDeploy.Single(v => v.Id == deployedVersion.Id).Deployed.Should().BeTrue();
            versionsAfterSecondDeploy.Single(v => v.Id != deployedVersion.Id).Deployed.Should().BeFalse();

            var action = await ApiClient.Actions.GetAsync(createdAction.Id);
            action.DeployedVersion.Id.Should().Be(deployedVersion.Id);

            // 9. Rollback
            var rollbackedVersion = await ApiClient.Actions.RollbackToVersionAsync(createdAction.Id, versionsAfterDeploy.Single().Id);

            // 10. Get all the versions after the action was rollbacked
            var versionsAfterRollback = await ApiClient.Actions.GetAllVersionsAsync(createdAction.Id, new PaginationInfo());
            var versionAfterRollback = await ApiClient.Actions.GetVersionAsync(createdAction.Id, rollbackedVersion.Id);

            versionsAfterRollback.Count.Should().Be(3);
            versionsAfterRollback.Single(v => v.Id == versionAfterRollback.Id).Should().BeEquivalentTo(versionAfterRollback);
            versionsAfterRollback.Single(v => v.Id == versionAfterRollback.Id).Deployed.Should().BeTrue();
            versionsAfterRollback.Where(v => v.Id != versionAfterRollback.Id).ToList().ForEach(v => v.Deployed.Should().BeFalse());

            // 10. Delete Action
            await ApiClient.Actions.DeleteAsync(createdAction.Id);
        }
    }
}
