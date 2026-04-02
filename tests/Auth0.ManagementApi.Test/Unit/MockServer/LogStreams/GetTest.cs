using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.LogStreams;

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
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/log-streams/id").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.LogStreams.GetAsync("id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
