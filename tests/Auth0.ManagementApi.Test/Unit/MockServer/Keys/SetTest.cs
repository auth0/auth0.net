using Auth0.ManagementApi;
using Auth0.ManagementApi.Keys;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Keys;

[TestFixture]
public class SetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "keys": [
                {
                  "kty": "EC"
                }
              ]
            }
            """;

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
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Keys.CustomSigning.SetAsync(
            new SetCustomSigningKeysRequestContent
            {
                Keys = new List<CustomSigningKeyJwk>()
                {
                    new CustomSigningKeyJwk { Kty = CustomSigningKeyTypeEnum.Ec },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
