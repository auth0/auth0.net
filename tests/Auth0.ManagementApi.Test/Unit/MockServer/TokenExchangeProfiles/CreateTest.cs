using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.TokenExchangeProfiles;

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
              "subject_token_type": "subject_token_type",
              "action_id": "action_id",
              "type": "custom_authentication"
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "subject_token_type": "subject_token_type",
              "action_id": "action_id",
              "type": "custom_authentication",
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/token-exchange-profiles")
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

        var response = await Client.TokenExchangeProfiles.CreateAsync(
            new CreateTokenExchangeProfileRequestContent
            {
                Name = "name",
                SubjectTokenType = "subject_token_type",
                ActionId = "action_id",
                Type = TokenExchangeProfileTypeEnum.CustomAuthentication,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
