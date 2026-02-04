using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Connections;

[TestFixture]
public class CreateTest_ : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "connection_id": "connection_id",
              "connection_name": "connection_name",
              "strategy": "strategy",
              "tenant_name": "tenant_name",
              "user_id_attribute": "user_id_attribute",
              "mapping": [
                {
                  "auth0": "auth0",
                  "scim": "scim"
                }
              ],
              "created_at": "created_at",
              "updated_on": "updated_on"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/connections/id/scim-configuration")
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

        var response = await Client.Connections.ScimConfiguration.CreateAsync(
            "id",
            new CreateScimConfigurationRequestContent()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
