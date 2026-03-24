using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Logs;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "date": "date",
              "type": "type",
              "description": "description",
              "connection": "connection",
              "connection_id": "connection_id",
              "client_id": "client_id",
              "client_name": "client_name",
              "ip": "ip",
              "hostname": "hostname",
              "user_id": "user_id",
              "user_name": "user_name",
              "audience": "audience",
              "scope": "scope",
              "strategy": "strategy",
              "strategy_type": "strategy_type",
              "log_id": "log_id",
              "isMobile": true,
              "details": {
                "key": "value"
              },
              "user_agent": "user_agent",
              "security_context": {
                "ja3": "ja3",
                "ja4": "ja4"
              },
              "location_info": {
                "country_code": "country_code",
                "country_code3": "country_code3",
                "country_name": "country_name",
                "city_name": "city_name",
                "latitude": 1.1,
                "longitude": 1.1,
                "time_zone": "time_zone",
                "continent_code": "continent_code"
              }
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/logs/id").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Logs.GetAsync("id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
