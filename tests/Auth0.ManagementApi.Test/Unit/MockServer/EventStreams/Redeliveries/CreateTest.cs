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
            {}
            """;

        const string mockResponse = """
            {
              "date_from": "2024-01-15T09:30:00.000Z",
              "date_to": "2024-01-15T09:30:00.000Z",
              "statuses": [
                "failed"
              ],
              "event_types": [
                "user.created"
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
            new CreateEventStreamRedeliveryRequestContent()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
