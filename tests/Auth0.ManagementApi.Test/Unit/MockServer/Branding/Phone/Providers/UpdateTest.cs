using Auth0.ManagementApi.Branding.Phone;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Branding.Phone.Providers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "id": "id",
              "tenant": "tenant",
              "name": "twilio",
              "channel": "phone",
              "disabled": true,
              "configuration": {
                "default_from": "default_from",
                "mssid": "mssid",
                "sid": "sid",
                "delivery_methods": [
                  "text"
                ]
              },
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/branding/phone/providers/id")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Branding.Phone.Providers.UpdateAsync(
            "id",
            new UpdateBrandingPhoneProviderRequestContent()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
