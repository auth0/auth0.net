using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models.Actions;
using Auth0.ManagementApi.Paging;
using FluentAssertions;
using Xunit;
using Action = Auth0.ManagementApi.Models.Actions.Action;


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
        var actionsBeforeCreate =
            await fixture.ApiClient.Actions.GetAllAsync(new GetActionsRequest(), new PaginationInfo());

        var createdAction = await fixture.ApiClient.Actions.CreateAsync(new CreateActionRequest
        {
            Name = $"{TestingConstants.ActionPrefix}-{Guid.NewGuid()}",
            Code = "module.exports = () => {}",
            Runtime = "node12",
            Secrets = new List<ActionSecret> { new() { Name = "My_Secret", Value = "Test123" } },
            SupportedTriggers = new List<ActionSupportedTrigger>
                { new() { Id = "post-login", Version = "v2" } }
        });

        fixture.TrackIdentifier(CleanUpType.Actions, createdAction.Id);

        var actionsAfterCreate =
            await fixture.ApiClient.Actions.GetAllAsync(new GetActionsRequest(), new PaginationInfo());

        actionsAfterCreate.Count.Should().Be(actionsBeforeCreate.Count + 1);
        createdAction.Should()
            .BeEquivalentTo(actionsAfterCreate.Last(), options => options.Excluding(o => o.Status));

        var updatedAction = await fixture.ApiClient.Actions.UpdateAsync(createdAction.Id, new UpdateActionRequest
        {
            Code = "module.exports = () => { console.log(true); }"
        });

        updatedAction.Should().BeEquivalentTo(createdAction,
            options => options.Excluding(o => o.Code).Excluding(o => o.UpdatedAt));
        updatedAction.Code.Should().Be("module.exports = () => { console.log(true); }");

        var actionAfterUpdate = await fixture.ApiClient.Actions.GetAsync(updatedAction.Id);

        updatedAction.Should().BeEquivalentTo(actionAfterUpdate, options => options.Excluding(o => o.Status));
        actionAfterUpdate.Code.Should().Be("module.exports = () => { console.log(true); }");

        await fixture.ApiClient.Actions.DeleteAsync(actionAfterUpdate.Id);

        var actionsAfterDelete =
            await fixture.ApiClient.Actions.GetAllAsync(new GetActionsRequest(), new PaginationInfo());
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
        var triggerBindingsBeforeCreate =
            await fixture.ApiClient.Actions.GetAllTriggerBindingsAsync("post-login", new PaginationInfo());

        var createdAction = await fixture.ApiClient.Actions.CreateAsync(new CreateActionRequest
        {
            Name = $"{TestingConstants.ActionPrefix}-{Guid.NewGuid()}",
            Code = "module.exports = () => {}",
            Runtime = "node12",
            Secrets = new List<ActionSecret> { new() { Name = "My_Secret", Value = "Test123" } },
            SupportedTriggers = new List<ActionSupportedTrigger>
                { new() { Id = "post-login", Version = "v2" } }
        });

        fixture.TrackIdentifier(CleanUpType.Actions, createdAction.Id);

        await RetryUtils.Retry(() => fixture.ApiClient.Actions.GetAsync(createdAction.Id),
            response => response.Status != "built");

        await fixture.ApiClient.Actions.DeployAsync(createdAction.Id);

        // 
        await RetryUtils.Retry(() => fixture.ApiClient.Actions.GetAsync(createdAction.Id),
            response => !response.AllChangesDeployed);

        await fixture.ApiClient.Actions.UpdateTriggerBindingsAsync("post-login", new UpdateTriggerBindingsRequest
        {
            Bindings = new List<UpdateTriggerBindingEntry>
            {
                new()
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

        var triggerBindingsAfterCreate =
            await fixture.ApiClient.Actions.GetAllTriggerBindingsAsync("post-login", new PaginationInfo());

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
            Secrets = new List<ActionSecret> { new() { Name = "My_Secret", Value = "Test123" } },
            SupportedTriggers = new List<ActionSupportedTrigger>
                { new() { Id = "post-login", Version = "v2" } }
        });

        fixture.TrackIdentifier(CleanUpType.Actions, createdAction.Id);

        // 2. Get all the versions after the action was created
        var versionsAfterCreate =
            await fixture.ApiClient.Actions.GetAllVersionsAsync(createdAction.Id, new PaginationInfo());

        versionsAfterCreate.Count.Should().Be(0);

        // 3.a Before deploying, ensure it's in built status (this is async and sometimes causes CI to fail)
        await RetryUtils.Retry(() => fixture.ApiClient.Actions.GetAsync(createdAction.Id),
            (action) => action.Status != "built");

        // 3.b Deploy the current version
        await fixture.ApiClient.Actions.DeployAsync(createdAction.Id);

        // 4. Get all the versions after the action was deployed
        var versionsAfterDeploy =
            await fixture.ApiClient.Actions.GetAllVersionsAsync(createdAction.Id, new PaginationInfo());

        versionsAfterDeploy.Count.Should().Be(1);

        // 5. Update the action
        await fixture.ApiClient.Actions.UpdateAsync(createdAction.Id, new UpdateActionRequest
        {
            Code = "module.exports = () => { console.log(true); }"
        });

        // 6.a Before deploying, ensure it's in built status (this is async and sometimes causes CI to fail)
        await RetryUtils.Retry(() => fixture.ApiClient.Actions.GetAsync(createdAction.Id),
            (action) => action.Status != "built");

        // 6.b. Deploy the latest version
        var deployedVersion = await fixture.ApiClient.Actions.DeployAsync(createdAction.Id);

        // Wait 2 seconds because it can take a while for the Action to be deployed
        await Task.Delay(2000);

        // 7. Get all the versions after the action was updated
        var versionsAfterSecondDeploy =
            await fixture.ApiClient.Actions.GetAllVersionsAsync(createdAction.Id, new PaginationInfo());

        versionsAfterSecondDeploy.Count.Should().Be(2);
        versionsAfterSecondDeploy.Single(v => v.Id == deployedVersion.Id).Deployed.Should().BeTrue();
        versionsAfterSecondDeploy.Single(v => v.Id != deployedVersion.Id).Deployed.Should().BeFalse();

        var action = await fixture.ApiClient.Actions.GetAsync(createdAction.Id);
        action.DeployedVersion.Id.Should().Be(deployedVersion.Id);

        // 9. Rollback
        var rollbackedVersion =
            await fixture.ApiClient.Actions.RollbackToVersionAsync(createdAction.Id,
                versionsAfterDeploy.Single().Id);

        // 10. Get all the versions after the action was rollbacked
        // Retry until the rollback was processed as this is async
        var versionAfterRollback =
            await RetryUtils.Retry(
                () => fixture.ApiClient.Actions.GetVersionAsync(createdAction.Id, rollbackedVersion.Id),
                (response) => response.Deployed == false);

        var versionsAfterRollback =
            await fixture.ApiClient.Actions.GetAllVersionsAsync(createdAction.Id, new PaginationInfo());

        versionsAfterRollback.Count.Should().Be(3);
        versionsAfterRollback.Single(v => v.Id == versionAfterRollback.Id).Should()
            .BeEquivalentTo(versionAfterRollback);
        versionsAfterRollback.Single(v => v.Id == versionAfterRollback.Id).Deployed.Should().BeTrue();
        versionsAfterRollback.Where(v => v.Id != versionAfterRollback.Id).ToList()
            .ForEach(v => v.Deployed.Should().BeFalse());

        // 10. Delete Action
        await fixture.ApiClient.Actions.DeleteAsync(createdAction.Id);

        fixture.UnTrackIdentifier(CleanUpType.Actions, createdAction.Id);
    }

    [Fact]
    public async Task Test_get_actions_with_integration_details()
    {
        var sampleGetActionsWithIntegrationData =
            await File.ReadAllTextAsync("./Data/GetActionsResponseWithIntegrationData.json");
        var httpManagementClientConnection = new HttpClientManagementConnection();
        var actions =
            httpManagementClientConnection.DeserializeContent<Action>(sampleGetActionsWithIntegrationData,
                null);

        actions.Should().NotBeNull();

        actions.Id.Should().Be("9be52336-3338-46fe-be43-3845ea874b16");
        actions.Name.Should().Be("post-login-action");
        actions.BuiltAt.Should().Be(DateTime.Parse("2024-10-28T11:53:00.811042526"));
        actions.Status.Should().Be("building");
            
        actions.SupportedTriggers.Should().NotBeEmpty();
        var supportedTrigger = actions.SupportedTriggers.First();
        supportedTrigger.Id.Should().Be("post-login");
        supportedTrigger.Version.Should().Be("v3");
        supportedTrigger.Status.Should().Be("built");
        supportedTrigger.Runtimes.Should().NotBeEmpty();
        supportedTrigger.DefaultRuntime.Should().Be("v18");
        supportedTrigger.CompatibleTrigger.Should().NotBeEmpty();
        supportedTrigger.CompatibleTrigger.First().Id.Should().Be("d929f92d-efd5-465f-9801-cdd40bfe2c55");
        supportedTrigger.CompatibleTrigger.First().Version.Should().Be("v2");
        supportedTrigger.BindingPolicy.Should().Be(BindingPolicy.TriggerBound);

        actions.AllChangesDeployed.Should().BeTrue();
        actions.CreatedAt.Should().Be(DateTime.Parse("2024-10-28T11:53:00.800362301"));
        actions.UpdatedAt.Should().Be(DateTime.Parse("2024-10-28T11:53:00.811042526"));

        actions.Integration.Id.Should().Be("750ce7ba-eac5-44a2-97ac-a67b2183bdea");
        actions.Integration.CatalogId.Should().Be("auth0-country-based-access");
        actions.Integration.UrlSlug.Should().Be("country-based-access");
        actions.Integration.PartnerId.Should().Be("d929f92d-efd5-465f-9801-cdd40bfe2c39");
        actions.Integration.Name.Should().Be("Country-based Access");
        actions.Integration.Description.Should().Be("This integration allows you to restrict access to your applications by country. You may choose to implement Country-based Access controls for various reasons, including to allow your applications to comply with unique restrictions based on where you do business. \n\nWith the Country-based Access integration, you can define any and all countries to restrict persons and entities from those countries logging into your applications. ");
        actions.Integration.ShortDescription.Should().Be("Restrict access to users by country");
        actions.Integration.Logo.Should().Be("https://cdn.auth0.com/marketplace/catalog/content/assets/creators/auth0/auth0-avatar.png");
        actions.Integration.FeatureType.Should().Be(FeatureType.Action);
        actions.Integration.TermsOfUseUrl.Should().Be("https://cdn.auth0.com/website/legal/files/mktplace/auth0-integration.pdf");
        actions.Integration.PublicSupportLink.Should().Be("https://support.auth0.com/");
            
        actions.Integration.CurrentRelease.Id.Should().Be("d929f92d-efd5-465f-9801-cdd40bfe2c61");
        actions.Integration.CurrentRelease.SemVer.Major.Should().Be(8);
        actions.Integration.CurrentRelease.SemVer.Minor.Should().Be(1);
        actions.Integration.CurrentRelease.RequiredSecrets.Should().NotBeNull();
        actions.Integration.CurrentRelease.RequiredConfigurations.Should().NotBeNull();
            
    }
}