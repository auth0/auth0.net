using Auth0.ManagementApi;
using Auth0.ManagementApi.Experimentation;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Experimentation.Experiments;

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
              "feature_flag_id": "feature_flag_id",
              "authentication_flow": "authentication"
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "description": "description",
              "feature_flag_id": "feature_flag_id",
              "feature_flag_name": "feature_flag_name",
              "authentication_flow": "authentication_flow",
              "allocation_strategy": "percentage",
              "status": "draft",
              "is_valid": true,
              "default_config": "tenant",
              "feature_flag_snapshot": {
                "key": "value"
              },
              "allocations": [
                {
                  "variation_id": "variation_id",
                  "variation_name": "variation_name",
                  "segment_id": "segment_id",
                  "segment_name": "segment_name",
                  "weight": 1,
                  "priority": 1,
                  "is_control": true,
                  "is_fallback": true,
                  "variation_snapshot": {
                    "key": "value"
                  },
                  "segment_snapshot": {
                    "key": "value"
                  }
                }
              ],
              "editable_fields": [
                "editable_fields"
              ],
              "levels": [
                1
              ],
              "current_level": 1,
              "started_at": "2024-01-15T09:30:00.000Z",
              "ended_at": "2024-01-15T09:30:00.000Z",
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/experimentation/experiments")
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

        var response = await Client.Experimentation.Experiments.CreateAsync(
            new CreateExperimentRequestContent
            {
                Name = "name",
                FeatureFlagId = "feature_flag_id",
                AuthenticationFlow = AuthenticationFlowEnum.Authentication,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
