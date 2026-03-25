using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.AttackProtection.BreachedPasswordDetection;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "enabled": true,
              "shields": [
                "block"
              ],
              "admin_notification_frequency": [
                "immediately"
              ],
              "method": "standard",
              "stage": {
                "pre-user-registration": {
                  "shields": [
                    "block"
                  ]
                },
                "pre-change-password": {
                  "shields": [
                    "block"
                  ]
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/attack-protection/breached-password-detection")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.AttackProtection.BreachedPasswordDetection.GetAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
