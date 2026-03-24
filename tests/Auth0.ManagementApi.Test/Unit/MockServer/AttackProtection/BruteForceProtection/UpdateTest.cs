using Auth0.ManagementApi.AttackProtection;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.AttackProtection.BruteForceProtection;

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
              "mode": "count_per_identifier_and_ip",
              "max_attempts": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/attack-protection/brute-force-protection")
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

        var response = await Client.AttackProtection.BruteForceProtection.UpdateAsync(
            new UpdateBruteForceSettingsRequestContent()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
