using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.UserBlocks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteByIdentifierTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/user-blocks")
                    .WithParam("identifier", "identifier")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.UserBlocks.DeleteByIdentifierAsync(
                new DeleteUserBlocksByIdentifierRequestParameters { Identifier = "identifier" }
            )
        );
    }
}
