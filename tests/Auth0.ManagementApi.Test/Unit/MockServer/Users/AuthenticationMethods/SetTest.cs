using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Users.AuthenticationMethods;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            [
              {
                "type": "phone"
              }
            ]
            """;

        const string mockResponse = """
            [
              {
                "id": "id",
                "type": "phone",
                "name": "name",
                "totp_secret": "totp_secret",
                "phone_number": "phone_number",
                "email": "email",
                "authentication_methods": [
                  {}
                ],
                "preferred_authentication_method": "voice",
                "key_id": "key_id",
                "public_key": "public_key",
                "aaguid": "aaguid",
                "relying_party_identifier": "relying_party_identifier",
                "created_at": "2024-01-15T09:30:00.000Z"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/users/id/authentication-methods")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Users.AuthenticationMethods.SetAsync(
            "id",
            new List<SetUserAuthenticationMethods>()
            {
                new SetUserAuthenticationMethods { Type = AuthenticationTypeEnum.Phone },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
