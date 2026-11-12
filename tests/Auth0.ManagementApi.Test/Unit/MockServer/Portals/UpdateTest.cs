using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Portals;

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
              "navigation": {
                "sidebar": {
                  "components": [
                    {
                      "type": "sidebar:component:auth0:external_link",
                      "config": {
                        "label": "label",
                        "url": "url"
                      }
                    }
                  ]
                }
              },
              "pages": {
                "default": "default",
                "standard": [
                  {
                    "title": "title",
                    "slug": "slug"
                  }
                ]
              },
              "slug": "slug",
              "client": {
                "token_endpoint_auth_method": "client_secret_post",
                "client_id": "client_id"
              },
              "custom_code": {
                "head": "head"
              },
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/portals/id")
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

        var response = await Client.Portals.UpdateAsync("id", new UpdatePortalRequestContent());
        JsonAssert.AreEqual(response, mockResponse);
    }
}
