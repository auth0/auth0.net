using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Organizations.OrganizationTemplate;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class AssignOrganizationTemplateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/organizations/id/organization-templates/template_id")
                    .UsingPut()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Organizations.OrganizationTemplate.AssignOrganizationTemplateAsync(
                "id",
                "template_id"
            )
        );
    }
}
