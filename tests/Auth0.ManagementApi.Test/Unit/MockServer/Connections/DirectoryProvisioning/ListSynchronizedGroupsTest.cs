using Auth0.ManagementApi.Connections;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Connections.DirectoryProvisioning;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListSynchronizedGroupsTest : BaseMockServerTest
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
                  "email": "email",
                  "direct_members_count": 1
                }
              ],
              "next": "next"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/connections/id/directory-provisioning/synchronized-groups")
                    .WithParam("from", "from")
                    .WithParam("take", "1")
                    .WithParam("q", "q")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Connections.DirectoryProvisioning.ListSynchronizedGroupsAsync(
            "id",
            new ListSynchronizedGroupsRequestParameters
            {
                From = "from",
                Take = 1,
                Q = "q",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
