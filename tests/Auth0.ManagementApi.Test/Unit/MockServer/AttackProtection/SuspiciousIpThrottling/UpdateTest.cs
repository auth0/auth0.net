using Auth0.ManagementApi.AttackProtection;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.AttackProtection.SuspiciousIpThrottling;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "enabled": true,
              "shields": [
                "block"
              ],
              "allowlist": [
                "allowlist"
              ],
              "stage": {
                "pre-login": {
                  "max_attempts": 1,
                  "rate": 1
                },
                "pre-user-registration": {
                  "max_attempts": 1,
                  "rate": 1
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/attack-protection/suspicious-ip-throttling")
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

        var response = await Client.AttackProtection.SuspiciousIpThrottling.UpdateAsync(
            new UpdateSuspiciousIpThrottlingSettingsRequestContent()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
