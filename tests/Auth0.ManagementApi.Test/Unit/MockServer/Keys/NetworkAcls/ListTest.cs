using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Keys.NetworkAcls;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "keys": [
                {
                  "id": "id",
                  "name": "name",
                  "alg": "hmac-sha256",
                  "fingerprint": "fingerprint",
                  "created_at": "created_at",
                  "updated_at": "updated_at"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/keys/network-acls").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Keys.NetworkAcls.ListAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
