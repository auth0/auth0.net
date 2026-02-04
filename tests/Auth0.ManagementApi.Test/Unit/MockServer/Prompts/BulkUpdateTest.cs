using Auth0.ManagementApi;
using Auth0.ManagementApi.Prompts;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Prompts;

[TestFixture]
public class BulkUpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "configs": [
                {
                  "prompt": "login",
                  "screen": "login"
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "configs": [
                {
                  "prompt": "login",
                  "screen": "login",
                  "rendering_mode": "advanced",
                  "context_configuration": [
                    "branding.settings"
                  ],
                  "default_head_tags_disabled": true,
                  "use_page_template": true,
                  "head_tags": [
                    {}
                  ]
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/prompts/rendering")
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

        var response = await Client.Prompts.Rendering.BulkUpdateAsync(
            new BulkUpdateAculRequestContent
            {
                Configs = new List<AculConfigsItem>()
                {
                    new AculConfigsItem
                    {
                        Prompt = PromptGroupNameEnum.Login,
                        Screen = ScreenGroupNameEnum.Login,
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
