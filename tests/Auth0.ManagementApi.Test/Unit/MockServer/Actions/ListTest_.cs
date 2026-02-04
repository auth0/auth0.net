using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Actions;

[TestFixture]
public class ListTest_ : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "triggers": [
                {
                  "id": "id",
                  "version": "version",
                  "status": "status",
                  "runtimes": [
                    "runtimes"
                  ],
                  "default_runtime": "default_runtime",
                  "compatible_triggers": [
                    {
                      "id": "id",
                      "version": "version"
                    }
                  ],
                  "binding_policy": "trigger-bound"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/actions/triggers").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Actions.Triggers.ListAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
