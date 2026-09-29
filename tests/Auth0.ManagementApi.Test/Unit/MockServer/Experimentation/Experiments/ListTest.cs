using Auth0.ManagementApi;
using Auth0.ManagementApi.Experimentation;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Experimentation.Experiments;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "experiments": [
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
                    {}
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
              ],
              "next": "next"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/experimentation/experiments")
                    .WithParam("from", "from")
                    .WithParam("take", "1")
                    .WithParam("status", "draft")
                    .WithParam("authentication_flow", "authentication_flow")
                    .WithParam("feature_flag_id", "feature_flag_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Experimentation.Experiments.ListAsync(
            new ListExperimentsRequestParameters
            {
                From = "from",
                Take = 1,
                Status = ExperimentStatusEnum.Draft,
                AuthenticationFlow = "authentication_flow",
                FeatureFlagId = "feature_flag_id",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
