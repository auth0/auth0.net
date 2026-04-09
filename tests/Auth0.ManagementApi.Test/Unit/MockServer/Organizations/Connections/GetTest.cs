using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Organizations.Connections;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "organization_connection_name": "organization_connection_name",
              "assign_membership_on_login": true,
              "show_as_button": true,
              "is_signup_enabled": true,
              "organization_access_level": "none",
              "is_enabled": true,
              "connection_id": "connection_id",
              "connection": {
                "name": "name",
                "strategy": "strategy"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/organizations/id/connections/connection_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organizations.Connections.GetAsync("id", "connection_id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
