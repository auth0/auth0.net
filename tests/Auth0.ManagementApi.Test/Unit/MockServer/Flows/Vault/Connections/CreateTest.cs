using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Flows.Vault.Connections;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "name": "name",
              "app_id": "ACTIVECAMPAIGN",
              "setup": {
                "type": "API_KEY",
                "api_key": "api_key",
                "base_url": "base_url"
              }
            }
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
                    .WithPath("/flows/vault/connections")
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

        var response = await Client.Flows.Vault.Connections.CreateAsync(
            new CreateFlowsVaultConnectionActivecampaignApiKey
            {
                Name = "name",
                AppId = FlowsVaultConnectionAppIdActivecampaignEnum.Activecampaign,
                Setup = new FlowsVaultConnectioSetupApiKeyWithBaseUrl
                {
                    Type = FlowsVaultConnectioSetupTypeApiKeyEnum.ApiKey,
                    ApiKey = "api_key",
                    BaseUrl = "base_url",
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
