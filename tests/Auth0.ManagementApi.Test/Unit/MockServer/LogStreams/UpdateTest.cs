using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.LogStreams;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "status": "active",
              "type": "http",
              "isPriority": true,
              "filters": [
                {
                  "type": "category",
                  "name": "auth.login.fail"
                }
              ],
              "pii_config": {
                "log_fields": [
                  "first_name"
                ],
                "method": "mask",
                "algorithm": "xxhash"
              },
              "sink": {
                "httpAuthorization": "httpAuthorization",
                "httpContentFormat": "JSONARRAY",
                "httpContentType": "httpContentType",
                "httpEndpoint": "httpEndpoint",
                "httpCustomHeaders": [
                  {}
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/log-streams/id")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.LogStreams.UpdateAsync(
            "id",
            new UpdateLogStreamRequestContent()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
