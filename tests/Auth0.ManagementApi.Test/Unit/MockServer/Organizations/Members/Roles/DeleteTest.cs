using Auth0.ManagementApi.Organizations.Members;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Organizations.Members.Roles;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        const string requestJson = """
            {
              "roles": [
                "roles"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/organizations/id/members/user_id/roles")
                    .WithHeader("Content-Type", "application/json")
                    .UsingDelete()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Organizations.Members.Roles.DeleteAsync(
                "id",
                "user_id",
                new DeleteOrganizationMemberRolesRequestContent
                {
                    Roles = new List<string>() { "roles" },
                }
            )
        );
    }
}
