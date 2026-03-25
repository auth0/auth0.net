using Auth0.ManagementApi.Organizations;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Organizations.DiscoveryDomains;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "domain": "domain"
            }
            """;

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
                    .WithPath("/organizations/id/discovery-domains")
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

        var response = await Client.Organizations.DiscoveryDomains.CreateAsync(
            "id",
            new CreateOrganizationDiscoveryDomainRequestContent { Domain = "domain" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
