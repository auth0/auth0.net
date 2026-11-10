using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Portals;

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
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/portals/id").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Portals.GetAsync("id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
