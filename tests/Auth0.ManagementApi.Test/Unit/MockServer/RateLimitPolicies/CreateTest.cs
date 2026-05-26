using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.RateLimitPolicies;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "resource": "oauth_authentication_api",
              "consumer": "client",
              "consumer_selector": "consumer_selector",
              "configuration": {
                "action": "allow"
              }
            }
            """;

        const string mockResponse = """
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/rate-limit-policies")
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

        var response = await Client.RateLimitPolicies.CreateAsync(
            new CreateRateLimitPolicyRequestContent
            {
                Resource = RateLimitPolicyResourceEnum.OauthAuthenticationApi,
                Consumer = RateLimitPolicyConsumerEnum.Client,
                ConsumerSelector = "consumer_selector",
                Configuration = new RateLimitPolicyConfigurationZero
                {
                    Action = RateLimitPolicyConfigurationZeroAction.Allow,
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
