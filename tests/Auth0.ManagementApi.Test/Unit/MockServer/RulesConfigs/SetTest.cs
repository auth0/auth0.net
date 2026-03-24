using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.RulesConfigs;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "value": "value"
            }
            """;

        const string mockResponse = """
            {
              "key": "key",
              "value": "value"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/rules-configs/key")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.RulesConfigs.SetAsync(
            "key",
            new SetRulesConfigRequestContent { Value = "value" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
