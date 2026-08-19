using Auth0.ManagementApi;
using Auth0.ManagementApi.Keys;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Keys.NetworkAcls;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "name": "name",
              "alg": "hmac-sha256",
              "value": "value"
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "alg": "hmac-sha256",
              "fingerprint": "fingerprint",
              "created_at": "created_at",
              "updated_at": "updated_at"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/keys/network-acls")
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

        var response = await Client.Keys.NetworkAcls.CreateAsync(
            new CreateKeysNetworkAclsRequestContent
            {
                Name = "name",
                Alg = NetworkAclKeyAlgorithmEnum.HmacSha256,
                Value = "value",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
