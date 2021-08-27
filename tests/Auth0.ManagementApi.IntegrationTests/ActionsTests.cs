using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth0.ManagementApi.Actions;
using Auth0.ManagementApi.Paging;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class ActionsTests : TestBase, IAsyncLifetime
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
        public async Task Test_actions_crud_sequence()
        {
            var actionsBeforeCreate = await _apiClient.Actions.GetAllAsync(new GetActionsRequest(), new PaginationInfo());

            var createdAction = await _apiClient.Actions.CreateAsync(new CreateActionRequest
            {
                Name = $"Int-Test-Action-{Guid.NewGuid()}",
                Code = "module.exports = () => {}",
                Runtime = "node12",
                Secrets = new List<ActionSecret> { new ActionSecret { Name = "My_Secret", Value  = "Test123" } },
                SupportedTriggers = new List<ActionSupportedTrigger> { new ActionSupportedTrigger { Id = "post-login", Version = "v2"} }
            });

            var actionsAfterCreate = await _apiClient.Actions.GetAllAsync(new GetActionsRequest(), new PaginationInfo());

            actionsAfterCreate.Count.Should().Be(actionsBeforeCreate.Count + 1);
            createdAction.Should().BeEquivalentTo(actionsAfterCreate.Last(), options => options.Excluding(o => o.Status));

            var updatedAction = await _apiClient.Actions.UpdateAsync(createdAction.Id, new UpdateActionRequest
            {
                Code = "module.exports = () => { console.log(true); }"
            });

            updatedAction.Should().BeEquivalentTo(createdAction, options => options.Excluding(o => o.Code).Excluding(o => o.UpdatedAt));
            updatedAction.Code.Should().Be("module.exports = () => { console.log(true); }");

            var actionAfterUpdate = await _apiClient.Actions.GetAsync(updatedAction.Id);

            updatedAction.Should().BeEquivalentTo(actionAfterUpdate, options => options.Excluding(o => o.Status));
            actionAfterUpdate.Code.Should().Be("module.exports = () => { console.log(true); }");

            await _apiClient.Actions.DeleteAsync(actionAfterUpdate.Id);

            var actionsAfterDelete = await _apiClient.Actions.GetAllAsync(new GetActionsRequest(), new PaginationInfo());
            actionsAfterDelete.Count.Should().Be(actionsBeforeCreate.Count);
        }

        [Fact]
        public async Task Test_get_triggers()
        {
            var triggers = await _apiClient.Actions.GetAllTriggersAsync();

            triggers.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Test_get_and_update_trigger_bindings()
        {
            var triggerBindingsBeforeCreate = await _apiClient.Actions.GetAllTriggerBindingsAsync("post-login", new PaginationInfo());
            
            var createdAction = await _apiClient.Actions.CreateAsync(new CreateActionRequest
            {
                Name = $"Int-Test-Action-{Guid.NewGuid()}",
                Code = "module.exports = () => {}",
                Runtime = "node12",
                Secrets = new List<ActionSecret> { new ActionSecret { Name = "My_Secret", Value = "Test123" } },
                SupportedTriggers = new List<ActionSupportedTrigger> { new ActionSupportedTrigger { Id = "post-login", Version = "v2" } }
            });

            await _apiClient.Actions.DeployAsync(createdAction.Id);

            await _apiClient.Actions.UpdateTriggerBindingsAsync("post-login", new UpdateTriggerBindingsRequest
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

            var triggerBindingsAfterCreate = await _apiClient.Actions.GetAllTriggerBindingsAsync("post-login", new PaginationInfo());

            triggerBindingsAfterCreate.Count.Should().Be(triggerBindingsBeforeCreate.Count + 1);

            await _apiClient.Actions.UpdateTriggerBindingsAsync("post-login", new UpdateTriggerBindingsRequest
            {
                Bindings = new List<UpdateTriggerBindingEntry>()
            });

            await _apiClient.Actions.DeleteAsync(createdAction.Id);
        }

        [Fact]
        public async Task Test_action_version_crud_sequence()
        {
            // 1. Create a new Action
            var createdAction = await _apiClient.Actions.CreateAsync(new CreateActionRequest
            {
                Name = $"Int-Test-Action-{Guid.NewGuid()}",
                Code = "module.exports = () => {}",
                Runtime = "node12",
                Secrets = new List<ActionSecret> { new ActionSecret { Name = "My_Secret", Value = "Test123" } },
                SupportedTriggers = new List<ActionSupportedTrigger> { new ActionSupportedTrigger { Id = "post-login", Version = "v2" } }
            });

            // 2. Get all the versions after the action was created
            var versionsAfterCreate = await _apiClient.Actions.GetAllVersionsAsync(createdAction.Id, new PaginationInfo());
            
            versionsAfterCreate.Count.Should().Be(0);

            // 3. Deploy the current version
            await _apiClient.Actions.DeployAsync(createdAction.Id);

            // 4. Get all the versions after the action was deployed
            var versionsAfterDeploy = await _apiClient.Actions.GetAllVersionsAsync(createdAction.Id, new PaginationInfo());
            
            versionsAfterDeploy.Count.Should().Be(1);

            // 5. Update the action
            await _apiClient.Actions.UpdateAsync(createdAction.Id, new UpdateActionRequest
            {
                Code = "module.exports = () => { console.log(true); }"
            });

            // 6. Deploy the latest version
            var deployedVersion = await _apiClient.Actions.DeployAsync(createdAction.Id);
            
            // 7. Get all the versions after the action was updated
            var versionsAfterSecondDeploy = await _apiClient.Actions.GetAllVersionsAsync(createdAction.Id, new PaginationInfo());

            versionsAfterSecondDeploy.Count.Should().Be(2);
            versionsAfterSecondDeploy.Single(v => v.Id == deployedVersion.Id).Deployed.Should().BeTrue();
            versionsAfterSecondDeploy.Single(v => v.Id != deployedVersion.Id).Deployed.Should().BeFalse();

            // 9. Rollback
            var rollbackedVersion = await _apiClient.Actions.RollbackToVersionAsync(createdAction.Id, versionsAfterDeploy.Single().Id);

            // 10. Get all the versions after the action was rollbacked
            var versionsAfterRollback = await _apiClient.Actions.GetAllVersionsAsync(createdAction.Id, new PaginationInfo());
            var versionAfterRollback = await _apiClient.Actions.GetVersionAsync(createdAction.Id, rollbackedVersion.Id);

            versionsAfterRollback.Count.Should().Be(3);
            versionsAfterRollback.Single(v => v.Id == versionAfterRollback.Id).Should().BeEquivalentTo(versionAfterRollback);
            versionsAfterRollback.Single(v => v.Id == versionAfterRollback.Id).Deployed.Should().BeTrue();
            versionsAfterRollback.Where(v => v.Id != versionAfterRollback.Id).ToList().ForEach(v => v.Deployed.Should().BeFalse());

            // 10. Delete Action
            await _apiClient.Actions.DeleteAsync(createdAction.Id);
        }
    }
}
