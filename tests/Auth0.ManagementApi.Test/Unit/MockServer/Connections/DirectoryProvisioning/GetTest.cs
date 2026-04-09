using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Connections.DirectoryProvisioning;

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
              "mapping": [
                {
                  "auth0": "auth0",
                  "idp": "idp"
                }
              ],
              "synchronize_automatically": true,
              "synchronize_groups": "all",
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z",
              "last_synchronization_at": "2024-01-15T09:30:00.000Z",
              "last_synchronization_status": "last_synchronization_status",
              "last_synchronization_error": "last_synchronization_error"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/connections/id/directory-provisioning")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Connections.DirectoryProvisioning.GetAsync("id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
