using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Users;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Users.Permissions;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
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
                    .WithPath("/users/id/permissions")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Users.Permissions.CreateAsync(
                "id",
                new CreateUserPermissionsRequestContent
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
