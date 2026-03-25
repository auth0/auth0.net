using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Logs;

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
              "length": 1.1,
              "total": 1.1,
              "logs": [
                {
                  "date": "date",
                  "type": "type",
                  "description": "description",
                  "connection": "connection",
                  "connection_id": "connection_id",
                  "client_id": "client_id",
                  "client_name": "client_name",
                  "ip": "ip",
                  "hostname": "hostname",
                  "user_id": "user_id",
                  "user_name": "user_name",
                  "audience": "audience",
                  "scope": "scope",
                  "strategy": "strategy",
                  "strategy_type": "strategy_type",
                  "log_id": "log_id",
                  "isMobile": true,
                  "details": {
                    "key": "value"
                  },
                  "user_agent": "user_agent"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/logs")
                    .WithParam("page", "1")
                    .WithParam("per_page", "1")
                    .WithParam("sort", "sort")
                    .WithParam("fields", "fields")
                    .WithParam("search", "search")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Logs.ListAsync(
            new ListLogsRequestParameters
            {
                Page = 1,
                PerPage = 1,
                Sort = "sort",
                Fields = "fields",
                IncludeFields = true,
                IncludeTotals = true,
                Search = "search",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
