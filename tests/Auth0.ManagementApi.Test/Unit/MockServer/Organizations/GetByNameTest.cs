using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Organizations;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetByNameTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "display_name": "display_name",
              "branding": {
                "logo_url": "logo_url",
                "colors": {
                  "primary": "primary",
                  "page_background": "page_background"
                }
              },
              "metadata": {
                "key": "value"
              },
              "token_quota": {
                "client_credentials": {
                  "enforce": true,
                  "per_day": 1,
                  "per_hour": 1
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/organizations/name/name")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organizations.GetByNameAsync("name");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
