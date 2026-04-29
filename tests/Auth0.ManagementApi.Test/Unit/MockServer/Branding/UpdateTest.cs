using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Branding;

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
              "colors": {
                "primary": "primary",
                "page_background": "page_background"
              },
              "favicon_url": "favicon_url",
              "logo_url": "logo_url",
              "identifiers": {
                "login_display": "unified",
                "otp_autocomplete": true,
                "phone_display": {
                  "masking": "show_all",
                  "formatting": "regional"
                }
              },
              "font": {
                "url": "url"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/branding")
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

        var response = await Client.Branding.UpdateAsync(new UpdateBrandingRequestContent());
        JsonAssert.AreEqual(response, mockResponse);
    }
}
