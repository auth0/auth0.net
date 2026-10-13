using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.ClientGrants;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SearchTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "client_grants": [
                {
                  "id": "id",
                  "client_id": "client_id",
                  "audience": "audience",
                  "scope": [
                    "scope"
                  ],
                  "organization_usage": "deny",
                  "allow_any_organization": true,
                  "default_for": "third_party_clients",
                  "is_system": true,
                  "subject_type": "client",
                  "authorization_details_types": [
                    "authorization_details_types"
                  ],
                  "allow_all_scopes": true
                }
              ],
              "next": "next"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/client-grants/search")
                    .WithParam("q", "q")
                    .WithParam("parser", "scim")
                    .WithParam("fields", "fields")
                    .WithParam("take", "1")
                    .WithParam("from", "from")
                    .WithParam("sort", "audience")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.ClientGrants.SearchAsync(
            new SearchClientGrantsRequestParameters
            {
                Q = "q",
                Parser = SearchParserEnum.Scim,
                Fields = "fields",
                IncludeFields = true,
                Take = 1,
                From = "from",
                Sort = ClientGrantSortFieldEnum.Audience,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
