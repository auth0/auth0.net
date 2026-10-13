using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.ClientProfiles;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "description": "description",
              "client_configuration": {
                "organization_usage": {
                  "default_value": "deny"
                },
                "organization_require_behavior": {
                  "default_value": "no_prompt"
                },
                "organization_discovery_methods": {
                  "default_value": [
                    "email"
                  ]
                },
                "require_proof_of_possession": {
                  "default_value": true
                }
              },
              "apply_policy": {
                "external_metadata_type": "cimd",
                "external_metadata_created_by": "client"
              },
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/client-profiles/id").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.ClientProfiles.GetAsync("id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
