using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.ClientGrants;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "next": "next",
              "client_grants": [
                {
                  "id": "id",
                  "client_id": "client_id",
                  "audience": "audience",
                  "scope": [
                    "scope"
                  ],
                  "organization_usage": "deny",
                  "allow_any_organization": true,
                  "is_system": true,
                  "subject_type": "client",
                  "authorization_details_types": [
                    "authorization_details_types"
                  ],
                  "allow_all_scopes": true
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/client-grants")
                    .WithParam("from", "from")
                    .WithParam("take", "1")
                    .WithParam("audience", "audience")
                    .WithParam("client_id", "client_id")
                    .WithParam("subject_type", "client")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.ClientGrants.ListAsync(
            new ListClientGrantsRequestParameters
            {
                From = "from",
                Take = 1,
                Audience = "audience",
                ClientId = "client_id",
                AllowAnyOrganization = true,
                SubjectType = ClientGrantSubjectTypeEnum.Client,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
