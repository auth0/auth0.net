using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Users.Multifactor;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteProviderTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/users/id/multifactor/duo")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Users.Multifactor.DeleteProviderAsync(
                "id",
                UserMultifactorProviderEnum.Duo
            )
        );
    }
}
