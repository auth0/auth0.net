using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Hooks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "name": "name",
              "script": "script",
              "triggerId": "credentials-exchange"
            }
            """;

        const string mockResponse = """
            {
              "triggerId": "triggerId",
              "id": "id",
              "name": "name",
              "enabled": true,
              "script": "script",
              "dependencies": {
                "key": "value"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/hooks")
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

        var response = await Client.Hooks.CreateAsync(
            new CreateHookRequestContent
            {
                Name = "name",
                Script = "script",
                TriggerId = HookTriggerIdEnum.CredentialsExchange,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
