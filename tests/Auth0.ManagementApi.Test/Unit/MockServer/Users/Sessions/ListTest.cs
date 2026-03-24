using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Users;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Users.Sessions;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "sessions": [
                {
                  "id": "id",
                  "user_id": "user_id",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z",
                  "authenticated_at": "2024-01-15T09:30:00.000Z",
                  "idle_expires_at": "2024-01-15T09:30:00.000Z",
                  "expires_at": "2024-01-15T09:30:00.000Z",
                  "last_interacted_at": "2024-01-15T09:30:00.000Z",
                  "clients": [
                    {}
                  ],
                  "session_metadata": {
                    "key": "value"
                  }
                }
              ],
              "next": "next"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/users/user_id/sessions")
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

        var items = await Client.Users.Sessions.ListAsync(
            "user_id",
            new ListUserSessionsRequestParameters { From = "from", Take = 1 }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
