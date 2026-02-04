using Auth0.ManagementApi;
using Auth0.ManagementApi.Roles;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Roles;

[TestFixture]
public class DeleteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        const string requestJson = """
            {
              "permissions": [
                {
                  "resource_server_identifier": "resource_server_identifier",
                  "permission_name": "permission_name"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/roles/id/permissions")
                    .WithHeader("Content-Type", "application/json")
                    .UsingDelete()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Roles.Permissions.DeleteAsync(
                "id",
                new DeleteRolePermissionsRequestContent
                {
                    Permissions = new List<PermissionRequestPayload>()
                    {
                        new PermissionRequestPayload
                        {
                            ResourceServerIdentifier = "resource_server_identifier",
                            PermissionName = "permission_name",
                        },
                    },
                }
            )
        );
    }
}
