using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer;

[TestFixture]
public class GetTemplateTest_ : BaseMockServerTest
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
                "user_id": {
                  "oidc_mapping": "sub",
                  "saml_mapping": [
                    "saml_mapping"
                  ],
                  "scim_mapping": "scim_mapping"
                },
                "user_attributes": {
                  "key": {
                    "description": "description",
                    "label": "label",
                    "profile_required": true,
                    "auth0_mapping": "auth0_mapping"
                  }
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/user-attribute-profiles/templates/id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.UserAttributeProfiles.GetTemplateAsync("id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
