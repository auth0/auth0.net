using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.ConnectionProfiles;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "organization": {
                "show_as_button": "none",
                "assign_membership_on_login": "none"
              },
              "connection_name_prefix_template": "connection_name_prefix_template",
              "enabled_features": [
                "scim"
              ],
              "strategy_overrides": {
                "pingfederate": {
                  "enabled_features": [
                    "scim"
                  ]
                },
                "ad": {
                  "enabled_features": [
                    "scim"
                  ]
                },
                "adfs": {
                  "enabled_features": [
                    "scim"
                  ]
                },
                "waad": {
                  "enabled_features": [
                    "scim"
                  ]
                },
                "google-apps": {
                  "enabled_features": [
                    "scim"
                  ]
                },
                "okta": {
                  "enabled_features": [
                    "scim"
                  ]
                },
                "oidc": {
                  "enabled_features": [
                    "scim"
                  ]
                },
                "samlp": {
                  "enabled_features": [
                    "scim"
                  ]
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/connection-profiles/id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.ConnectionProfiles.GetAsync("id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
