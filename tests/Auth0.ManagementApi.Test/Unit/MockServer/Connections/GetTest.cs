using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Connections;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
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
                    .WithPath("/connections/id")
                    .WithParam("fields", "fields")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Connections.GetAsync(
            "id",
            new GetConnectionRequestParameters { Fields = "fields", IncludeFields = true }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
