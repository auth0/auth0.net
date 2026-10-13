using Auth0.ManagementApi;
using Auth0.ManagementApi.AttackProtection;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.AttackProtection.CaptchaPolicies;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "name": "name",
              "priority": 1,
              "match": {},
              "action": {}
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "description": "description",
              "priority": 1,
              "match": {
                "auth0_managed": [
                  "auth0_managed"
                ],
                "geo_country_codes": [
                  "geo_country_codes"
                ]
              },
              "action": {
                "active_provider_id": "simple_captcha",
                "auth_challenge": {
                  "fail_open": true
                },
                "recaptcha_v2": {
                  "site_key": "site_key"
                },
                "recaptcha_enterprise": {
                  "site_key": "site_key",
                  "project_id": "project_id"
                },
                "hcaptcha": {
                  "site_key": "site_key"
                },
                "friendly_captcha": {
                  "site_key": "site_key"
                },
                "arkose": {
                  "site_key": "site_key",
                  "client_subdomain": "client_subdomain",
                  "verify_subdomain": "verify_subdomain",
                  "fail_open": true
                }
              },
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/attack-protection/captcha/policies")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.AttackProtection.CaptchaPolicies.CreateAsync(
            new CreateAttackProtectionCaptchaPolicyRequestContent
            {
                Name = "name",
                Priority = 1,
                Match = new AttackProtectionCaptchaPolicyMatch(),
                Action = new AttackProtectionCaptchaPolicyActionInput(),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
