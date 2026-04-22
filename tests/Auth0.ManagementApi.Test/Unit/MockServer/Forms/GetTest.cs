using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Forms;

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
              "messages": {
                "errors": {
                  "key": "value"
                },
                "custom": {
                  "key": "value"
                }
              },
              "languages": {
                "primary": "primary",
                "default": "default"
              },
              "translations": {
                "key": {
                  "key": "value"
                }
              },
              "nodes": [
                {
                  "id": "id",
                  "type": "FLOW",
                  "coordinates": {
                    "x": 1,
                    "y": 1
                  },
                  "alias": "alias",
                  "config": {
                    "flow_id": "flow_id"
                  }
                }
              ],
              "start": {
                "hidden_fields": [
                  {
                    "key": "key"
                  }
                ],
                "next_node": "$ending",
                "coordinates": {
                  "x": 1,
                  "y": 1
                }
              },
              "ending": {
                "redirection": {
                  "delay": 1,
                  "target": "target"
                },
                "after_submit": {
                  "flow_id": "flow_id"
                },
                "coordinates": {
                  "x": 1,
                  "y": 1
                },
                "resume_flow": true
              },
              "style": {
                "css": "css"
              },
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z",
              "embedded_at": "embedded_at",
              "submitted_at": "submitted_at"
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/forms/id").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Forms.GetAsync(
            "id",
            new GetFormRequestParameters
            {
                Hydrate =
                [
                    new List<FormsRequestParametersHydrateEnum?>()
                    {
                        FormsRequestParametersHydrateEnum.FlowCount,
                    },
                ],
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
