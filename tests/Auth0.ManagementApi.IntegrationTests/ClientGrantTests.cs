using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class ClientGrantTestsFixture : TestBaseFixture
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

public class ClientGrantTests : IClassFixture<ClientGrantTestsFixture>
{
    private ClientGrantTestsFixture fixture;

    public ClientGrantTests(ClientGrantTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact(Skip = "Requires resource server configuration")]
    public async Task Test_client_grants_crud_sequence()
    {
        // Get all client grants
        var grantsPager = await fixture.ApiClient.ClientGrants.ListAsync(new ListClientGrantsRequestParameters());
        var grantsBefore = grantsPager.CurrentPage.Items.ToList();

        // Create a new client grant
        var newClientGrantRequest = new CreateClientGrantRequestContent
        {
            ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
            Audience = "https://api.mycompany.com/client-grant-test-1",
            Scope = new List<string> { "read:users" },
            AllowAnyOrganization = true,
            OrganizationUsage = ClientGrantOrganizationUsageEnum.Allow
        };
        var newClientGrantResponse = await fixture.ApiClient.ClientGrants.CreateAsync(newClientGrantRequest);
        newClientGrantResponse.Should().NotBeNull();
        newClientGrantResponse.Id.Should().NotBeNull();
        newClientGrantResponse.ClientId.Should().Be(newClientGrantRequest.ClientId);
        newClientGrantResponse.Audience.Should().Be(newClientGrantRequest.Audience);
        newClientGrantResponse.Scope.Should().BeEquivalentTo(newClientGrantRequest.Scope);
        newClientGrantResponse.AllowAnyOrganization.Should().Be(true);
        newClientGrantResponse.OrganizationUsage.Should().Be(ClientGrantOrganizationUsageEnum.Allow);

        // Get all client grants again, and check we have one more
        grantsPager = await fixture.ApiClient.ClientGrants.ListAsync(new ListClientGrantsRequestParameters());
        var grantsAfter = grantsPager.CurrentPage.Items.ToList();
        grantsAfter.Count.Should().Be(grantsBefore.Count + 1);

        // Update the client grant
        var updateClientGrantRequest = new UpdateClientGrantRequestContent
        {
            Scope = new List<string> { "read:users", "write:users" },
            AllowAnyOrganization = false,
            OrganizationUsage = ClientGrantOrganizationNullableUsageEnum.Require
        };
        var updateClientGrantResponse = await fixture.ApiClient.ClientGrants.UpdateAsync(newClientGrantResponse.Id, updateClientGrantRequest);
        updateClientGrantResponse.Should().NotBeNull();
        updateClientGrantResponse.Scope.Should().BeEquivalentTo(updateClientGrantRequest.Scope);
        updateClientGrantResponse.AllowAnyOrganization.Should().Be(false);
        updateClientGrantResponse.OrganizationUsage.Should().Be(ClientGrantOrganizationUsageEnum.Require);

        // Delete the client grant
        await fixture.ApiClient.ClientGrants.DeleteAsync(newClientGrantResponse.Id);

        // Get all client grants again, and check we have one less
        grantsPager = await fixture.ApiClient.ClientGrants.ListAsync(new ListClientGrantsRequestParameters());
        var grantsAfterDelete = grantsPager.CurrentPage.Items.ToList();
        grantsAfterDelete.Count.Should().Be(grantsBefore.Count);
    }

    [Fact]
    public async Task Test_client_grants_filter_by_audience()
    {
        // Get all client grants for a specific audience
        var grantsPager = await fixture.ApiClient.ClientGrants.ListAsync(new ListClientGrantsRequestParameters
        {
            Audience = "https://" + TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_URL").Replace("https://", "").TrimEnd('/') + "/api/v2/"
        });

        grantsPager.Should().NotBeNull();
        var grants = grantsPager.CurrentPage.Items.ToList();
        grants.Should().NotBeNull();
    }

    [Fact]
    public async Task Test_client_grants_filter_by_client_id()
    {
        // Get all client grants for a specific client
        var grantsPager = await fixture.ApiClient.ClientGrants.ListAsync(new ListClientGrantsRequestParameters
        {
            ClientId = TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID")
        });

        grantsPager.Should().NotBeNull();
        var grants = grantsPager.CurrentPage.Items.ToList();
        grants.Should().NotBeNull();
        grants.Count.Should().BeGreaterThan(0);
    }
}
