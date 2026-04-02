using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.NetworkAcls;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        const string requestJson = """
            {
              "description": "description",
              "active": true,
              "rule": {
                "action": {},
                "scope": "management"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/network-acls")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.NetworkAcls.CreateAsync(
                new CreateNetworkAclRequestContent
                {
                    Description = "description",
                    Active = true,
                    Rule = new NetworkAclRule
                    {
                        Action = new NetworkAclAction(),
                        Scope = NetworkAclRuleScopeEnum.Management,
                    },
                }
            )
        );
    }
}
