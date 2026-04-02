using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.SupplementalSignals;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PatchTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "akamai_enabled": true
            }
            """;

        const string mockResponse = """
            {
              "akamai_enabled": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/supplemental-signals")
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

        var response = await Client.SupplementalSignals.PatchAsync(
            new UpdateSupplementalSignalsRequestContent { AkamaiEnabled = true }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
