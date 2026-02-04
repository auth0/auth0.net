using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.Actions;
using Auth0.ManagementApi.Actions.Triggers;
using Auth0.ManagementApi.IntegrationTests.Testing;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

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
    private ActionsTestsFixture fixture;

    public ActionsTests(ActionsTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Test_actions_crud_sequence()
    {
        var actionsBeforeCreatePager =
            await fixture.ApiClient.Actions.ListAsync(new ListActionsRequestParameters());
        var actionsBeforeCreate = actionsBeforeCreatePager.CurrentPage.Items.ToList();

        var createdAction = await fixture.ApiClient.Actions.CreateAsync(new CreateActionRequestContent
        {
            Name = $"{TestingConstants.ActionPrefix}-{Guid.NewGuid()}",
            Code = "module.exports = () => {}",
            Runtime = "node18",
            Secrets = new List<ActionSecretRequest> { new() { Name = "My_Secret", Value = "Test123" } },
            SupportedTriggers = new List<ActionTrigger>
                { new() { Id = "post-login", Version = "v2" } }
        });

        fixture.TrackIdentifier(CleanUpType.Actions, createdAction.Id);

        var actionsAfterCreatePager =
            await fixture.ApiClient.Actions.ListAsync(new ListActionsRequestParameters());
        var actionsAfterCreate = actionsAfterCreatePager.CurrentPage.Items.ToList();

        actionsAfterCreate.Count.Should().Be(actionsBeforeCreate.Count + 1);
        // Verify the created action is in the list (can't use BeEquivalentTo due to timing-related property differences)
        actionsAfterCreate.Should().Contain(a => a.Id == createdAction.Id);

        var updatedAction = await fixture.ApiClient.Actions.UpdateAsync(createdAction.Id, new UpdateActionRequestContent
        {
            Code = "module.exports = () => { console.log(true); }"
        });

        // Verify the update changed the code
        updatedAction.Id.Should().Be(createdAction.Id);
        updatedAction.Code.Should().Be("module.exports = () => { console.log(true); }");

        var actionAfterUpdate = await fixture.ApiClient.Actions.GetAsync(updatedAction.Id);

        // Verify we can fetch the updated action
        actionAfterUpdate.Id.Should().Be(updatedAction.Id);
        actionAfterUpdate.Code.Should().Be("module.exports = () => { console.log(true); }");

        await fixture.ApiClient.Actions.DeleteAsync(actionAfterUpdate.Id, new DeleteActionRequestParameters());

        var actionsAfterDeletePager =
            await fixture.ApiClient.Actions.ListAsync(new ListActionsRequestParameters());
        var actionsAfterDelete = actionsAfterDeletePager.CurrentPage.Items.ToList();
        actionsAfterDelete.Count.Should().Be(actionsBeforeCreate.Count);

        fixture.UnTrackIdentifier(CleanUpType.Actions, createdAction.Id);
    }

    [Fact]
    public async Task Test_get_triggers()
    {
        var triggers = await fixture.ApiClient.Actions.Triggers.ListAsync();

        triggers.Triggers.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Test_get_and_update_trigger_bindings()
    {
        var triggerBindingsBeforeCreatePager =
            await fixture.ApiClient.Actions.Triggers.Bindings.ListAsync("post-login", new ListActionTriggerBindingsRequestParameters());
        var triggerBindingsBeforeCreate = triggerBindingsBeforeCreatePager.CurrentPage.Items.ToList();

        var createdAction = await fixture.ApiClient.Actions.CreateAsync(new CreateActionRequestContent
        {
            Name = $"{TestingConstants.ActionPrefix}-{Guid.NewGuid()}",
            Code = "module.exports = () => {}",
            Runtime = "node18",
            Secrets = new List<ActionSecretRequest> { new() { Name = "My_Secret", Value = "Test123" } },
            SupportedTriggers = new List<ActionTrigger>
                { new() { Id = "post-login", Version = "v2" } }
        });

        fixture.TrackIdentifier(CleanUpType.Actions, createdAction.Id);

        await RetryUtils.Retry<GetActionResponseContent>(async () => await fixture.ApiClient.Actions.GetAsync(createdAction.Id),
            response => response.Status != ActionBuildStatusEnum.Built);

        await fixture.ApiClient.Actions.DeployAsync(createdAction.Id);

        await RetryUtils.Retry<GetActionResponseContent>(async () => await fixture.ApiClient.Actions.GetAsync(createdAction.Id),
            response => response.AllChangesDeployed != true);

        await fixture.ApiClient.Actions.Triggers.Bindings.UpdateManyAsync("post-login", new UpdateActionBindingsRequestContent
        {
            Bindings = new List<ActionBindingWithRef>
            {
                new()
                {
                    Ref = new ActionBindingRef
                    {
                        Type = ActionBindingRefTypeEnum.ActionId,
                        Value = createdAction.Id
                    },
                    DisplayName = "My Action"
                }
            }
        });

        // Wait for binding update to propagate
        await Task.Delay(2000);

        var triggerBindingsAfterCreatePager =
            await fixture.ApiClient.Actions.Triggers.Bindings.ListAsync("post-login", new ListActionTriggerBindingsRequestParameters());
        var triggerBindingsAfterCreate = triggerBindingsAfterCreatePager.CurrentPage.Items.ToList();

        // Verify our binding was added (check for presence rather than exact count since other bindings may exist)
        triggerBindingsAfterCreate.Should().Contain(b => b.Action.Id == createdAction.Id);

        await fixture.ApiClient.Actions.Triggers.Bindings.UpdateManyAsync("post-login", new UpdateActionBindingsRequestContent
        {
            Bindings = new List<ActionBindingWithRef>()
        });

        await fixture.ApiClient.Actions.DeleteAsync(createdAction.Id, new DeleteActionRequestParameters());

        fixture.UnTrackIdentifier(CleanUpType.Actions, createdAction.Id);
    }

    [Fact]
    public async Task Test_action_version_crud_sequence()
    {
        // 1. Create a new Action
        var createdAction = await fixture.ApiClient.Actions.CreateAsync(new CreateActionRequestContent
        {
            Name = $"{TestingConstants.ActionPrefix}-{Guid.NewGuid()}",
            Code = "module.exports = () => {}",
            Runtime = "node18",
            Secrets = new List<ActionSecretRequest> { new() { Name = "My_Secret", Value = "Test123" } },
            SupportedTriggers = new List<ActionTrigger>
                { new() { Id = "post-login", Version = "v2" } }
        });

        fixture.TrackIdentifier(CleanUpType.Actions, createdAction.Id);

        // 2. Get all the versions after the action was created
        var versionsAfterCreatePager =
            await fixture.ApiClient.Actions.Versions.ListAsync(createdAction.Id, new ListActionVersionsRequestParameters());
        var versionsAfterCreate = versionsAfterCreatePager.CurrentPage.Items.ToList();

        versionsAfterCreate.Count.Should().Be(0);

        // 3.a Before deploying, ensure it's in built status (this is async and sometimes causes CI to fail)
        await RetryUtils.Retry<GetActionResponseContent>(async () => await fixture.ApiClient.Actions.GetAsync(createdAction.Id),
            (action) => action.Status != ActionBuildStatusEnum.Built);

        // 3.b Deploy the current version
        await fixture.ApiClient.Actions.DeployAsync(createdAction.Id);

        // 4. Get all the versions after the action was deployed
        var versionsAfterDeployPager =
            await fixture.ApiClient.Actions.Versions.ListAsync(createdAction.Id, new ListActionVersionsRequestParameters());
        var versionsAfterDeploy = versionsAfterDeployPager.CurrentPage.Items.ToList();

        versionsAfterDeploy.Count.Should().Be(1);

        // Wait for deployment to fully complete before updating
        await Task.Delay(2000);

        // 5. Update the action
        await fixture.ApiClient.Actions.UpdateAsync(createdAction.Id, new UpdateActionRequestContent
        {
            Code = "module.exports = () => { console.log(true); }"
        });

        // 6.a Before deploying, ensure it's in built status (this is async and sometimes causes CI to fail)
        await RetryUtils.Retry<GetActionResponseContent>(async () => await fixture.ApiClient.Actions.GetAsync(createdAction.Id),
            (action) => action.Status != ActionBuildStatusEnum.Built);

        // 6.b. Deploy the latest version
        var deployedVersion = await fixture.ApiClient.Actions.DeployAsync(createdAction.Id);

        // Wait 2 seconds because it can take a while for the Action to be deployed
        await Task.Delay(2000);

        // 7. Get all the versions after the action was updated
        var versionsAfterSecondDeployPager =
            await fixture.ApiClient.Actions.Versions.ListAsync(createdAction.Id, new ListActionVersionsRequestParameters());
        var versionsAfterSecondDeploy = versionsAfterSecondDeployPager.CurrentPage.Items.ToList();

        versionsAfterSecondDeploy.Count.Should().Be(2);
        versionsAfterSecondDeploy.Single(v => v.Id == deployedVersion.Id).Deployed.Should().BeTrue();
        versionsAfterSecondDeploy.Single(v => v.Id != deployedVersion.Id).Deployed.Should().BeFalse();

        var action = await fixture.ApiClient.Actions.GetAsync(createdAction.Id);
        action.DeployedVersion.Id.Should().Be(deployedVersion.Id);

        // 9. Rollback (using DeployAsync which performs equivalent of rollback to specified version)
        var rollbackedVersion =
            await fixture.ApiClient.Actions.Versions.DeployAsync(createdAction.Id,
                versionsAfterDeploy.Single().Id, default);

        // 10. Get all the versions after the action was rollbacked
        // Retry until the rollback was processed as this is async
        var versionAfterRollback =
            await RetryUtils.Retry<GetActionVersionResponseContent>(
                async () => await fixture.ApiClient.Actions.Versions.GetAsync(createdAction.Id, rollbackedVersion.Id),
                (response) => response.Deployed == false);

        var versionsAfterRollbackPager =
            await fixture.ApiClient.Actions.Versions.ListAsync(createdAction.Id, new ListActionVersionsRequestParameters());
        var versionsAfterRollback = versionsAfterRollbackPager.CurrentPage.Items.ToList();

        versionsAfterRollback.Count.Should().Be(3);
        // Verify the rolled back version exists and is deployed
        var rolledBackVersionFromList = versionsAfterRollback.Single(v => v.Id == versionAfterRollback.Id);
        rolledBackVersionFromList.Deployed.Should().BeTrue();
        versionsAfterRollback.Where(v => v.Id != versionAfterRollback.Id).ToList()
            .ForEach(v => v.Deployed.Should().BeFalse());

        // 10. Delete Action
        await fixture.ApiClient.Actions.DeleteAsync(createdAction.Id, new DeleteActionRequestParameters());

        fixture.UnTrackIdentifier(CleanUpType.Actions, createdAction.Id);
    }
}
