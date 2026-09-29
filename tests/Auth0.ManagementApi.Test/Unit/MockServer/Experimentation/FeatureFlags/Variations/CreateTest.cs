using Auth0.ManagementApi.Experimentation.FeatureFlags;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Experimentation.FeatureFlags.Variations;

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
              "overrides": {
                "key": "value"
              }
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "feature_flag_id": "feature_flag_id",
              "name": "name",
              "description": "description",
              "overrides": {
                "key": "value"
              },
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/experimentation/feature-flags/id/variations")
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

        var response = await Client.Experimentation.FeatureFlags.Variations.CreateAsync(
            "id",
            new CreateVariationRequestContent
            {
                Name = "name",
                Overrides = new Dictionary<string, object?>() { { "key", "value" } },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
