using Auth0.ManagementApi;
using Auth0.ManagementApi.Connections;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Connections.DirectoryProvisioning;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteSynchronizedGroupSelectionsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        const string requestJson = """
            {
              "groups": [
                {
                  "id": "id"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/connections/id/directory-provisioning/synchronized-groups")
                    .WithHeader("Content-Type", "application/json")
                    .UsingDelete()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Connections.DirectoryProvisioning.DeleteSynchronizedGroupSelectionsAsync(
                "id",
                new DeleteSynchronizedGroupsRequestContent
                {
                    Groups = new List<SynchronizedGroupSelectionId>()
                    {
                        new SynchronizedGroupSelectionId { Id = "id" },
                    },
                }
            )
        );
    }
}
