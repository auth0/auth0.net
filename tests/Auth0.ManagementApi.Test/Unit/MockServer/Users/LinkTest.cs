using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using Auth0.ManagementApi.Users;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Users;

[TestFixture]
public class LinkTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            [
              {
                "connection": "connection",
                "user_id": "user_id",
                "provider": "provider",
                "profileData": {
                  "email": "email",
                  "email_verified": true,
                  "name": "name",
                  "username": "username",
                  "given_name": "given_name",
                  "phone_number": "phone_number",
                  "phone_verified": true,
                  "family_name": "family_name"
                },
                "isSocial": true,
                "access_token": "access_token",
                "access_token_secret": "access_token_secret",
                "refresh_token": "refresh_token"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/users/id/identities")
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

        var response = await Client.Users.Identities.LinkAsync(
            "id",
            new LinkUserIdentityRequestContent()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
