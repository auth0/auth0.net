using Auth0.ManagementApi.Guardian.Factors;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Guardian.Factors.PushNotification;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SetApnsProviderTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "sandbox": true,
              "bundle_id": "bundle_id"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/guardian/factors/push-notification/providers/apns")
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

        var response = await Client.Guardian.Factors.PushNotification.SetApnsProviderAsync(
            new SetGuardianFactorsProviderPushNotificationApnsRequestContent()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
