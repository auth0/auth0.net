using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Prompts;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "tenant": "tenant",
              "prompt": "prompt",
              "screen": "screen",
              "rendering_mode": "advanced",
              "context_configuration": [
                "branding.settings"
              ],
              "default_head_tags_disabled": true,
              "use_page_template": true,
              "head_tags": [
                {
                  "tag": "tag",
                  "attributes": {
                    "key": "value"
                  },
                  "content": "content"
                }
              ],
              "filters": {
                "match_type": "includes_any",
                "clients": [
                  {
                    "id": "id"
                  }
                ],
                "organizations": [
                  {
                    "id": "id"
                  }
                ],
                "domains": [
                  {
                    "id": "id"
                  }
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/prompts/login/screen/login/rendering")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Prompts.Rendering.GetAsync(
            PromptGroupNameEnum.Login,
            ScreenGroupNameEnum.Login
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
