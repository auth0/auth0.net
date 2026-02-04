using Auth0.ManagementApi;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer;

[TestFixture]
public class ListTest_ : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "start": 1.1,
              "limit": 1.1,
              "length": 1.1,
              "total": 1.1,
              "users": [
                {
                  "user_id": "user_id",
                  "email": "email",
                  "email_verified": true,
                  "username": "username",
                  "phone_number": "phone_number",
                  "phone_verified": true,
                  "created_at": "created_at",
                  "updated_at": "updated_at",
                  "identities": [
                    {}
                  ],
                  "app_metadata": {
                    "key": "value"
                  },
                  "user_metadata": {
                    "key": "value"
                  },
                  "picture": "picture",
                  "name": "name",
                  "nickname": "nickname",
                  "multifactor": [
                    "multifactor"
                  ],
                  "last_ip": "last_ip",
                  "last_login": "last_login",
                  "logins_count": 1,
                  "blocked": true,
                  "given_name": "given_name",
                  "family_name": "family_name"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/users")
                    .WithParam("page", "1")
                    .WithParam("per_page", "1")
                    .WithParam("sort", "sort")
                    .WithParam("connection", "connection")
                    .WithParam("fields", "fields")
                    .WithParam("q", "q")
                    .WithParam("search_engine", "v1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Users.ListAsync(
            new ListUsersRequestParameters
            {
                Page = 1,
                PerPage = 1,
                IncludeTotals = true,
                Sort = "sort",
                Connection = "connection",
                Fields = "fields",
                IncludeFields = true,
                Q = "q",
                SearchEngine = SearchEngineVersionsEnum.V1,
                PrimaryOrder = true,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
