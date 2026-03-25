using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.NetworkAcls;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "description": "description",
              "active": true,
              "priority": 1.1,
              "rule": {
                "action": {},
                "scope": "management"
              }
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "description": "description",
              "active": true,
              "priority": 1.1,
              "rule": {
                "action": {
                  "block": true,
                  "allow": true,
                  "log": true,
                  "redirect": true,
                  "redirect_uri": "redirect_uri"
                },
                "match": {
                  "asns": [
                    1
                  ],
                  "auth0_managed": [
                    "auth0_managed"
                  ],
                  "geo_country_codes": [
                    "geo_country_codes"
                  ],
                  "geo_subdivision_codes": [
                    "geo_subdivision_codes"
                  ],
                  "ipv4_cidrs": [
                    "ipv4_cidrs"
                  ],
                  "ipv6_cidrs": [
                    "ipv6_cidrs"
                  ],
                  "ja3_fingerprints": [
                    "ja3_fingerprints"
                  ],
                  "ja4_fingerprints": [
                    "ja4_fingerprints"
                  ],
                  "user_agents": [
                    "user_agents"
                  ]
                },
                "not_match": {
                  "asns": [
                    1
                  ],
                  "auth0_managed": [
                    "auth0_managed"
                  ],
                  "geo_country_codes": [
                    "geo_country_codes"
                  ],
                  "geo_subdivision_codes": [
                    "geo_subdivision_codes"
                  ],
                  "ipv4_cidrs": [
                    "ipv4_cidrs"
                  ],
                  "ipv6_cidrs": [
                    "ipv6_cidrs"
                  ],
                  "ja3_fingerprints": [
                    "ja3_fingerprints"
                  ],
                  "ja4_fingerprints": [
                    "ja4_fingerprints"
                  ],
                  "user_agents": [
                    "user_agents"
                  ]
                },
                "scope": "management"
              },
              "created_at": "created_at",
              "updated_at": "updated_at"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/network-acls/id")
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

        var response = await Client.NetworkAcls.SetAsync(
            "id",
            new SetNetworkAclRequestContent
            {
                Description = "description",
                Active = true,
                Priority = 1.1,
                Rule = new NetworkAclRule
                {
                    Action = new NetworkAclAction(),
                    Scope = NetworkAclRuleScopeEnum.Management,
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
