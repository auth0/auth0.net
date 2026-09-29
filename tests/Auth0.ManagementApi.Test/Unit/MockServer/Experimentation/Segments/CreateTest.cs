using Auth0.ManagementApi;
using Auth0.ManagementApi.Experimentation;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Experimentation.Segments;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "name": "name",
              "rules": [
                {}
              ]
            }
            """;

        const string mockResponse = """
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/experimentation/segments")
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

        var response = await Client.Experimentation.Segments.CreateAsync(
            new CreateSegmentRequestContent
            {
                Name = "name",
                Rules = new List<SegmentRule>() { new SegmentRule() },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
