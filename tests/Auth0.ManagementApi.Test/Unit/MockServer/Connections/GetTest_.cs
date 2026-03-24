using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Connections;

[TestFixture]
public class GetTest_ : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            [
              {
                "kid": "kid",
                "cert": "cert",
                "pkcs": "pkcs",
                "current": true,
                "next": true,
                "previous": true,
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
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Connections.Keys.GetAsync("id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
