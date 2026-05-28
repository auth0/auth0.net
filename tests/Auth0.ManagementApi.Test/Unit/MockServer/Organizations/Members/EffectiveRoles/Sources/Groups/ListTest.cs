using Auth0.ManagementApi.Organizations.Members.EffectiveRoles.Sources;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Organizations.Members.EffectiveRoles.Sources.Groups;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "groups": [
                {
                  "id": "id",
                  "name": "name",
                  "external_id": "external_id",
                  "connection_id": "connection_id",
                  "tenant_name": "tenant_name",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z"
                }
              ],
              "next": "next"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/organizations/id/members/user_id/effective-roles/sources/groups")
                    .WithParam("from", "from")
                    .WithParam("take", "1")
                    .WithParam("role_id", "role_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Organizations.Members.EffectiveRoles.Sources.Groups.ListAsync(
            "id",
            "user_id",
            new ListOrganizationMemberRoleSourceGroupsRequestParameters
            {
                From = "from",
                Take = 1,
                RoleId = "role_id",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
