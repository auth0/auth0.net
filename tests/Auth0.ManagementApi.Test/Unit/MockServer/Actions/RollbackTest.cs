using Auth0.ManagementApi.Actions;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Actions;

[TestFixture]
public class RollbackTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "module_version_id": "module_version_id"
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "code": "code",
              "dependencies": [
                {
                  "name": "name",
                  "version": "version"
                }
              ],
              "secrets": [
                {
                  "name": "name",
                  "updated_at": "2024-01-15T09:30:00.000Z"
                }
              ],
              "actions_using_module_total": 1,
              "all_changes_published": true,
              "latest_version_number": 1,
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z",
              "latest_version": {
                "id": "id",
                "version_number": 1,
                "code": "code",
                "dependencies": [
                  {}
                ],
                "secrets": [
                  {}
                ],
                "created_at": "2024-01-15T09:30:00.000Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/actions/modules/id/rollback")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Actions.Modules.RollbackAsync(
            "id",
            new RollbackActionModuleRequestParameters { ModuleVersionId = "module_version_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
