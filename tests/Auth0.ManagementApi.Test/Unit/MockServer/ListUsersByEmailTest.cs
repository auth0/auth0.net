using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer;

[TestFixture]
public class ListUsersByEmailTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            [
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/users-by-email")
                    .WithParam("fields", "fields")
                    .WithParam("email", "email")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Users.ListUsersByEmailAsync(
            new ListUsersByEmailRequestParameters
            {
                Fields = "fields",
                IncludeFields = true,
                Email = "email",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
