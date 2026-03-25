using Auth0.ManagementApi;
using Auth0.ManagementApi.Clients;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Clients.Credentials;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "credential_type": "public_key"
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "kid": "kid",
              "alg": "RS256",
              "credential_type": "public_key",
              "subject_dn": "subject_dn",
              "thumbprint_sha256": "thumbprint_sha256",
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z",
              "expires_at": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/clients/client_id/credentials")
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

        var response = await Client.Clients.Credentials.CreateAsync(
            "client_id",
            new PostClientCredentialRequestContent
            {
                CredentialType = ClientCredentialTypeEnum.PublicKey,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
