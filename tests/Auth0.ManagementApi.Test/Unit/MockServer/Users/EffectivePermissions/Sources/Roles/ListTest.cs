using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Users.EffectivePermissions.Sources;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Users.EffectivePermissions.Sources.Roles;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "roles": [
                {
                  "id": "id",
                  "name": "name",
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
                    .WithPath("/users/id/effective-permissions/sources/effective-roles")
                    .WithParam("from", "from")
                    .WithParam("take", "1")
                    .WithParam("resource_server_identifier", "resource_server_identifier")
                    .WithParam("permission_name", "permission_name")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Users.EffectivePermissions.Sources.Roles.ListAsync(
            "id",
            new ListUserEffectivePermissionRoleSourceRequestParameters
            {
                From = "from",
                Take = 1,
                ResourceServerIdentifier = "resource_server_identifier",
                PermissionName = "permission_name",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
