using Auth0.ManagementApi;
using Auth0.ManagementApi.Guardian;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Guardian;

[TestFixture]
public class SetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "enabled": true
            }
            """;

        const string mockResponse = """
            {
              "enabled": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/guardian/factors/push-notification")
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

        var response = await Client.Guardian.Factors.SetAsync(
            GuardianFactorNameEnum.PushNotification,
            new SetGuardianFactorRequestContent { Enabled = true }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
