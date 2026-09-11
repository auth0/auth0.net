using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Organizations;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SearchTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "organizations": [
                {
                  "id": "id",
                  "name": "name",
                  "display_name": "display_name",
                  "token_quota": {
                    "client_credentials": {}
                  },
                  "third_party_client_access": "block",
                  "is_app_entitlement_active": true
                }
              ],
              "next": "next"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/organizations/search")
                    .WithParam("q", "q")
                    .WithParam("parser", "scim")
                    .WithParam("take", "1")
                    .WithParam("from", "from")
                    .WithParam("sort", "name")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Organizations.SearchAsync(
            new SearchOrganizationsRequestParameters
            {
                Q = "q",
                Parser = SearchParserEnum.Scim,
                Take = 1,
                From = "from",
                Sort = OrganizationSortFieldEnum.Name,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
