using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Actions;

[TestFixture]
public class GetTest_ : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "id": "id",
              "trigger_id": "trigger_id",
              "status": "unspecified",
              "results": [
                {
                  "action_name": "action_name",
                  "started_at": "2024-01-15T09:30:00.000Z",
                  "ended_at": "2024-01-15T09:30:00.000Z"
                }
              ],
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/actions/executions/id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Actions.Executions.GetAsync("id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
