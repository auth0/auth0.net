using Auth0.ManagementApi.RiskAssessments.Settings;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.RiskAssessments.Settings;

[TestFixture]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "remember_for": 1
            }
            """;

        const string mockResponse = """
            {
              "remember_for": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/risk-assessments/settings/new-device")
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

        var response = await Client.RiskAssessments.Settings.NewDevice.UpdateAsync(
            new UpdateRiskAssessmentsSettingsNewDeviceRequestContent { RememberFor = 1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
