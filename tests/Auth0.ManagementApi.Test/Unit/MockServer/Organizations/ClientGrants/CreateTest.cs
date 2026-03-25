using Auth0.ManagementApi.Organizations;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Organizations.ClientGrants;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "grant_id": "grant_id"
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "client_id": "client_id",
              "audience": "audience",
              "scope": [
                "scope"
              ],
              "organization_usage": "deny",
              "allow_any_organization": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/organizations/id/client-grants")
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

        var response = await Client.Organizations.ClientGrants.CreateAsync(
            "id",
            new AssociateOrganizationClientGrantRequestContent { GrantId = "grant_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
