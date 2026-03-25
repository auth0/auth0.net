using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Actions;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeployTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "id": "id",
              "action_id": "action_id",
              "code": "code",
              "dependencies": [
                {
                  "name": "name",
                  "version": "version",
                  "registry_url": "registry_url"
                }
              ],
              "deployed": true,
              "runtime": "runtime",
              "secrets": [
                {
                  "name": "name",
                  "updated_at": "2024-01-15T09:30:00.000Z"
                }
              ],
              "status": "pending",
              "number": 1.1,
              "errors": [
                {
                  "id": "id",
                  "msg": "msg",
                  "url": "url"
                }
              ],
              "action": {
                "id": "id",
                "name": "name",
                "supported_triggers": [
                  {
                    "id": "id"
                  }
                ],
                "all_changes_deployed": true,
                "created_at": "2024-01-15T09:30:00.000Z",
                "updated_at": "2024-01-15T09:30:00.000Z"
              },
              "built_at": "2024-01-15T09:30:00.000Z",
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z",
              "supported_triggers": [
                {
                  "id": "id",
                  "version": "version",
                  "status": "status",
                  "runtimes": [
                    "runtimes"
                  ],
                  "default_runtime": "default_runtime",
                  "compatible_triggers": [
                    {
                      "id": "id",
                      "version": "version"
                    }
                  ],
                  "binding_policy": "trigger-bound"
                }
              ],
              "modules": [
                {
                  "module_id": "module_id",
                  "module_name": "module_name",
                  "module_version_id": "module_version_id",
                  "module_version_number": 1
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/actions/actions/id/deploy")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Actions.DeployAsync("id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
