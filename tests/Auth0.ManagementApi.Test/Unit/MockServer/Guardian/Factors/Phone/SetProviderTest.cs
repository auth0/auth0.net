using Auth0.ManagementApi;
using Auth0.ManagementApi.Guardian.Factors;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Guardian.Factors.Phone;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SetProviderTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "provider": "auth0"
            }
            """;

        const string mockResponse = """
            {
              "provider": "auth0"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/guardian/factors/phone/selected-provider")
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

        var response = await Client.Guardian.Factors.Phone.SetProviderAsync(
            new SetGuardianFactorsProviderPhoneRequestContent
            {
                Provider = GuardianFactorsProviderSmsProviderEnum.Auth0,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
