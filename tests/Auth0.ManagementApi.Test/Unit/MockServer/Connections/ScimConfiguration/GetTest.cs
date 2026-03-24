using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Connections.ScimConfiguration;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
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
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_on": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/connections/id/scim-configuration")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Connections.ScimConfiguration.GetAsync("id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
