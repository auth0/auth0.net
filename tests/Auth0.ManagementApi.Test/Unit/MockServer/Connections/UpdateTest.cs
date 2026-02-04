using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Connections;

[TestFixture]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        const string requestJson = """
            [
              {
                "client_id": "client_id",
                "status": true
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/connections/id/clients")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Connections.Clients.UpdateAsync(
                "id",
                new List<UpdateEnabledClientConnectionsRequestContentItem>()
                {
                    new UpdateEnabledClientConnectionsRequestContentItem
                    {
                        ClientId = "client_id",
                        Status = true,
                    },
                }
            )
        );
    }
}
