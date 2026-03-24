using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Hooks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "start": 1.1,
              "limit": 1.1,
              "total": 1.1,
              "hooks": [
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
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/hooks")
                    .WithParam("page", "1")
                    .WithParam("per_page", "1")
                    .WithParam("fields", "fields")
                    .WithParam("triggerId", "credentials-exchange")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Hooks.ListAsync(
            new ListHooksRequestParameters
            {
                Page = 1,
                PerPage = 1,
                IncludeTotals = true,
                Enabled = true,
                Fields = "fields",
                TriggerId = HookTriggerIdEnum.CredentialsExchange,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
