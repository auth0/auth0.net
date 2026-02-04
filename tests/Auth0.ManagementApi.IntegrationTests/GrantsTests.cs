using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

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
    private GrantsTestsFixture fixture;

    public GrantsTests(GrantsTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Test_GetAll()
    {
        var grantsPager = await fixture.ApiClient.UserGrants.ListAsync(new ListUserGrantsRequestParameters
        {
            Page = 0,
            PerPage = 50,
            IncludeTotals = true
        });

        // Just verify we can call the API without errors
        // The result may be empty if there are no grants
    }
}
