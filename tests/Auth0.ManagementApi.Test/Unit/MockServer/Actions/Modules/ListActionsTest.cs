using Auth0.ManagementApi.Actions;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Actions.Modules;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListActionsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "actions": [
                {
                  "action_id": "action_id",
                  "action_name": "action_name",
                  "module_version_id": "module_version_id",
                  "module_version_number": 1,
                  "supported_triggers": [
                    {
                      "id": "post-login"
                    }
                  ]
                }
              ],
              "total": 1,
              "page": 1,
              "per_page": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/actions/modules/id/actions")
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

        var items = await Client.Actions.Modules.ListActionsAsync(
            "id",
            new GetActionModuleActionsRequestParameters { Page = 1, PerPage = 1 }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
