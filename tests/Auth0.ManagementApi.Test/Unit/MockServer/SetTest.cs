using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer;

[TestFixture]
public class SetTest : BaseMockServerTest
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
                    .WithPath("/email-templates/verify_email")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.EmailTemplates.SetAsync(
            EmailTemplateNameEnum.VerifyEmail,
            new SetEmailTemplateRequestContent { Template = EmailTemplateNameEnum.VerifyEmail }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
