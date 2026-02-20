using Auth0.ManagementApi.Actions.Modules;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Actions.Modules;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "versions": [
                {
                  "id": "id",
                  "module_id": "module_id",
                  "version_number": 1,
                  "code": "code",
                  "secrets": [
                    {}
                  ],
                  "dependencies": [
                    {}
                  ],
                  "created_at": "2024-01-15T09:30:00.000Z"
                }
              ],
              "total": 1,
              "page": 1,
              "per_page": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/actions/modules/id/versions")
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

        var items = await Client.Actions.Modules.Versions.ListAsync(
            "id",
            new GetActionModuleVersionsRequestParameters { Page = 1, PerPage = 1 }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
