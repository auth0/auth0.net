using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.AttackProtection;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "bot_detection_level": "low",
              "challenge_password_policy": "never",
              "challenge_passwordless_policy": "never",
              "challenge_password_reset_policy": "never",
              "allowlist": [
                "allowlist"
              ],
              "monitoring_mode_enabled": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/attack-protection/bot-detection")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.AttackProtection.BotDetection.GetAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
