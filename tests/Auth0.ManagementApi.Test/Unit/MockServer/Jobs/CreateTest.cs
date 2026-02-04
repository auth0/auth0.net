using Auth0.ManagementApi.Jobs;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Jobs;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "status": "status",
              "type": "type",
              "created_at": "created_at",
              "id": "id",
              "connection_id": "connection_id",
              "format": "json",
              "limit": 1,
              "fields": [
                {
                  "name": "name",
                  "export_as": "export_as"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/jobs/users-exports")
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

        var response = await Client.Jobs.UsersExports.CreateAsync(
            new CreateExportUsersRequestContent()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
