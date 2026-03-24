using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Connections;

[TestFixture]
public class CreateTest_ : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            [
              {
                "kid": "kid",
                "cert": "cert",
                "pkcs": "pkcs",
                "current": true,
                "next": true,
                "current_since": "current_since",
                "fingerprint": "fingerprint",
                "thumbprint": "thumbprint",
                "algorithm": "algorithm",
                "key_use": "encryption",
                "subject_dn": "subject_dn"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/connections/id/keys")
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

        var response = await Client.Connections.Keys.CreateAsync(
            "id",
            new PostConnectionKeysRequestContent()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
