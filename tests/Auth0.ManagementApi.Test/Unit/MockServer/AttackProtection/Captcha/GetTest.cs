using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.AttackProtection.Captcha;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "active_provider_id": "active_provider_id",
              "arkose": {
                "site_key": "site_key",
                "fail_open": true,
                "client_subdomain": "client_subdomain",
                "verify_subdomain": "verify_subdomain"
              },
              "auth_challenge": {
                "fail_open": true
              },
              "hcaptcha": {
                "site_key": "site_key"
              },
              "friendly_captcha": {
                "site_key": "site_key"
              },
              "recaptcha_enterprise": {
                "site_key": "site_key",
                "project_id": "project_id"
              },
              "recaptcha_v2": {
                "site_key": "site_key"
              },
              "simple_captcha": {
                "key": "value"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/attack-protection/captcha")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.AttackProtection.Captcha.GetAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
