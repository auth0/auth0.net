using Auth0.ManagementApi;
using Auth0.ManagementApi.Flows;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Flows.Executions;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "id": "id",
              "trace_id": "trace_id",
              "journey_id": "journey_id",
              "status": "status",
              "debug": {
                "key": "value"
              },
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z",
              "started_at": "2024-01-15T09:30:00.000Z",
              "ended_at": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/flows/flow_id/executions/execution_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Flows.Executions.GetAsync(
            "flow_id",
            "execution_id",
            new GetFlowExecutionRequestParameters
            {
                Hydrate =
                [
                    new List<GetFlowExecutionRequestParametersHydrateEnum?>()
                    {
                        GetFlowExecutionRequestParametersHydrateEnum.Debug,
                    },
                ],
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
