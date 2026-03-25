using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Organizations.DiscoveryDomains;

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
              "domain": "domain",
              "status": "pending",
              "use_for_organization_discovery": true,
              "verification_txt": "verification_txt",
              "verification_host": "verification_host"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/organizations/id/discovery-domains/name/discovery_domain")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organizations.DiscoveryDomains.GetByNameAsync(
            "id",
            "discovery_domain"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
