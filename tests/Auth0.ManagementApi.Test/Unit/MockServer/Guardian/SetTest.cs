using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Guardian;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "display_remember_me_checkbox": true,
              "remember_me_default_value": true,
              "mfa_session_inactivity_timeout": 1,
              "mfa_session_overall_timeout": 1
            }
            """;

        const string mockResponse = """
            {
              "display_remember_me_checkbox": true,
              "remember_me_default_value": true,
              "mfa_session_inactivity_timeout": 1,
              "mfa_session_overall_timeout": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/guardian/settings")
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

        var response = await Client.Guardian.SetAsync(
            new SetGuardianSettingsRequestContent
            {
                DisplayRememberMeCheckbox = true,
                RememberMeDefaultValue = true,
                MfaSessionInactivityTimeout = 1,
                MfaSessionOverallTimeout = 1,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
