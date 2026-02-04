using Auth0.ManagementApi.Flows.Vault;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Flows.Vault;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "start": 1.1,
              "limit": 1.1,
              "total": 1.1,
              "connections": [
                {
                  "id": "id",
                  "app_id": "app_id",
                  "name": "name",
                  "account_name": "account_name",
                  "ready": true,
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z",
                  "refreshed_at": "2024-01-15T09:30:00.000Z",
                  "fingerprint": "fingerprint"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/flows/vault/connections")
                    .WithParam("page", "1")
                    .WithParam("per_page", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Flows.Vault.Connections.ListAsync(
            new ListFlowsVaultConnectionsRequestParameters
            {
                Page = 1,
                PerPage = 1,
                IncludeTotals = true,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
