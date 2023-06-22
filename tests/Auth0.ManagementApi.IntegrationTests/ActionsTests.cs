using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models.Actions;
using Auth0.ManagementApi.Paging;
using FluentAssertions;
using Xunit;


namespace Auth0.ManagementApi.IntegrationTests
{

    public class ActionsTestsFixture : TestBaseFixture
    {
        public override async Task DisposeAsync()
        {
            foreach (KeyValuePair<CleanUpType, IList<string>> entry in identifiers)
            {
                await ManagementTestBaseUtils.CleanupAsync(ApiClient, entry.Key, entry.Value);
            }

            ApiClient.Dispose();
        }
    }

    public class ActionsTests : IClassFixture<ActionsTestsFixture>
    {
        ActionsTestsFixture fixture;

        public ActionsTests(ActionsTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task Test_actions_crud_sequence()
        {
            var actionsBeforeCreate = await fixture.ApiClient.Actions.GetAllAsync(new GetActionsRequest(), new PaginationInfo());

            var createdAction = await fixture.ApiClient.Actions.CreateAsync(new CreateActionRequest
            {
                Name = $"{TestingConstants.ActionPrefix}-{Guid.NewGuid()}",
                Code = "module.exports = () => {}",
                Runtime = "node12",
                Secrets = new List<ActionSecret> { new ActionSecret { Name = "My_Secret", Value  = "Test123" } },
                SupportedTriggers = new List<ActionSupportedTrigger> { new ActionSupportedTrigger { Id = "post-login", Version = "v2"} }
            });

            fixture.TrackIdentifier(CleanUpType.Actions, createdAction.Id);

            var actionsAfterCreate = await fixture.ApiClient.Actions.GetAllAsync(new GetActionsRequest(), new PaginationInfo());

            actionsAfterCreate.Count.Should().Be(actionsBeforeCreate.Count + 1);
            createdAction.Should().BeEquivalentTo(actionsAfterCreate.Last(), options => options.Excluding(o => o.Status));

            var updatedAction = await fixture.ApiClient.Actions.UpdateAsync(createdAction.Id, new UpdateActionRequest
            {
                Code = "module.exports = () => { console.log(true); }"
            });

            updatedAction.Should().BeEquivalentTo(createdAction, options => options.Excluding(o => o.Code).Excluding(o => o.UpdatedAt));
            updatedAction.Code.Should().Be("module.exports = () => { console.log(true); }");

            var actionAfterUpdate = await fixture.ApiClient.Actions.GetAsync(updatedAction.Id);

            updatedAction.Should().BeEquivalentTo(actionAfterUpdate, options => options.Excluding(o => o.Status));
            actionAfterUpdate.Code.Should().Be("module.exports = () => { console.log(true); }");

            await fixture.ApiClient.Actions.DeleteAsync(actionAfterUpdate.Id);

            var actionsAfterDelete = await fixture.ApiClient.Actions.GetAllAsync(new GetActionsRequest(), new PaginationInfo());
            actionsAfterDelete.Count.Should().Be(actionsBeforeCreate.Count);

            fixture.UnTrackIdentifier(CleanUpType.Actions, createdAction.Id);
        }

        [Fact]
        public async Task Test_get_triggers()
        {
            var triggers = await fixture.ApiClient.Actions.GetAllTriggersAsync();

            triggers.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Test_get_and_update_trigger_bindings()
        {
            var triggerBindingsBeforeCreate = await fixture.ApiClient.Actions.GetAllTriggerBindingsAsync("post-login", new PaginationInfo());
            
            var createdAction = await fixture.ApiClient.Actions.CreateAsync(new CreateActionRequest
            {
                Name = $"{TestingConstants.ActionPrefix}-{Guid.NewGuid()}",
                Code = "module.exports = () => {}",
                Runtime = "node12",
                Secrets = new List<ActionSecret> { new ActionSecret { Name = "My_Secret", Value = "Test123" } },
                SupportedTriggers = new List<ActionSupportedTrigger> { new ActionSupportedTrigger { Id = "post-login", Version = "v2" } }
            });

            fixture.TrackIdentifier(CleanUpType.Actions, createdAction.Id);

            await RetryUtils.Retry(() => fixture.ApiClient.Actions.GetAsync(createdAction.Id), response => response.Status != "built");

            await fixture.ApiClient.Actions.DeployAsync(createdAction.Id);

            // 
            await RetryUtils.Retry(() => fixture.ApiClient.Actions.GetAsync(createdAction.Id), response => !response.AllChangesDeployed);

            await fixture.ApiClient.Actions.UpdateTriggerBindingsAsync("post-login", new UpdateTriggerBindingsRequest
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

            var triggerBindingsAfterCreate = await fixture.ApiClient.Actions.GetAllTriggerBindingsAsync("post-login", new PaginationInfo());

            triggerBindingsAfterCreate.Count.Should().Be(triggerBindingsBeforeCreate.Count + 1);

            await fixture.ApiClient.Actions.UpdateTriggerBindingsAsync("post-login", new UpdateTriggerBindingsRequest
            {
                Bindings = new List<UpdateTriggerBindingEntry>()
            });

            await fixture.ApiClient.Actions.DeleteAsync(createdAction.Id);

            fixture.UnTrackIdentifier(CleanUpType.Actions, createdAction.Id);
        }

        [Fact]
        public async Task Test_action_version_crud_sequence()
        {
            // 1. Create a new Action
            var createdAction = await fixture.ApiClient.Actions.CreateAsync(new CreateActionRequest
            {
                Name = $"{TestingConstants.ActionPrefix}-{Guid.NewGuid()}",
                Code = "module.exports = () => {}",
                Runtime = "node12",
                Secrets = new List<ActionSecret> { new ActionSecret { Name = "My_Secret", Value = "Test123" } },
                SupportedTriggers = new List<ActionSupportedTrigger> { new ActionSupportedTrigger { Id = "post-login", Version = "v2" } }
            });

            fixture.TrackIdentifier(CleanUpType.Actions, createdAction.Id);

            // 2. Get all the versions after the action was created
            var versionsAfterCreate = await fixture.ApiClient.Actions.GetAllVersionsAsync(createdAction.Id, new PaginationInfo());
            
            versionsAfterCreate.Count.Should().Be(0);

            // 3.a Before deploying, ensure it's in built status (this is async and sometimes causes CI to fail)
            await RetryUtils.Retry(() => fixture.ApiClient.Actions.GetAsync(createdAction.Id), (action) => action.Status != "built");

            // 3.b Deploy the current version
            await fixture.ApiClient.Actions.DeployAsync(createdAction.Id);

            // 4. Get all the versions after the action was deployed
            var versionsAfterDeploy = await fixture.ApiClient.Actions.GetAllVersionsAsync(createdAction.Id, new PaginationInfo());
            
            versionsAfterDeploy.Count.Should().Be(1);

            // 5. Update the action
            await fixture.ApiClient.Actions.UpdateAsync(createdAction.Id, new UpdateActionRequest
            {
                Code = "module.exports = () => { console.log(true); }"
            });

            // 6.a Before deploying, ensure it's in built status (this is async and sometimes causes CI to fail)
            await RetryUtils.Retry(() => fixture.ApiClient.Actions.GetAsync(createdAction.Id), (action) => action.Status != "built");

            // 6.b. Deploy the latest version
            var deployedVersion = await fixture.ApiClient.Actions.DeployAsync(createdAction.Id);

            // Wait 2 seconds because it can take a while for the Action to be deployed
            await Task.Delay(2000);

            // 7. Get all the versions after the action was updated
            var versionsAfterSecondDeploy = await fixture.ApiClient.Actions.GetAllVersionsAsync(createdAction.Id, new PaginationInfo());

            versionsAfterSecondDeploy.Count.Should().Be(2);
            versionsAfterSecondDeploy.Single(v => v.Id == deployedVersion.Id).Deployed.Should().BeTrue();
            versionsAfterSecondDeploy.Single(v => v.Id != deployedVersion.Id).Deployed.Should().BeFalse();

            var action = await fixture.ApiClient.Actions.GetAsync(createdAction.Id);
            action.DeployedVersion.Id.Should().Be(deployedVersion.Id);

            // 9. Rollback
            var rollbackedVersion = await fixture.ApiClient.Actions.RollbackToVersionAsync(createdAction.Id, versionsAfterDeploy.Single().Id);

            // 10. Get all the versions after the action was rollbacked
            // Retry until the rollback was processed as this is async
            var versionAfterRollback = await RetryUtils.Retry(() => fixture.ApiClient.Actions.GetVersionAsync(createdAction.Id, rollbackedVersion.Id), (response) => response.Deployed == false);

            var versionsAfterRollback = await fixture.ApiClient.Actions.GetAllVersionsAsync(createdAction.Id, new PaginationInfo());

            versionsAfterRollback.Count.Should().Be(3);
            versionsAfterRollback.Single(v => v.Id == versionAfterRollback.Id).Should().BeEquivalentTo(versionAfterRollback);
            versionsAfterRollback.Single(v => v.Id == versionAfterRollback.Id).Deployed.Should().BeTrue();
            versionsAfterRollback.Where(v => v.Id != versionAfterRollback.Id).ToList().ForEach(v => v.Deployed.Should().BeFalse());

            // 10. Delete Action
            await fixture.ApiClient.Actions.DeleteAsync(createdAction.Id);

            fixture.UnTrackIdentifier(CleanUpType.Actions, createdAction.Id);
        }
    }
}
