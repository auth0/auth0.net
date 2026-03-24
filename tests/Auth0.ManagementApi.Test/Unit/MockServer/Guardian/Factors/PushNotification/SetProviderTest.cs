using Auth0.ManagementApi;
using Auth0.ManagementApi.Guardian.Factors;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Guardian.Factors.PushNotification;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SetProviderTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "provider": "guardian"
            }
            """;

        const string mockResponse = """
            {
              "provider": "guardian"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/guardian/factors/push-notification/selected-provider")
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

        var response = await Client.Guardian.Factors.PushNotification.SetProviderAsync(
            new SetGuardianFactorsProviderPushNotificationRequestContent
            {
                Provider = GuardianFactorsProviderPushNotificationProviderDataEnum.Guardian,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
