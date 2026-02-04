using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;

namespace Auth0.ManagementApi.IntegrationTests;

public class NetworkAclTestFixture : TestBaseFixture
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

public class NetworkAclTest(NetworkAclTestFixture fixture) : IClassFixture<NetworkAclTestFixture>
{
    [Fact]
    public async Task Test_NetworkAcl_crud_sequence()
    {
        // Create a Network ACL entry
        var networkAcl = new CreateNetworkAclRequestContent
        {
            Active = false,
            Priority = 1,
            Description = "Reject all traffic from test cases",
            Rule = new NetworkAclRule
            {
                Action = new NetworkAclAction { Block = true },
                Match = new NetworkAclMatch
                {
                    GeoCountryCodes = new List<string> { "CN" }
                },
                Scope = NetworkAclRuleScopeEnum.Management
            }
        };

        // Create the Network ACL, should not throw an exception
        await fixture.ApiClient.NetworkAcls.CreateAsync(networkAcl);

        var networkAclsPager = await fixture.ApiClient.NetworkAcls.ListAsync(new ListNetworkAclsRequestParameters());
        var networkAcls = networkAclsPager.CurrentPage.Items.ToList();
        networkAcls.Should().NotBeNullOrEmpty();
        try
        {
            networkAcls
                .Should()
                .ContainSingle()
                .Which
                .Description
                .Should()
                .Be(networkAcl.Description);

            var patchUpdateRequest = new UpdateNetworkAclRequestContent
            {
                Active = false,
                Priority = 2,
                Description = "Updated description for test cases",
                Rule = new NetworkAclRule
                {
                    Action = new NetworkAclAction { Block = true },
                    Match = new NetworkAclMatch
                    {
                        GeoCountryCodes = new List<string> { "US" }
                    },
                    NotMatch = new NetworkAclMatch
                    {
                        GeoCountryCodes = new List<string> { "CA" }
                    },
                    Scope = NetworkAclRuleScopeEnum.Management
                }
            };

            // Get the Network ACL entry, should not throw an exception
            var networkAclEntry =
                await fixture.ApiClient.NetworkAcls.GetAsync(networkAcls
                    .FirstOrDefault(x => x.Description == networkAcl.Description).Id);
            networkAclEntry.Should().NotBeNull();
            networkAclEntry.Rule.Should().NotBeNull();
            networkAclEntry.Rule.Match.Should().NotBeNull();
            networkAclEntry.Rule.Match?.GeoCountryCodes.Should()
                .BeEquivalentTo(new List<string> { "CN" });
            networkAclEntry.Rule.NotMatch.Should().BeNull();
            networkAclEntry.Description.Should().Be(networkAcl.Description);

            // Update the Network ACL using PATCH, should not throw an exception
            var networkAclToBeUpdated = networkAcls.FirstOrDefault(x => x.Description == networkAcl.Description);
            var patchUpdatedNetworkAclEntry =
                await fixture.ApiClient.NetworkAcls.UpdateAsync(networkAclToBeUpdated.Id, patchUpdateRequest);

            patchUpdatedNetworkAclEntry.Should().NotBeNull();
            patchUpdatedNetworkAclEntry.Rule.Should().NotBeNull();
            patchUpdatedNetworkAclEntry.Rule.NotMatch.Should().NotBeNull();
            patchUpdatedNetworkAclEntry.Description.Should().Be(patchUpdateRequest.Description);
            patchUpdatedNetworkAclEntry.Rule.NotMatch?.GeoCountryCodes.Should()
                .BeEquivalentTo(new List<string> { "CA" });

            var putUpdateRequest = new SetNetworkAclRequestContent
            {
                Active = false,
                Priority = 3,
                Description = "Updated description for test cases with PUT",
                Rule = new NetworkAclRule
                {
                    Action = new NetworkAclAction { Block = true },
                    NotMatch = new NetworkAclMatch
                    {
                        GeoCountryCodes = new List<string> { "DE" }
                    },
                    Scope = NetworkAclRuleScopeEnum.Management
                }
            };

            var putUpdatedNetworkAclEntry =
                await fixture.ApiClient.NetworkAcls.SetAsync(
                    networkAclToBeUpdated.Id, putUpdateRequest);

            putUpdatedNetworkAclEntry.Should().NotBeNull();
            putUpdatedNetworkAclEntry.Rule.Should().NotBeNull();
            putUpdatedNetworkAclEntry.Rule.NotMatch.Should().NotBeNull();
            putUpdatedNetworkAclEntry.Description.Should().Be(putUpdateRequest.Description);
            putUpdatedNetworkAclEntry.Priority.Should().Be(putUpdateRequest.Priority);
            putUpdatedNetworkAclEntry.Rule.NotMatch?.GeoCountryCodes.Should()
                .BeEquivalentTo(new List<string> { "DE" });
        }
        finally
        {
            // Delete all Network ACLs, should not throw an exception
            foreach (var acl in networkAcls)
            {
                await fixture.ApiClient.NetworkAcls.DeleteAsync(acl.Id);
            }
        }
    }
}
