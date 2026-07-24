using Auth0.ManagementApi.EventStreams;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.EventStreams.Redeliveries;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "date_from": "2024-01-15T09:30:00Z",
              "date_to": "2024-01-15T10:30:00Z"
            }
            """;

        const string mockResponse = """
            {
              "date_from": "2024-01-15T09:30:00.000Z",
              "date_to": "2024-01-15T09:30:00.000Z",
              "statuses": [
                "failed"
              ],
              "event_types": [
                "connection.created"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/event-streams/id/redeliver")
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

        var response = await Client.EventStreams.Redeliveries.CreateAsync(
            "id",
            new CreateEventStreamRedeliveryRequestContent
            {
                DateFrom = new DateTime(2024, 1, 15, 9, 30, 0, 123, DateTimeKind.Utc),
                DateTo = new DateTime(2024, 1, 15, 10, 30, 0, 456, DateTimeKind.Utc),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
