using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Connections;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "next": "next",
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
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/connections")
                    .WithParam("from", "from")
                    .WithParam("take", "1")
                    .WithParam("name", "name")
                    .WithParam("fields", "fields")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Connections.ListAsync(
            new ListConnectionsQueryParameters
            {
                From = "from",
                Take = 1,
                Name = "name",
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
