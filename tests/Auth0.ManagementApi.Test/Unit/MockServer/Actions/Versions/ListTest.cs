using Auth0.ManagementApi.Actions;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Actions.Versions;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "total": 1.1,
              "page": 1.1,
              "per_page": 1.1,
              "versions": [
                {
                  "id": "id",
                  "action_id": "action_id",
                  "code": "code",
                  "dependencies": [
                    {}
                  ],
                  "deployed": true,
                  "runtime": "runtime",
                  "secrets": [
                    {}
                  ],
                  "status": "pending",
                  "number": 1.1,
                  "errors": [
                    {}
                  ],
                  "built_at": "2024-01-15T09:30:00.000Z",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z",
                  "supported_triggers": [
                    {
                      "id": "post-login"
                    }
                  ],
                  "modules": [
                    {}
                  ]
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/actions/actions/actionId/versions")
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

        var items = await Client.Actions.Versions.ListAsync(
            "actionId",
            new ListActionVersionsRequestParameters { Page = 1, PerPage = 1 }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
