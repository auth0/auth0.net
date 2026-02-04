using Auth0.ManagementApi;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer;

[TestFixture]
public class RevokeAccessTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/users/id/revoke-access")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Users.RevokeAccessAsync("id", new RevokeUserAccessRequestContent())
        );
    }
}
