using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.EmailTemplates;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "template": "verify_email"
            }
            """;

        const string mockResponse = """
            {
              "template": "verify_email",
              "body": "body",
              "from": "from",
              "resultUrl": "resultUrl",
              "subject": "subject",
              "syntax": "syntax",
              "urlLifetimeInSeconds": 1.1,
              "includeEmailInRedirect": true,
              "enabled": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/email-templates")
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

        var response = await Client.EmailTemplates.CreateAsync(
            new CreateEmailTemplateRequestContent { Template = EmailTemplateNameEnum.VerifyEmail }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
