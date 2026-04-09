using Auth0.ManagementApi.Connections;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Connections.DirectoryProvisioning;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "directory_provisionings": [
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
              ],
              "next": "next"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/connections-directory-provisionings")
                    .WithParam("from", "from")
                    .WithParam("take", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Connections.DirectoryProvisioning.ListAsync(
            new ListDirectoryProvisioningsRequestParameters { From = "from", Take = 1 }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
