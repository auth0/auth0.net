using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Clients;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RegisterCimdClientTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "external_client_id": "external_client_id"
            }
            """;

        const string mockResponse = """
            {
              "client_id": "client_id",
              "mapped_fields": {
                "external_client_id": "external_client_id",
                "name": "name",
                "app_type": "app_type",
                "callbacks": [
                  "callbacks"
                ],
                "logo_uri": "logo_uri",
                "description": "description",
                "grant_types": [
                  "grant_types"
                ],
                "token_endpoint_auth_method": "token_endpoint_auth_method",
                "jwks_uri": "jwks_uri",
                "client_authentication_methods": {
                  "private_key_jwt": {
                    "credentials": [
                      {
                        "credential_type": "credential_type",
                        "kid": "kid",
                        "alg": "alg"
                      }
                    ]
                  }
                }
              },
              "validation": {
                "valid": true,
                "violations": [
                  "violations"
                ],
                "warnings": [
                  "warnings"
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/clients/cimd/register")
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

        var response = await Client.Clients.RegisterCimdClientAsync(
            new RegisterCimdClientRequestContent { ExternalClientId = "external_client_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
