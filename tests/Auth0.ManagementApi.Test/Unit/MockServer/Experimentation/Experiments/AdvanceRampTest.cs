using Auth0.ManagementApi.Experimentation;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Experimentation.Experiments;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class AdvanceRampTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "target_level": 1
            }
            """;

        const string mockResponse = """
            {
              "experiment_id": "experiment_id",
              "from_level": 1,
              "to_level": 1,
              "current_level": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/experimentation/experiments/id/advance-ramp")
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

        var response = await Client.Experimentation.Experiments.AdvanceRampAsync(
            "id",
            new AdvanceRampRequestContent { TargetLevel = 1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
