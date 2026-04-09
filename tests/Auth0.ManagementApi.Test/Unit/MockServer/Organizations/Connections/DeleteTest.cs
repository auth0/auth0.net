using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Organizations.Connections;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/organizations/id/connections/connection_id")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Organizations.Connections.DeleteAsync("id", "connection_id")
        );
    }
}
