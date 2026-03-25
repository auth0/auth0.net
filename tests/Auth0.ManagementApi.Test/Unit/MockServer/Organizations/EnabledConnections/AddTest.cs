using Auth0.ManagementApi.Organizations;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Organizations.EnabledConnections;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class AddTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "connection_id": "connection_id"
            }
            """;

        const string mockResponse = """
            {
              "connection_id": "connection_id",
              "assign_membership_on_login": true,
              "show_as_button": true,
              "is_signup_enabled": true,
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
                    .WithPath("/organizations/id/enabled_connections")
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

        var response = await Client.Organizations.EnabledConnections.AddAsync(
            "id",
            new AddOrganizationConnectionRequestContent { ConnectionId = "connection_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
