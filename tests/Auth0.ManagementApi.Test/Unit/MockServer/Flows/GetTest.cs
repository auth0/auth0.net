using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Flows;

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
              "name": "name",
              "actions": [
                {
                  "id": "id",
                  "alias": "alias",
                  "type": "ACTIVECAMPAIGN",
                  "action": "LIST_CONTACTS",
                  "allow_failure": true,
                  "mask_output": true,
                  "params": {
                    "connection_id": "connection_id",
                    "email": "email"
                  }
                }
              ],
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z",
              "executed_at": "executed_at"
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/flows/id").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Flows.GetAsync(
            "id",
            new GetFlowRequestParameters
            {
                Hydrate =
                [
                    new List<GetFlowRequestParametersHydrateEnum?>()
                    {
                        GetFlowRequestParametersHydrateEnum.FormCount,
                    },
                ],
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
