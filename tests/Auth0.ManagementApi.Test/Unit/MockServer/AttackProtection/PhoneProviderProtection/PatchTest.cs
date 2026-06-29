using Auth0.ManagementApi;
using Auth0.ManagementApi.AttackProtection;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.AttackProtection.PhoneProviderProtection;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PatchTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "type": "exponential"
            }
            """;

        const string mockResponse = """
            {
              "type": "exponential"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/attack-protection/phone-provider-protection")
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

        var response = await Client.AttackProtection.PhoneProviderProtection.PatchAsync(
            new PatchPhoneProviderProtectionRequestContent
            {
                Type = PhoneProviderProtectionBackoffStrategyEnum.Exponential,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
