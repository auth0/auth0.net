using Auth0.ManagementApi.Guardian.Factors;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Guardian.Factors.Sms;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SetTwilioProviderTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "from": "from",
              "messaging_service_sid": "messaging_service_sid",
              "auth_token": "auth_token",
              "sid": "sid"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/guardian/factors/sms/providers/twilio")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Guardian.Factors.Sms.SetTwilioProviderAsync(
            new SetGuardianFactorsProviderSmsTwilioRequestContent()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
