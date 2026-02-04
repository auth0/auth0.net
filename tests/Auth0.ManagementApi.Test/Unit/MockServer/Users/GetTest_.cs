using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Users;

[TestFixture]
public class GetTest_ : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            [
              {
                "id": "id",
                "status": "pending",
                "type": "type",
                "name": "name",
                "identifier": "identifier",
                "phone_number": "phone_number",
                "auth_method": "authenticator",
                "enrolled_at": "2024-01-15T09:30:00.000Z",
                "last_auth": "2024-01-15T09:30:00.000Z"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/users/id/enrollments")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Users.Enrollments.GetAsync("id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
