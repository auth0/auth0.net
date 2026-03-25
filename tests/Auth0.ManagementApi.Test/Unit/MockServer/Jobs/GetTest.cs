using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Jobs;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "status": "status",
              "type": "type",
              "created_at": "created_at",
              "id": "id",
              "connection_id": "connection_id",
              "location": "location",
              "percentage_done": 1,
              "time_left_seconds": 1,
              "format": "json",
              "status_details": "status_details",
              "summary": {
                "failed": 1,
                "updated": 1,
                "inserted": 1,
                "total": 1
              }
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/jobs/id").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Jobs.GetAsync("id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
