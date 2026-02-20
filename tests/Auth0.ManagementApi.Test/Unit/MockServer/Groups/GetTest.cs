using Auth0.ManagementApi.Groups;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Groups;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "members": [
                {
                  "id": "id",
                  "member_type": "user",
                  "type": "connection",
                  "connection_id": "connection_id",
                  "created_at": "2024-01-15T09:30:00.000Z"
                }
              ],
              "next": "next"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/groups/id/members")
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

        var items = await Client.Groups.Members.GetAsync(
            "id",
            new GetGroupMembersRequestParameters
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
