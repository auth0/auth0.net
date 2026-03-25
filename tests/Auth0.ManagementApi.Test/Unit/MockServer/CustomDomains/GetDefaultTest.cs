using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.CustomDomains;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetDefaultTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "custom_domain_id": "custom_domain_id",
              "domain": "domain",
              "primary": true,
              "is_default": true,
              "status": "pending_verification",
              "type": "auth0_managed_certs",
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
              },
              "relying_party_identifier": "relying_party_identifier"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/custom-domains/default")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CustomDomains.GetDefaultAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
