using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.UserGrants;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteByUserIdTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/grants")
                    .WithParam("user_id", "user_id")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.UserGrants.DeleteByUserIdAsync(
                new DeleteUserGrantByUserIdRequestParameters { UserId = "user_id" }
            )
        );
    }
}
