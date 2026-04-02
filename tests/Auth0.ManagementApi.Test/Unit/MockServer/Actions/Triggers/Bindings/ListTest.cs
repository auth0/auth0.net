using Auth0.ManagementApi;
using Auth0.ManagementApi.Actions.Triggers;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Actions.Triggers.Bindings;

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
              "bindings": [
                {
                  "id": "id",
                  "trigger_id": "post-login",
                  "display_name": "display_name",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/actions/triggers/post-login/bindings")
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

        var items = await Client.Actions.Triggers.Bindings.ListAsync(
            ActionTriggerTypeEnum.PostLogin,
            new ListActionTriggerBindingsRequestParameters { Page = 1, PerPage = 1 }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
