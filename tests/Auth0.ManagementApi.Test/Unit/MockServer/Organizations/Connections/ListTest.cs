using Auth0.ManagementApi.Organizations;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Organizations.Connections;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
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
              "connections": [
                {
                  "organization_connection_name": "organization_connection_name",
                  "assign_membership_on_login": true,
                  "show_as_button": true,
                  "is_signup_enabled": true,
                  "organization_access_level": "none",
                  "is_enabled": true,
                  "connection_id": "connection_id"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/organizations/id/connections")
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

        var items = await Client.Organizations.Connections.ListAsync(
            "id",
            new ListOrganizationAllConnectionsRequestParameters
            {
                Page = 1,
                PerPage = 1,
                IncludeTotals = true,
                IsEnabled = true,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
