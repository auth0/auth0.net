using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Keys;

[TestFixture]
public class GetTest_ : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "kid": "kid",
              "cert": "cert",
              "pkcs7": "pkcs7",
              "current": true,
              "next": true,
              "previous": true,
              "current_since": "current_since",
              "current_until": "current_until",
              "fingerprint": "fingerprint",
              "thumbprint": "thumbprint",
              "revoked": true,
              "revoked_at": "revoked_at"
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/keys/signing/kid").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Keys.Signing.GetAsync("kid");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
