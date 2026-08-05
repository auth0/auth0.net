using Auth0.ManagementApi;
using Auth0.ManagementApi.Organizations;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Organizations.Clients;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "clients": [
                {
                  "client_id": "client_id",
                  "use_for_member_access": true
                }
              ]
            }
            """;

        const string mockResponse = """
            [
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
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/organizations/id/clients")
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

        var response = await Client.Organizations.Clients.CreateAsync(
            "id",
            new CreateOrganizationClientsRequestContent
            {
                Clients = new List<CreateOrganizationClientRequestItem>()
                {
                    new CreateOrganizationClientRequestItem
                    {
                        ClientId = "client_id",
                        UseForMemberAccess = true,
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
