using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Keys;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "keys": [
                {
                  "kty": "EC",
                  "kid": "kid",
                  "use": "sig",
                  "key_ops": [
                    "verify"
                  ],
                  "alg": "RS256",
                  "n": "n",
                  "e": "e",
                  "crv": "P-256",
                  "x": "x",
                  "y": "y",
                  "x5u": "x5u",
                  "x5c": [
                    "x5c"
                  ],
                  "x5t": "x5t",
                  "x5t#S256": "x5t#S256"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/keys/custom-signing")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Keys.CustomSigning.GetAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
