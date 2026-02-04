using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer;

[TestFixture]
public class GetDailyTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            [
              {
                "date": "date",
                "logins": 1,
                "signups": 1,
                "leaked_passwords": 1,
                "updated_at": "updated_at",
                "created_at": "created_at"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/stats/daily")
                    .WithParam("from", "from")
                    .WithParam("to", "to")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Stats.GetDailyAsync(
            new GetDailyStatsRequestParameters { From = "from", To = "to" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
