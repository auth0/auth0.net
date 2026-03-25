using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.LogStreams;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "type": "http",
              "sink": {
                "httpEndpoint": "httpEndpoint"
              }
            }
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
                    .WithPath("/log-streams")
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

        var response = await Client.LogStreams.CreateAsync(
            new CreateLogStreamHttpRequestBody
            {
                Type = LogStreamHttpEnum.Http,
                Sink = new LogStreamHttpSink { HttpEndpoint = "httpEndpoint" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
