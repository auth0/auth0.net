using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer;

[TestFixture]
public class TestTest_ : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "event_type": "user.created"
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "event_stream_id": "event_stream_id",
              "status": "failed",
              "event_type": "user.created",
              "attempts": [
                {
                  "status": "failed",
                  "timestamp": "2024-01-15T09:30:00.000Z",
                  "error_message": "error_message"
                }
              ],
              "event": {
                "id": "id",
                "source": "source",
                "specversion": "specversion",
                "type": "type",
                "time": "2024-01-15T09:30:00.000Z",
                "data": "data"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/event-streams/id/test")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.EventStreams.TestAsync(
            "id",
            new CreateEventStreamTestEventRequestContent
            {
                EventType = EventStreamTestEventTypeEnum.UserCreated,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
