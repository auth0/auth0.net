using System.Linq;
using System.Text.Json;
using Auth0.ManagementApi.EventStreams;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.EventStreams.Redeliveries;

// Hand-written (see .fernignore). Complements the generated CreateTest, which
// only sends an empty body. This exercises Rfc3339SecondsDateTimeConverter end
// to end through the real serializer + HTTP pipeline, asserting that
// date_from/date_to go on the wire as spec-compliant, seconds-only RFC 3339
// values (maxLength 20) — the fix for the redelivery HTTP 400.
[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RedeliveryDateSerializationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task Serializes_DateFrom_DateTo_AsSecondsOnlyRfc3339()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/event-streams/id/redeliver")
                    .UsingPost()
            )
            .RespondWith(
                WireMock.ResponseBuilders.Response.Create().WithStatusCode(200).WithBody("{}")
            );

        await Client.EventStreams.Redeliveries.CreateAsync(
            "id",
            new CreateEventStreamRedeliveryRequestContent
            {
                DateFrom = new DateTime(2024, 1, 15, 9, 30, 0, DateTimeKind.Utc),
                DateTo = new DateTime(2024, 1, 15, 10, 15, 30, DateTimeKind.Utc),
            }
        );

        // Inspect the request body the SDK actually put on the wire.
        var body = Server.LogEntries.Single().RequestMessage.Body;
        Assert.That(body, Is.Not.Null);

        using var doc = JsonDocument.Parse(body!);
        var dateFrom = doc.RootElement.GetProperty("date_from").GetString();
        var dateTo = doc.RootElement.GetProperty("date_to").GetString();

        Assert.That(dateFrom, Is.EqualTo("2024-01-15T09:30:00Z"));
        Assert.That(dateFrom!.Length, Is.EqualTo(20));
        Assert.That(dateTo, Is.EqualTo("2024-01-15T10:15:30Z"));
        Assert.That(dateTo!.Length, Is.EqualTo(20));
    }
}
