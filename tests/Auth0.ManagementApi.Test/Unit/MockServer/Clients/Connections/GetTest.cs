using Auth0.ManagementApi.Clients;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Clients.Connections;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "connections": [
                {
                  "name": "name",
                  "display_name": "display_name",
                  "options": {
                    "key": "value"
                  },
                  "id": "id",
                  "strategy": "strategy",
                  "realms": [
                    "realms"
                  ],
                  "is_domain_connection": true,
                  "show_as_button": true,
                  "authentication": {
                    "active": true
                  },
                  "connected_accounts": {
                    "active": true
                  }
                }
              ],
              "next": "next"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/clients/id/connections")
                    .WithParam("from", "from")
                    .WithParam("take", "1")
                    .WithParam("fields", "fields")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Clients.Connections.GetAsync(
            "id",
            new ConnectionsGetRequest
            {
                From = "from",
                Take = 1,
                Fields = "fields",
                IncludeFields = true,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
