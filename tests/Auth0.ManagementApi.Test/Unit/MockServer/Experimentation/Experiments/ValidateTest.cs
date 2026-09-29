using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Experimentation.Experiments;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ValidateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "is_valid": true,
              "errors": [
                {
                  "code": "code",
                  "message": "message"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/experimentation/experiments/id/validate")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Experimentation.Experiments.ValidateAsync("id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
