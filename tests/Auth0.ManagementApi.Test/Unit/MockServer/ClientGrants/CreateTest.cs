using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.ClientGrants;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "audience": "audience"
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
              "allow_any_organization": true,
              "default_for": "third_party_clients",
              "is_system": true,
              "subject_type": "client",
              "authorization_details_types": [
                "authorization_details_types"
              ],
              "allow_all_scopes": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/client-grants")
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

        var response = await Client.ClientGrants.CreateAsync(
            new CreateClientGrantRequestContent { Audience = "audience" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
