using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Guardian.Factors.PushNotification;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetApnsProviderTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "bundle_id": "bundle_id",
              "sandbox": true,
              "enabled": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/guardian/factors/push-notification/providers/apns")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Guardian.Factors.PushNotification.GetApnsProviderAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
