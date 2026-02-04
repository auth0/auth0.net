using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Branding.Phone;

[TestFixture]
public class GetTest_ : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "id": "id",
              "channel": "channel",
              "customizable": true,
              "tenant": "tenant",
              "content": {
                "syntax": "syntax",
                "from": "from",
                "body": {
                  "text": "text",
                  "voice": "voice"
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
                    .WithPath("/branding/phone/templates/id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Branding.Phone.Templates.GetAsync("id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
