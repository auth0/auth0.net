using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.ConnectionProfiles;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTemplateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "id": "id",
              "display_name": "display_name",
              "template": {
                "name": "name",
                "organization": {
                  "show_as_button": "none",
                  "assign_membership_on_login": "none"
                },
                "connection_name_prefix_template": "connection_name_prefix_template",
                "enabled_features": [
                  "scim"
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/connection-profiles/templates/id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.ConnectionProfiles.GetTemplateAsync("id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
