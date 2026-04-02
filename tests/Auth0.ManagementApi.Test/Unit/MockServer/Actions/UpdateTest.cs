using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Actions;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "supported_triggers": [
                {
                  "id": "post-login",
                  "version": "version",
                  "status": "status",
                  "runtimes": [
                    "runtimes"
                  ],
                  "default_runtime": "default_runtime",
                  "compatible_triggers": [
                    {
                      "id": "post-login",
                      "version": "version"
                    }
                  ],
                  "binding_policy": "trigger-bound"
                }
              ],
              "all_changes_deployed": true,
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z",
              "code": "code",
              "dependencies": [
                {
                  "name": "name",
                  "version": "version",
                  "registry_url": "registry_url"
                }
              ],
              "runtime": "runtime",
              "secrets": [
                {
                  "name": "name",
                  "updated_at": "2024-01-15T09:30:00.000Z"
                }
              ],
              "deployed_version": {
                "id": "id",
                "action_id": "action_id",
                "code": "code",
                "dependencies": [
                  {}
                ],
                "deployed": true,
                "runtime": "runtime",
                "secrets": [
                  {}
                ],
                "status": "pending",
                "number": 1.1,
                "errors": [
                  {}
                ],
                "action": {
                  "id": "id",
                  "name": "name",
                  "supported_triggers": [
                    {
                      "id": "post-login"
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
                    "id": "post-login"
                  }
                ],
                "modules": [
                  {}
                ]
              },
              "installed_integration_id": "installed_integration_id",
              "integration": {
                "id": "id",
                "catalog_id": "catalog_id",
                "url_slug": "url_slug",
                "partner_id": "partner_id",
                "name": "name",
                "description": "description",
                "short_description": "short_description",
                "logo": "logo",
                "feature_type": "unspecified",
                "terms_of_use_url": "terms_of_use_url",
                "privacy_policy_url": "privacy_policy_url",
                "public_support_link": "public_support_link",
                "current_release": {
                  "id": "id",
                  "trigger": {
                    "id": "post-login"
                  },
                  "required_secrets": [
                    {}
                  ],
                  "required_configuration": [
                    {}
                  ]
                },
                "created_at": "2024-01-15T09:30:00.000Z",
                "updated_at": "2024-01-15T09:30:00.000Z"
              },
              "status": "pending",
              "built_at": "2024-01-15T09:30:00.000Z",
              "deploy": true,
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
                    .WithPath("/actions/actions/id")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Actions.UpdateAsync("id", new UpdateActionRequestContent());
        JsonAssert.AreEqual(response, mockResponse);
    }
}
