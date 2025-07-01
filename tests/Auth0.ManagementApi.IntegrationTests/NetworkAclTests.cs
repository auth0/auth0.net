using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models.NetworkAcl;
using Auth0.ManagementApi.Paging;

namespace Auth0.ManagementApi.IntegrationTests
{
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
            var networkAcl = new NetworkAclCreateRequest
            {
                Active = false,
                Priority = 1,
                Description = "Reject all traffic from test cases",
                NetworkAclRule = new NetworkAclRule
                {
                    Action = new NetworkAclAction { Block = true },
                    Match = new NetworkAclMatch
                    {
                        GeoCountryCodes = new List<string> { "CN" }
                    },
                    Scope = NetworkAclScope.Management
                }
            };

            // Create the Network ACL, should not throw an exception
            await fixture.ApiClient.NetworkAclClient.CreateAsync(networkAcl);

            var networkAcls = await fixture.ApiClient.NetworkAclClient.GetAllAsync(new PaginationInfo());
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

                var patchUpdateRequest = new NetworkAclPatchUpdateRequest()
                {
                    Active = false,
                    Priority = 2,
                    Description = "Updated description for test cases",
                    NetworkAclRule = new NetworkAclRule
                    {
                        Action = new NetworkAclAction { Block = true },
                        Match = new NetworkAclMatch
                        {
                            GeoCountryCodes = new List<string> { "US" }
                        },
                        NotMatch = new NetworkAclMatch
                        {
                            GeoCountryCodes = new List<string> { "CA" }
                        }
                    }
                };

                // Get the Network ACL entry, should not throw an exception
                var networkAclEntry =
                    await fixture.ApiClient.NetworkAclClient.GetAsync(networkAcls
                        .FirstOrDefault(x => x.Description == networkAcl.Description).Id);
                networkAclEntry.Should().NotBeNull();
                networkAclEntry.NetworkAclRule.Should().NotBeNull();
                networkAclEntry.NetworkAclRule.Match.Should().NotBeNull();
                networkAclEntry.NetworkAclRule.Match?.GeoCountryCodes.Should()
                    .BeEquivalentTo(new List<string> { "CN" });
                networkAclEntry.NetworkAclRule.NotMatch.Should().BeNull();
                networkAclEntry.Description.Should().Be(networkAcl.Description);

                // Update the Network ACL, should not throw an exception
                var networkAclToBeUpdated = networkAcls.FirstOrDefault(x => x.Description == networkAcl.Description);
                var patchUpdatedNetworkAclEntry =
                    await fixture.ApiClient.NetworkAclClient.UpdateAsync(networkAclToBeUpdated.Id, patchUpdateRequest);

                patchUpdatedNetworkAclEntry.Should().NotBeNull();
                patchUpdatedNetworkAclEntry.NetworkAclRule.Should().NotBeNull();
                patchUpdatedNetworkAclEntry.NetworkAclRule.NotMatch.Should().NotBeNull();
                patchUpdatedNetworkAclEntry.Description.Should().Be(patchUpdateRequest.Description);
                patchUpdatedNetworkAclEntry.NetworkAclRule.NotMatch?.GeoCountryCodes.Should()
                    .BeEquivalentTo(new List<string> { "CA" });

                var putUpdateRequest = new NetworkAclPutUpdateRequest
                {
                    Active = false,
                    Priority = 3,
                    Description = "Updated description for test cases with PUT",
                    NetworkAclRule = new NetworkAclRule
                    {
                        Action = new NetworkAclAction { Block = true },
                        NotMatch = new NetworkAclMatch
                        {
                            GeoCountryCodes = new List<string> { "DE" }
                        }
                    }
                };

                var putUpdatedNetworkAclEntry =
                    await fixture.ApiClient.NetworkAclClient.UpdateAsync(
                        networkAclToBeUpdated.Id, putUpdateRequest);

                putUpdatedNetworkAclEntry.Should().NotBeNull();
                putUpdatedNetworkAclEntry.NetworkAclRule.Should().NotBeNull();
                putUpdatedNetworkAclEntry.NetworkAclRule.NotMatch.Should().NotBeNull();
                putUpdatedNetworkAclEntry.Description.Should().Be(putUpdateRequest.Description);
                putUpdatedNetworkAclEntry.Priority.Should().Be(putUpdateRequest.Priority);
                putUpdatedNetworkAclEntry.NetworkAclRule.NotMatch?.GeoCountryCodes.Should()
                    .BeEquivalentTo(new List<string> { "DE" });
            }
            finally
            {
                // Delete all Network ACLs, should not throw an exception
                foreach (var acl in networkAcls)
                {
                    await fixture.ApiClient.NetworkAclClient.DeleteAsync(acl.Id);
                }
            }
        }
    }
}