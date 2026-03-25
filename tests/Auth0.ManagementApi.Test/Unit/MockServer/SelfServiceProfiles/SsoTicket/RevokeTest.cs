using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.SelfServiceProfiles.SsoTicket;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RevokeTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/self-service-profiles/profileId/sso-ticket/id/revoke")
                    .UsingPost()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.SelfServiceProfiles.SsoTicket.RevokeAsync("profileId", "id")
        );
    }
}
