using Auth0.ManagementApi;
using Auth0.ManagementApi.Guardian.Factors;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Guardian.Factors.Phone;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SetMessageTypesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "message_types": [
                "sms"
              ]
            }
            """;

        const string mockResponse = """
            {
              "message_types": [
                "sms"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/guardian/factors/phone/message-types")
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

        var response = await Client.Guardian.Factors.Phone.SetMessageTypesAsync(
            new SetGuardianFactorPhoneMessageTypesRequestContent
            {
                MessageTypes = new List<GuardianFactorPhoneFactorMessageTypeEnum>()
                {
                    GuardianFactorPhoneFactorMessageTypeEnum.Sms,
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
