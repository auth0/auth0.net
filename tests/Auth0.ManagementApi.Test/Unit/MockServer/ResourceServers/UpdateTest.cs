using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.ResourceServers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "is_system": true,
              "identifier": "identifier",
              "scopes": [
                {
                  "value": "value",
                  "description": "description"
                }
              ],
              "signing_alg": "HS256",
              "signing_secret": "signing_secret",
              "allow_offline_access": true,
              "allow_online_access": true,
              "skip_consent_for_verifiable_first_party_clients": true,
              "token_lifetime": 1,
              "token_lifetime_for_web": 1,
              "enforce_policies": true,
              "token_dialect": "access_token",
              "token_encryption": {
                "format": "compact-nested-jwe",
                "encryption_key": {
                  "name": "name",
                  "alg": "RSA-OAEP-256",
                  "kid": "kid",
                  "pem": "pem"
                }
              },
              "consent_policy": "transactional-authorization-with-mfa",
              "authorization_details": [
                {
                  "key": "value"
                }
              ],
              "proof_of_possession": {
                "mechanism": "mtls",
                "required": true,
                "required_for": "public_clients"
              },
              "subject_type_authorization": {
                "user": {
                  "policy": "allow_all"
                },
                "client": {
                  "policy": "deny_all"
                }
              },
              "client_id": "client_id"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/resource-servers/id")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.ResourceServers.UpdateAsync(
            "id",
            new UpdateResourceServerRequestContent()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
