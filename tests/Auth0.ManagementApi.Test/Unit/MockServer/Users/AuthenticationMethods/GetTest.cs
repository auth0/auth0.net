using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Users.AuthenticationMethods;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "id": "id",
              "type": "recovery-code",
              "confirmed": true,
              "name": "name",
              "authentication_methods": [
                {
                  "type": "totp",
                  "id": "id"
                }
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/users/id/authentication-methods/authentication_method_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Users.AuthenticationMethods.GetAsync(
            "id",
            "authentication_method_id"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
