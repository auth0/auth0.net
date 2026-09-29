using Auth0.ManagementApi;
using Auth0.ManagementApi.Experimentation;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Experimentation.FeatureFlags;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateStatusTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "status": "draft"
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "description": "description",
              "type": "auth0",
              "status": "draft",
              "parameters": {
                "key": {
                  "type": "string",
                  "value": {
                    "key": "value"
                  },
                  "description": "description"
                }
              },
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/experimentation/feature-flags/id/status")
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

        var response = await Client.Experimentation.FeatureFlags.UpdateStatusAsync(
            "id",
            new UpdateFeatureFlagStatusRequestContent { Status = FeatureFlagStatusEnum.Draft }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
