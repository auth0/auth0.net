using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Connections;

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
              "strategy": "ad"
            }
            """;

        const string mockResponse = """
            {
              "name": "name",
              "display_name": "display_name",
              "options": {
                "key": "value"
              },
              "id": "id",
              "strategy": "strategy",
              "realms": [
                "realms"
              ],
              "enabled_clients": [
                "enabled_clients"
              ],
              "is_domain_connection": true,
              "show_as_button": true,
              "metadata": {
                "key": "value"
              },
              "authentication": {
                "active": true
              },
              "connected_accounts": {
                "active": true,
                "cross_app_access": true
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/connections")
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

        var response = await Client.Connections.CreateAsync(
            new CreateConnectionRequestContent
            {
                Name = "name",
                Strategy = ConnectionIdentityProviderEnum.Ad,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
