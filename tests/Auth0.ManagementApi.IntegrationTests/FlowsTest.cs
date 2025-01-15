using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FluentAssertions;
using Xunit;

using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models.Flow;
using Auth0.ManagementApi.Paging;
using Auth0.IntegrationTests.Shared;
using Auth0.Tests.Shared;

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
    FlowsTestFixture fixture;

    public FlowsTest(FlowsTestFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async void Test_get_all_flows_throws_when_request_is_null()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => fixture.ApiClient.FlowsClient.GetAllAsync(null));
    }
    
    [Fact]
    public async void Test_get_flows_throws_when_request_is_null_when_id_is_null()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => fixture.ApiClient.FlowsClient.GetAsync(null));
        await Assert.ThrowsAsync<ArgumentNullException>(() => fixture.ApiClient.FlowsClient.GetAsync(new FlowGetRequest()));
    }
    
    [Fact]
    public async void Test_update_flows_throws_when_id_is_null()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(
            () => fixture.ApiClient.FlowsClient.UpdateAsync(null, null));
    }
    
    [Fact]
    public async void Test_delete_flow_throws_when_id_is_null()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => fixture.ApiClient.FlowsClient.DeleteAsync(null));
    }
    
    [Fact]
    public async void Test_get_all_flow_vault_connections_throws_when_request_is_null()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(
            () => fixture.ApiClient.FlowsClient.GetAllFlowVaultConnectionsAsync(null));
    }
    
    [Fact]
    public async void Test_get_flow_vault_connections_throws_when_request_is_null_id_is_null()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(
            () => fixture.ApiClient.FlowsClient.GetFlowVaultConnectionAsync(null));
        await Assert.ThrowsAsync<ArgumentNullException>(
            () => fixture.ApiClient.FlowsClient.GetFlowVaultConnectionAsync(new FlowVaultConnectionGetRequest()));
    }
    
    [Fact]
    public async void Test_update_flow_vault_connection_throws_when_id_is_null()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(
            () => fixture.ApiClient.FlowsClient.UpdateFlowVaultConnectionAsync(
                null, new FlowVaultConnectionUpdateRequest()));
    }
    
    [Fact]
    public async void Test_delete_flow_vault_connection_throws_when_id_is_null()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(
            () => fixture.ApiClient.FlowsClient.DeleteFlowVaultConnectionAsync(null));
    }
    
    [Fact]
    public async void Test_get_all_flow_executions_throws_when_request_is_null()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(
            () => fixture.ApiClient.FlowsClient.GetAllFlowExecutionsAsync(null, new PaginationInfo()));
        await Assert.ThrowsAsync<ArgumentNullException>(
            () => fixture.ApiClient.FlowsClient.GetAllFlowExecutionsAsync(null, new CheckpointPaginationInfo()));
    }
    
    [Fact]
    public async void Test_get_flow_executions_throws_when_id_execution_id_is_null()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(
            () => fixture.ApiClient.FlowsClient.GetFlowExecutionAsync(null, "executionId"));
        await Assert.ThrowsAsync<ArgumentNullException>(
            () => fixture.ApiClient.FlowsClient.GetFlowExecutionAsync("flowId", null));
    }
    
    [Fact]
    public async void Test_flows_crud_sequence()
    {
        // Create a Flow
        var createRequest = new FlowCreateRequest()
        {
            Name = "Test Flow",
            Actions = System.Array.Empty<object>()
        };

        var flow = await fixture.ApiClient.FlowsClient.CreateAsync(createRequest);
        flow.Should().NotBeNull();
        flow.Name.Should().Be(createRequest.Name);

        // Update flow
        var updateRequest = new FlowUpdateRequest()
        {
            Actions = null
        };
        var updatedFlow = await fixture.ApiClient.FlowsClient.UpdateAsync(flow.Id, updateRequest);
        updatedFlow.Should().NotBeNull();

        // Get a Flow 
        var getFlow = await fixture.ApiClient.FlowsClient.GetAsync(new FlowGetRequest { Id = flow.Id, Hydrate = new []
            {
                Hydrate.FORM_COUNT
            }}
        );
        getFlow.Should().NotBeNull();

        // Delete a flow
        await fixture.ApiClient.FlowsClient.DeleteAsync(flow.Id);
    }

    [Fact]
    public async void Test_flow_vault_connection_crud_sequence()
    {
        var createRequest = new FlowVaultConnectionCreateRequest()
        {
            AppId = "AUTH0",
            Setup = new Dictionary<string, string>()
            {
                { "type", "OAUTH_APP" },
                { "domain", TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_URL")},
                { "client_id", TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") },
                { "client_secret", TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_SECRET") }
            },
            Name = "Auth0-test-connection"
        };
        
        var createdFlowVaultConnection = await fixture.ApiClient.FlowsClient.CreateVaultConnectionAsync(createRequest);
        createdFlowVaultConnection.Should().NotBeNull();

        // Update the flow vault connection
        var updateRequest = new FlowVaultConnectionUpdateRequest()
        {
            Name = "Updated Name"
        };

        var updatedVaultConnection = 
            await fixture.ApiClient.FlowsClient.UpdateFlowVaultConnectionAsync(createdFlowVaultConnection.Id, updateRequest);
        updatedVaultConnection.Should().NotBeNull();
        updatedVaultConnection.Name.Should().Be("Updated Name");

        // Get all vault connections
        var allFlowVaultConnections =
            await fixture.ApiClient.FlowsClient.GetAllFlowVaultConnectionsAsync(new FlowVaultConnectionGetRequest());
        allFlowVaultConnections.Select( x => x.Id == createdFlowVaultConnection.Id).Should().NotBeNull();
        
        // Get the newly created vault connection
        var getRequest = new FlowVaultConnectionGetRequest()
        {
            Id = createdFlowVaultConnection.Id
        };

        var vaultConnection = await fixture.ApiClient.FlowsClient.GetFlowVaultConnectionAsync(getRequest);
        vaultConnection.Should().NotBeNull();
        vaultConnection.Id.Should().Be(createdFlowVaultConnection.Id);
        
        // Delete the newly created vault connection
        await fixture.ApiClient.FlowsClient.DeleteFlowVaultConnectionAsync(createdFlowVaultConnection.Id);
    }

    [Fact]
    public async void Test_flow_executions_crud_sequence()
    {
        // Given a flow 
        var createRequest = new FlowCreateRequest()
        {
            Name = "Flow for Test_flow_executions_crud_sequence",
            Actions = System.Array.Empty<object>()
        };
        var newFlow = await fixture.ApiClient.FlowsClient.CreateAsync(createRequest);
        newFlow.Should().NotBeNull();
        fixture.TrackIdentifier(CleanUpType.Flows, newFlow.Id);
        
        // Get all flow executions 
        var flowExecutions =
            await fixture.ApiClient.FlowsClient.GetAllFlowExecutionsAsync(newFlow.Id, new PaginationInfo());
        
        flowExecutions.Should().NotBeNull();
    }
}