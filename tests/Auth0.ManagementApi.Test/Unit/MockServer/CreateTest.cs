using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "name": "name",
              "supported_triggers": [
                {
                  "id": "id"
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
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
                    "id": "id"
                  }
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
                    "id": "id"
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
              "deploy": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/actions/actions")
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

        var response = await Client.Actions.CreateAsync(
            new CreateActionRequestContent
            {
                Name = "name",
                SupportedTriggers = new List<ActionTrigger>() { new ActionTrigger { Id = "id" } },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
