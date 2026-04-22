using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.ClientGrants;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
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
                WireMock.RequestBuilders.Request.Create().WithPath("/client-grants/id").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.ClientGrants.GetAsync("id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
