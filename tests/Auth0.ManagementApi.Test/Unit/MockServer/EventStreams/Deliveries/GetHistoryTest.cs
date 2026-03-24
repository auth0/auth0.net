using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.EventStreams.Deliveries;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetHistoryTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
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
                    .WithPath("/event-streams/id/deliveries/event_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.EventStreams.Deliveries.GetHistoryAsync("id", "event_id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
