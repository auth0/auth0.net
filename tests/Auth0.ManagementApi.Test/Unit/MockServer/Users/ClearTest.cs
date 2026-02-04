using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Users;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Users;

[TestFixture]
public class ClearTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        const string requestJson = """
            {
              "connection": "connection",
              "assessors": [
                "new-device"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/users/id/risk-assessments/clear")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Users.RiskAssessments.ClearAsync(
                "id",
                new ClearAssessorsRequestContent
                {
                    Connection = "connection",
                    Assessors = new List<string>() { "new-device" },
                }
            )
        );
    }
}
