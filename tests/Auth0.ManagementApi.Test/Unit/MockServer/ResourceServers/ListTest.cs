using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.ResourceServers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "start": 1.1,
              "limit": 1.1,
              "total": 1.1,
              "resource_servers": [
                {
                  "id": "id",
                  "name": "name",
                  "is_system": true,
                  "identifier": "identifier",
                  "scopes": [
                    {
                      "value": "value"
                    }
                  ],
                  "signing_alg": "HS256",
                  "signing_secret": "signing_secret",
                  "allow_offline_access": true,
                  "allow_online_access": true,
                  "skip_consent_for_verifiable_first_party_clients": true,
                  "token_lifetime": 1,
                  "token_lifetime_for_web": 1,
                  "enforce_policies": true,
                  "token_dialect": "access_token",
                  "token_encryption": {
                    "format": "compact-nested-jwe",
                    "encryption_key": {
                      "alg": "RSA-OAEP-256",
                      "pem": "pem"
                    }
                  },
                  "consent_policy": "transactional-authorization-with-mfa",
                  "proof_of_possession": {
                    "mechanism": "mtls",
                    "required": true
                  },
                  "authorization_policy": {
                    "policy_id": "policy_id"
                  },
                  "client_id": "client_id"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/resource-servers")
                    .WithParam("page", "1")
                    .WithParam("per_page", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.ResourceServers.ListAsync(
            new ListResourceServerRequestParameters
            {
                Identifiers = [new List<string?>() { "identifiers" }],
                Page = 1,
                PerPage = 1,
                IncludeTotals = true,
                IncludeFields = true,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
