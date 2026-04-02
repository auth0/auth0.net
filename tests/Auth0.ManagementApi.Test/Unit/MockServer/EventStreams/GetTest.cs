using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.EventStreams;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "subscriptions": [
                {
                  "event_type": "event_type"
                }
              ],
              "destination": {
                "type": "webhook",
                "configuration": {
                  "webhook_endpoint": "webhook_endpoint",
                  "webhook_authorization": {
                    "method": "basic",
                    "username": "username"
                  }
                }
              },
              "status": "enabled",
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/event-streams/id").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.EventStreams.GetAsync("id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
