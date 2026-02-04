using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Flows;
using Auth0.ManagementApi.Flows.Vault;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class FlowsTestFixture : TestBaseFixture
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

public class FlowsTest : IClassFixture<FlowsTestFixture>
{
    private FlowsTestFixture fixture;

    public FlowsTest(FlowsTestFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Test_flows_crud_sequence()
    {
        // Create a Flow
        var createRequest = new CreateFlowRequestContent
        {
            Name = "Test Flow"
        };

        var flow = await fixture.ApiClient.Flows.CreateAsync(createRequest);
        flow.Should().NotBeNull();
        flow.Name.Should().Be(createRequest.Name);

        // Update flow
        var updateRequest = new UpdateFlowRequestContent
        {
            Actions = null
        };
        var updatedFlow = await fixture.ApiClient.Flows.UpdateAsync(flow.Id, updateRequest);
        updatedFlow.Should().NotBeNull();

        // Get a Flow
        var getFlow = await fixture.ApiClient.Flows.GetAsync(flow.Id, new GetFlowRequestParameters
        {
            Hydrate = new GetFlowRequestParametersHydrateEnum?[] { GetFlowRequestParametersHydrateEnum.FormCount }
        });
        getFlow.Should().NotBeNull();

        // Delete a flow
        await fixture.ApiClient.Flows.DeleteAsync(flow.Id);
    }

    [Fact(Skip = "Requires Flows vault connection configuration")]
    public async Task Test_flow_vault_connection_crud_sequence()
    {
        var vaultConnectionRequest = new CreateFlowsVaultConnectionAuth0OauthApp
        {
            AppId = "AUTH0",
            Setup = new FlowsVaultConnectioSetupOauthApp
            {
                Domain = TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_URL"),
                ClientId = TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID"),
                ClientSecret = TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_SECRET")
            },
            Name = "Auth0-test-connection"
        };

        // The union type has implicit conversion from CreateFlowsVaultConnectionAuth0OauthApp
        var createdFlowVaultConnection = await fixture.ApiClient.Flows.Vault.Connections.CreateAsync(vaultConnectionRequest);
        createdFlowVaultConnection.Should().NotBeNull();

        // Update the flow vault connection
        var updateRequest = new UpdateFlowsVaultConnectionRequestContent
        {
            Name = "Updated Name"
        };

        var updatedVaultConnection =
            await fixture.ApiClient.Flows.Vault.Connections.UpdateAsync(createdFlowVaultConnection.Id, updateRequest);
        updatedVaultConnection.Should().NotBeNull();
        updatedVaultConnection.Name.Should().Be("Updated Name");

        // Get all vault connections
        var allFlowVaultConnectionsPager =
            await fixture.ApiClient.Flows.Vault.Connections.ListAsync(new ListFlowsVaultConnectionsRequestParameters());
        var allFlowVaultConnections = allFlowVaultConnectionsPager.CurrentPage.Items.ToList();
        allFlowVaultConnections.Select(x => x.Id == createdFlowVaultConnection.Id).Should().NotBeNull();

        // Get the newly created vault connection
        var vaultConnection = await fixture.ApiClient.Flows.Vault.Connections.GetAsync(createdFlowVaultConnection.Id);
        vaultConnection.Should().NotBeNull();
        vaultConnection.Id.Should().Be(createdFlowVaultConnection.Id);

        // Delete the newly created vault connection
        await fixture.ApiClient.Flows.Vault.Connections.DeleteAsync(createdFlowVaultConnection.Id);
    }

    [Fact]
    public async Task Test_flow_executions_crud_sequence()
    {
        // Given a flow
        var createExecRequest = new CreateFlowRequestContent
        {
            Name = "Flow for Test_flow_executions_crud_sequence"
        };
        var newFlow = await fixture.ApiClient.Flows.CreateAsync(createExecRequest);
        newFlow.Should().NotBeNull();
        fixture.TrackIdentifier(CleanUpType.Flows, newFlow.Id);

        try
        {
            // Get all flow executions
            var flowExecutionsPager =
                await fixture.ApiClient.Flows.Executions.ListAsync(newFlow.Id, new ExecutionsListRequest());

            flowExecutionsPager.Should().NotBeNull();
        }
        finally
        {
            await fixture.ApiClient.Flows.DeleteAsync(newFlow.Id);
            fixture.UnTrackIdentifier(CleanUpType.Flows, newFlow.Id);
        }
    }
}
