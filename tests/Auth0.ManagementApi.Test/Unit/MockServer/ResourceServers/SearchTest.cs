using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.ResourceServers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SearchTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
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
                  "allow_offline_access": true,
                  "allow_online_access": true,
                  "allow_online_access_with_ephemeral_sessions": true,
                  "skip_consent_for_verifiable_first_party_clients": true,
                  "token_lifetime": 1,
                  "token_lifetime_for_web": 1,
                  "enforce_policies": true,
                  "token_lifetime_for_anonymous_access_tokens": 1,
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
              ],
              "next": "next"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/resource-servers/search")
                    .WithParam("q", "q")
                    .WithParam("parser", "scim")
                    .WithParam("fields", "fields")
                    .WithParam("take", "1")
                    .WithParam("from", "from")
                    .WithParam("sort", "identifier")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.ResourceServers.SearchAsync(
            new SearchResourceServersRequestParameters
            {
                Q = "q",
                Parser = SearchParserEnum.Scim,
                Fields = "fields",
                IncludeFields = true,
                Take = 1,
                From = "from",
                Sort = ResourceServerSortFieldEnum.Identifier,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
