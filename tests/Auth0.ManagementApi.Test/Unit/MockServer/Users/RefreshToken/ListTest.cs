using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Users;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Users.RefreshToken;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "tokens": [
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
                    .WithPath("/users/user_id/refresh-tokens")
                    .WithParam("from", "from")
                    .WithParam("take", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Users.RefreshToken.ListAsync(
            "user_id",
            new ListRefreshTokensRequestParameters { From = "from", Take = 1 }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
