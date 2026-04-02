using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Organizations;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "name": "name"
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "display_name": "display_name",
              "branding": {
                "logo_url": "logo_url",
                "colors": {
                  "primary": "primary",
                  "page_background": "page_background"
                }
              },
              "metadata": {
                "key": "value"
              },
              "token_quota": {
                "client_credentials": {
                  "enforce": true,
                  "per_day": 1,
                  "per_hour": 1
                }
              },
              "enabled_connections": [
                {
                  "connection_id": "connection_id",
                  "assign_membership_on_login": true,
                  "show_as_button": true,
                  "is_signup_enabled": true
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/organizations")
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

        var response = await Client.Organizations.CreateAsync(
            new CreateOrganizationRequestContent { Name = "name" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
