using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.EventStreams.Redeliveries;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateByIdTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/event-streams/id/redeliver/event_id")
                    .UsingPost()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.EventStreams.Redeliveries.CreateByIdAsync("id", "event_id")
        );
    }
}
