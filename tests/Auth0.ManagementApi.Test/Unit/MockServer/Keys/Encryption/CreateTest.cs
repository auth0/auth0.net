using Auth0.ManagementApi;
using Auth0.ManagementApi.Keys;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Keys.Encryption;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "type": "customer-provided-root-key"
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
                    .WithPath("/keys/encryption")
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

        var response = await Client.Keys.Encryption.CreateAsync(
            new CreateEncryptionKeyRequestContent
            {
                Type = CreateEncryptionKeyType.CustomerProvidedRootKey,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
