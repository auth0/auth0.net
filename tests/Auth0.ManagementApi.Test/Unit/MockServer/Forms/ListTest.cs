using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Forms;

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
              "forms": [
                {
                  "id": "id",
                  "name": "name",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z",
                  "embedded_at": "embedded_at",
                  "submitted_at": "submitted_at"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/forms")
                    .WithParam("page", "1")
                    .WithParam("per_page", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Forms.ListAsync(
            new ListFormsRequestParameters
            {
                Page = 1,
                PerPage = 1,
                IncludeTotals = true,
                Hydrate =
                [
                    new List<FormsRequestParametersHydrateEnum?>()
                    {
                        FormsRequestParametersHydrateEnum.FlowCount,
                    },
                ],
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
