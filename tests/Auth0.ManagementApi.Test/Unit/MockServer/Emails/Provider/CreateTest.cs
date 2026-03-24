using Auth0.ManagementApi;
using Auth0.ManagementApi.Emails;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Emails.Provider;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "name": "mailgun",
              "credentials": {
                "api_key": "api_key"
              }
            }
            """;

        const string mockResponse = """
            {
              "name": "name",
              "enabled": true,
              "default_from_address": "default_from_address",
              "credentials": {
                "api_user": "api_user",
                "region": "region",
                "smtp_host": "smtp_host",
                "smtp_port": 1,
                "smtp_user": "smtp_user"
              },
              "settings": {
                "key": "value"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/emails/provider")
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

        var response = await Client.Emails.Provider.CreateAsync(
            new CreateEmailProviderRequestContent
            {
                Name = EmailProviderNameEnum.Mailgun,
                Credentials = new EmailProviderCredentialsSchemaZero { ApiKey = "api_key" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
