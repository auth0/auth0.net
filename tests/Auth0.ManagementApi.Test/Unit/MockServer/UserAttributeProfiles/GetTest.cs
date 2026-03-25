using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.UserAttributeProfiles;

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
                  "auth0_mapping": "auth0_mapping",
                  "oidc_mapping": {
                    "mapping": "mapping"
                  },
                  "saml_mapping": [
                    "saml_mapping"
                  ],
                  "scim_mapping": "scim_mapping"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/user-attribute-profiles/id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.UserAttributeProfiles.GetAsync("id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
