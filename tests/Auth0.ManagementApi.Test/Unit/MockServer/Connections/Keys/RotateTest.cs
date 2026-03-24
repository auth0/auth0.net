using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Connections.Keys;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RotateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "kid": "kid",
              "cert": "cert",
              "pkcs": "pkcs",
              "next": true,
              "fingerprint": "fingerprint",
              "thumbprint": "thumbprint",
              "algorithm": "algorithm",
              "key_use": "encryption",
              "subject_dn": "subject_dn"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/connections/id/keys/rotate")
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

        var response = await Client.Connections.Keys.RotateAsync(
            "id",
            new RotateConnectionKeysRequestContent()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
