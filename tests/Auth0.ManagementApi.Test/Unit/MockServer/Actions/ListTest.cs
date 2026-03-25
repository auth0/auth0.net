using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Actions;

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
              "actions": [
                {
                  "id": "id",
                  "name": "name",
                  "supported_triggers": [
                    {
                      "id": "id"
                    }
                  ],
                  "all_changes_deployed": true,
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z",
                  "code": "code",
                  "dependencies": [
                    {}
                  ],
                  "runtime": "runtime",
                  "secrets": [
                    {}
                  ],
                  "installed_integration_id": "installed_integration_id",
                  "status": "pending",
                  "built_at": "2024-01-15T09:30:00.000Z",
                  "deploy": true,
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
                    .WithPath("/actions/actions")
                    .WithParam("triggerId", "triggerId")
                    .WithParam("actionName", "actionName")
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

        var items = await Client.Actions.ListAsync(
            new ListActionsRequestParameters
            {
                TriggerId = "triggerId",
                ActionName = "actionName",
                Deployed = true,
                Page = 1,
                PerPage = 1,
                Installed = true,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
