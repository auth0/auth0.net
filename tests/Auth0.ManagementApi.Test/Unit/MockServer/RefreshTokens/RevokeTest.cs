using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.RefreshTokens;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RevokeTest : BaseMockServerTest
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
                    .WithPath("/refresh-tokens/revoke")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.RefreshTokens.RevokeAsync(new RevokeRefreshTokensRequestContent())
        );
    }
}
