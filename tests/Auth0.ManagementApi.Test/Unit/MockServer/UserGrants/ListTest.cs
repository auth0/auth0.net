using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.UserGrants;

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
              "grants": [
                {
                  "id": "id",
                  "clientID": "clientID",
                  "user_id": "user_id",
                  "audience": "audience",
                  "scope": [
                    "scope"
                  ]
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/grants")
                    .WithParam("per_page", "1")
                    .WithParam("page", "1")
                    .WithParam("user_id", "user_id")
                    .WithParam("client_id", "client_id")
                    .WithParam("audience", "audience")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.UserGrants.ListAsync(
            new ListUserGrantsRequestParameters
            {
                PerPage = 1,
                Page = 1,
                IncludeTotals = true,
                UserId = "user_id",
                ClientId = "client_id",
                Audience = "audience",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
