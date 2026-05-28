using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.RateLimitPolicies;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "rate_limit_policies": [
                {
                  "id": "id",
                  "resource": "oauth_authentication_api",
                  "consumer": "client",
                  "consumer_selector": "consumer_selector",
                  "configuration": {
                    "action": "allow"
                  },
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z"
                }
              ],
              "next": "next"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/rate-limit-policies")
                    .WithParam("resource", "oauth_authentication_api")
                    .WithParam("consumer", "client")
                    .WithParam("consumer_selector", "consumer_selector")
                    .WithParam("take", "1")
                    .WithParam("from", "from")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.RateLimitPolicies.ListAsync(
            new ListRateLimitPoliciesRequestParameters
            {
                Resource = RateLimitPolicyResourceEnum.OauthAuthenticationApi,
                Consumer = RateLimitPolicyConsumerEnum.Client,
                ConsumerSelector = "consumer_selector",
                Take = 1,
                From = "from",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
