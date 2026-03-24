using Auth0.ManagementApi.Actions.Triggers;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Actions.Triggers.Bindings;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateManyTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "bindings": [
                {
                  "id": "id",
                  "trigger_id": "trigger_id",
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
                    .WithPath("/actions/triggers/triggerId/bindings")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Actions.Triggers.Bindings.UpdateManyAsync(
            "triggerId",
            new UpdateActionBindingsRequestContent()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
