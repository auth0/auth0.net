using Auth0.ManagementApi;
using Auth0.ManagementApi.Experimentation;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Experimentation.Segments;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "segments": [
                {
                  "id": "id",
                  "name": "name",
                  "description": "description",
                  "type": "self",
                  "rules": [
                    {}
                  ],
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z"
                }
              ],
              "next": "next"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/experimentation/segments")
                    .WithParam("from", "from")
                    .WithParam("take", "1")
                    .WithParam("type", "auth0")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Experimentation.Segments.ListAsync(
            new ListSegmentsRequestParameters
            {
                From = "from",
                Take = 1,
                Type = SegmentTypeFilterEnum.Auth0,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
