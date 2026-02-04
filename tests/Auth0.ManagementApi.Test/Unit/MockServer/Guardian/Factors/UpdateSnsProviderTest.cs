using Auth0.ManagementApi.Guardian.Factors;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Guardian.Factors;

[TestFixture]
public class UpdateSnsProviderTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "aws_access_key_id": "aws_access_key_id",
              "aws_secret_access_key": "aws_secret_access_key",
              "aws_region": "aws_region",
              "sns_apns_platform_application_arn": "sns_apns_platform_application_arn",
              "sns_gcm_platform_application_arn": "sns_gcm_platform_application_arn"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/guardian/factors/push-notification/providers/sns")
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

        var response = await Client.Guardian.Factors.PushNotification.UpdateSnsProviderAsync(
            new UpdateGuardianFactorsProviderPushNotificationSnsRequestContent()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
