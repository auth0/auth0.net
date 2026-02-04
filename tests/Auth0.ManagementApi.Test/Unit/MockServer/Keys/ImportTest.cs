using Auth0.ManagementApi.Keys;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Keys;

[TestFixture]
public class ImportTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "wrapped_key": "wrapped_key"
            }
            """;

        const string mockResponse = """
            {
              "kid": "kid",
              "type": "customer-provided-root-key",
              "state": "pre-activation",
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z",
              "parent_kid": "parent_kid",
              "public_key": "public_key"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/keys/encryption/kid")
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

        var response = await Client.Keys.Encryption.ImportAsync(
            "kid",
            new ImportEncryptionKeyRequestContent { WrappedKey = "wrapped_key" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
