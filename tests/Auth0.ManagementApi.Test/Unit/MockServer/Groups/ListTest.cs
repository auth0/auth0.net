using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Groups;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "groups": [
                {
                  "id": "id",
                  "name": "name",
                  "external_id": "external_id",
                  "connection_id": "connection_id",
                  "tenant_name": "tenant_name",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z"
                }
              ],
              "next": "next",
              "start": 1.1,
              "limit": 1.1,
              "total": 1.1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/groups")
                    .WithParam("connection_id", "connection_id")
                    .WithParam("name", "name")
                    .WithParam("external_id", "external_id")
                    .WithParam("search", "search")
                    .WithParam("fields", "fields")
                    .WithParam("from", "from")
                    .WithParam("take", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Groups.ListAsync(
            new ListGroupsRequestParameters
            {
                ConnectionId = "connection_id",
                Name = "name",
                ExternalId = "external_id",
                Search = "search",
                Fields = "fields",
                IncludeFields = true,
                From = "from",
                Take = 1,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
