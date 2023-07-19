using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models.Grants;
using Auth0.ManagementApi.Paging;
using Xunit;


namespace Auth0.ManagementApi.IntegrationTests
{
    public class GrantsTestsFixture : TestBaseFixture
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

    public class GrantsTests : IClassFixture<GrantsTestsFixture>
    {
        GrantsTestsFixture fixture;

        public GrantsTests(GrantsTestsFixture fixture)
        {
            this.fixture = fixture;
        }



        [Fact]
        public async Task Test_GetAll()
        {
            var grants = await fixture.ApiClient.Grants.GetAllAsync(new GetGrantsRequest(), new PaginationInfo(0, 50, true));
        }

    }
}
