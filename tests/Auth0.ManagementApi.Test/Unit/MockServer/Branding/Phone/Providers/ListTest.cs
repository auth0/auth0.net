using Auth0.ManagementApi.Branding.Phone;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Branding.Phone.Providers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "providers": [
                {
                  "id": "id",
                  "tenant": "tenant",
                  "name": "twilio",
                  "channel": "phone",
                  "disabled": true,
                  "configuration": {
                    "sid": "sid",
                    "delivery_methods": [
                      "text"
                    ]
                  },
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/branding/phone/providers")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Branding.Phone.Providers.ListAsync(
            new ListBrandingPhoneProvidersRequestParameters { Disabled = true }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
