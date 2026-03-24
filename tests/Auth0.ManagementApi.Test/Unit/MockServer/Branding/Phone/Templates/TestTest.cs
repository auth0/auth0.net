using Auth0.ManagementApi.Branding.Phone;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Branding.Phone.Templates;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class TestTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "to": "to"
            }
            """;

        const string mockResponse = """
            {
              "message": "message"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/branding/phone/templates/id/try")
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

        var response = await Client.Branding.Phone.Templates.TestAsync(
            "id",
            new CreatePhoneTemplateTestNotificationRequestContent { To = "to" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
