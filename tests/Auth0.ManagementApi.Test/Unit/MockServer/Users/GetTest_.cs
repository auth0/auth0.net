using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Users;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Users;

[TestFixture]
public class GetTest_ : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "groups": [
                {
                  "id": "id",
                  "name": "name",
                  "external_id": "external_id",
                  "connection_id": "connection_id",
                  "organization_id": "organization_id",
                  "tenant_name": "tenant_name",
                  "description": "description",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z",
                  "membership_created_at": "2024-01-15T09:30:00.000Z"
                }
              ],
              "next": "next",
              "start": 1.1,
              "limit": 1.1,
              "total": 1.1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/users/id/groups")
                    .WithParam("fields", "fields")
                    .WithParam("from", "from")
                    .WithParam("take", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Users.Groups.GetAsync(
            "id",
            new GetUserGroupsRequestParameters
            {
                Fields = "fields",
                IncludeFields = true,
                From = "from",
                Take = 1,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
