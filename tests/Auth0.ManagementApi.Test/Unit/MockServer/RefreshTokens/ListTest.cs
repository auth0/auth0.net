using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.RefreshTokens;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "refresh_tokens": [
                {
                  "id": "id",
                  "user_id": "user_id",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "idle_expires_at": "2024-01-15T09:30:00.000Z",
                  "expires_at": "2024-01-15T09:30:00.000Z",
                  "client_id": "client_id",
                  "session_id": "session_id",
                  "rotating": true,
                  "resource_servers": [
                    {}
                  ],
                  "refresh_token_metadata": {
                    "key": "value"
                  },
                  "last_exchanged_at": "2024-01-15T09:30:00.000Z"
                }
              ],
              "next": "next"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/refresh-tokens")
                    .WithParam("user_id", "user_id")
                    .WithParam("client_id", "client_id")
                    .WithParam("from", "from")
                    .WithParam("take", "1")
                    .WithParam("fields", "fields")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.RefreshTokens.ListAsync(
            new GetRefreshTokensRequestParameters
            {
                UserId = "user_id",
                ClientId = "client_id",
                From = "from",
                Take = 1,
                Fields = "fields",
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
