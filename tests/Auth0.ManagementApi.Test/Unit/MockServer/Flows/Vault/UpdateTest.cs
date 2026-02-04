using Auth0.ManagementApi.Flows.Vault;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Flows.Vault;

[TestFixture]
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
              "app_id": "app_id",
              "environment": "environment",
              "name": "name",
              "account_name": "account_name",
              "ready": true,
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z",
              "refreshed_at": "2024-01-15T09:30:00.000Z",
              "fingerprint": "fingerprint"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/flows/vault/connections/id")
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

        var response = await Client.Flows.Vault.Connections.UpdateAsync(
            "id",
            new UpdateFlowsVaultConnectionRequestContent()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
