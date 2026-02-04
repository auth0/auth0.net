using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer;

[TestFixture]
public class VerifyTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "custom_domain_id": "custom_domain_id",
              "domain": "domain",
              "primary": true,
              "status": "pending_verification",
              "type": "auth0_managed_certs",
              "cname_api_key": "cname_api_key",
              "origin_domain_name": "origin_domain_name",
              "verification": {
                "methods": [
                  {
                    "name": "cname",
                    "record": "record"
                  }
                ],
                "status": "verified",
                "error_msg": "error_msg",
                "last_verified_at": "last_verified_at"
              },
              "custom_client_ip_header": "custom_client_ip_header",
              "tls_policy": "tls_policy",
              "domain_metadata": {
                "key": "value"
              },
              "certificate": {
                "status": "provisioning",
                "error_msg": "error_msg",
                "certificate_authority": "letsencrypt",
                "renews_before": "renews_before"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/custom-domains/id/verify")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CustomDomains.VerifyAsync("id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
