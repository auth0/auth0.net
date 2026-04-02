using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Users;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
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
                {
                  "connection": "connection",
                  "user_id": "user_id",
                  "provider": "ad",
                  "isSocial": true,
                  "access_token": "access_token",
                  "access_token_secret": "access_token_secret",
                  "refresh_token": "refresh_token"
                }
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/users/id")
                    .WithParam("fields", "fields")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Users.GetAsync(
            "id",
            new GetUserRequestParameters { Fields = "fields", IncludeFields = true }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
