using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer;

[TestFixture]
public class GetSettingsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "universal_login_experience": "new",
              "identifier_first": true,
              "webauthn_platform_first_factor": true
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/prompts").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Prompts.GetSettingsAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
