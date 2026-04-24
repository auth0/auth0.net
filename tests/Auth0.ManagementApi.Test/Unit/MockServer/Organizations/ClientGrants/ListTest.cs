using Auth0.ManagementApi.Organizations;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Organizations.ClientGrants;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "start": 1.1,
              "limit": 1.1,
              "total": 1.1,
              "client_grants": [
                {
                  "id": "id",
                  "client_id": "client_id",
                  "audience": "audience",
                  "scope": [
                    "scope"
                  ],
                  "organization_usage": "deny",
                  "allow_any_organization": true
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/organizations/id/client-grants")
                    .WithParam("audience", "audience")
                    .WithParam("client_id", "client_id")
                    .WithParam("page", "1")
                    .WithParam("per_page", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Organizations.ClientGrants.ListAsync(
            "id",
            new ListOrganizationClientGrantsRequestParameters
            {
                Audience = "audience",
                ClientId = "client_id",
                GrantIds = new List<string?>() { "grant_ids" },
                Page = 1,
                PerPage = 1,
                IncludeTotals = true,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
