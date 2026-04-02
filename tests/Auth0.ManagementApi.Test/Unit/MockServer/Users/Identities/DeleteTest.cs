using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Users.Identities;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            [
              {
                "connection": "connection",
                "user_id": "user_id",
                "provider": "provider",
                "isSocial": true,
                "access_token": "access_token",
                "access_token_secret": "access_token_secret",
                "refresh_token": "refresh_token",
                "profileData": {
                  "email": "email",
                  "email_verified": true,
                  "name": "name",
                  "username": "username",
                  "given_name": "given_name",
                  "phone_number": "phone_number",
                  "phone_verified": true,
                  "family_name": "family_name"
                }
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/users/id/identities/ad/user_id")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Users.Identities.DeleteAsync(
            "id",
            UserIdentityProviderEnum.Ad,
            "user_id"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
