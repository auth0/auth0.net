using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Users;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Users.EffectivePermissions;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "permissions": [
                {
                  "resource_server_identifier": "resource_server_identifier",
                  "permission_name": "permission_name",
                  "resource_server_name": "resource_server_name",
                  "description": "description",
                  "sources": [
                    "direct"
                  ]
                }
              ],
              "next": "next"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/users/id/effective-permissions")
                    .WithParam("from", "from")
                    .WithParam("take", "1")
                    .WithParam("resource_server_identifier", "resource_server_identifier")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Users.EffectivePermissions.ListAsync(
            "id",
            new ListUserEffectivePermissionsRequestParameters
            {
                From = "from",
                Take = 1,
                ResourceServerIdentifier = "resource_server_identifier",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
