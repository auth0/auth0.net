using Auth0.ManagementApi.Organizations;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Organizations.Invitations;

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
              "invitations": [
                {
                  "id": "id",
                  "organization_id": "organization_id",
                  "inviter": {
                    "name": "name"
                  },
                  "invitee": {
                    "email": "email"
                  },
                  "invitation_url": "invitation_url",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "expires_at": "2024-01-15T09:30:00.000Z",
                  "client_id": "client_id",
                  "connection_id": "connection_id",
                  "app_metadata": {
                    "key": "value"
                  },
                  "user_metadata": {
                    "key": "value"
                  },
                  "roles": [
                    "roles"
                  ],
                  "ticket_id": "ticket_id"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/organizations/id/invitations")
                    .WithParam("page", "1")
                    .WithParam("per_page", "1")
                    .WithParam("fields", "fields")
                    .WithParam("sort", "sort")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Organizations.Invitations.ListAsync(
            "id",
            new ListOrganizationInvitationsRequestParameters
            {
                Page = 1,
                PerPage = 1,
                IncludeTotals = true,
                Fields = "fields",
                IncludeFields = true,
                Sort = "sort",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
