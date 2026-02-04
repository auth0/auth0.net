using Auth0.ManagementApi.Organizations.Members;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Organizations.Members;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "start": 1.1,
              "limit": 1.1,
              "total": 1.1,
              "roles": [
                {
                  "id": "id",
                  "name": "name",
                  "description": "description"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/organizations/id/members/user_id/roles")
                    .WithParam("page", "1")
                    .WithParam("per_page", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Organizations.Members.Roles.ListAsync(
            "id",
            "user_id",
            new ListOrganizationMemberRolesRequestParameters
            {
                Page = 1,
                PerPage = 1,
                IncludeTotals = true,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
