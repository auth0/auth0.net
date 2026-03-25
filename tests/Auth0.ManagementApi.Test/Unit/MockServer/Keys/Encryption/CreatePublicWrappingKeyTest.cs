using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Keys.Encryption;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreatePublicWrappingKeyTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "public_key": "public_key",
              "algorithm": "CKM_RSA_AES_KEY_WRAP"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/keys/encryption/kid/wrapping-key")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Keys.Encryption.CreatePublicWrappingKeyAsync("kid");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
