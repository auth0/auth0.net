using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Branding.Phone;

[TestFixture]
public class ResetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "key": "value"
            }
            """;

        const string mockResponse = """
            {
              "id": "x",
              "channel": "channel",
              "customizable": true,
              "tenant": "x",
              "content": {
                "syntax": "syntax",
                "from": "x",
                "body": {
                  "text": "x",
                  "voice": "x"
                }
              },
              "type": "otp_verify",
              "disabled": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/branding/phone/templates/id/reset")
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

        var response = await Client.Branding.Phone.Templates.ResetAsync(
            "id",
            new Dictionary<object, object?>() { { "key", "value" } }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
