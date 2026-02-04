using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Users;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Users;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "start": 1.1,
              "limit": 1.1,
              "total": 1.1,
              "authenticators": [
                {
                  "id": "id",
                  "type": "recovery-code",
                  "confirmed": true,
                  "name": "name",
                  "authentication_methods": [
                    {}
                  ],
                  "preferred_authentication_method": "voice",
                  "link_id": "link_id",
                  "phone_number": "phone_number",
                  "email": "email",
                  "key_id": "key_id",
                  "public_key": "public_key",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "enrolled_at": "2024-01-15T09:30:00.000Z",
                  "last_auth_at": "2024-01-15T09:30:00.000Z",
                  "credential_device_type": "credential_device_type",
                  "credential_backed_up": true,
                  "identity_user_id": "identity_user_id",
                  "user_agent": "user_agent",
                  "aaguid": "aaguid",
                  "relying_party_identifier": "relying_party_identifier"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/users/id/authentication-methods")
                    .WithParam("page", "1")
                    .WithParam("per_page", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Users.AuthenticationMethods.ListAsync(
            "id",
            new ListUserAuthenticationMethodsRequestParameters
            {
                Page = 1,
                PerPage = 1,
                IncludeTotals = true,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
