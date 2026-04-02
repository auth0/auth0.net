using Auth0.ManagementApi;
using Auth0.ManagementApi.Prompts;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Prompts.Rendering;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "configs": [
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
                    {}
                  ]
                }
              ],
              "start": 1.1,
              "limit": 1.1,
              "total": 1.1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/prompts/rendering")
                    .WithParam("fields", "fields")
                    .WithParam("page", "1")
                    .WithParam("per_page", "1")
                    .WithParam("prompt", "prompt")
                    .WithParam("screen", "screen")
                    .WithParam("rendering_mode", "advanced")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Prompts.Rendering.ListAsync(
            new ListAculsRequestParameters
            {
                Fields = "fields",
                IncludeFields = true,
                Page = 1,
                PerPage = 1,
                IncludeTotals = true,
                Prompt = "prompt",
                Screen = "screen",
                RenderingMode = AculRenderingModeEnum.Advanced,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
