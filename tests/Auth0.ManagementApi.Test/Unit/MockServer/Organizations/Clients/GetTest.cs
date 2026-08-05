using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Organizations.Clients;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "client_id": "client_id",
              "use_for_member_access": true,
              "client": {
                "name": "name",
                "app_type": "app_type",
                "logo_uri": "logo_uri",
                "is_first_party": true,
                "grant_types": [
                  "grant_types"
                ],
                "organization_usage": "deny"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/organizations/id/clients/client_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organizations.Clients.GetAsync("id", "client_id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
