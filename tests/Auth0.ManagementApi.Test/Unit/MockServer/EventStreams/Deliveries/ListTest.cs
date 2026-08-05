using Auth0.ManagementApi.EventStreams;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.EventStreams.Deliveries;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "deliveries": [
                {
                  "id": "id",
                  "event_stream_id": "event_stream_id",
                  "status": "failed",
                  "event_type": "connection.created",
                  "attempts": [
                    {
                      "status": "failed",
                      "timestamp": "2024-01-15T09:30:00.000Z"
                    }
                  ]
                }
              ],
              "next": "next"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/event-streams/id/deliveries")
                    .WithParam("statuses", "statuses")
                    .WithParam("event_types", "event_types")
                    .WithParam("date_from", "date_from")
                    .WithParam("date_to", "date_to")
                    .WithParam("from", "from")
                    .WithParam("take", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.EventStreams.Deliveries.ListAsync(
            "id",
            new ListEventStreamDeliveriesRequestParameters
            {
                Statuses = "statuses",
                EventTypes = "event_types",
                DateFrom = "date_from",
                DateTo = "date_to",
                From = "from",
                Take = 1,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
