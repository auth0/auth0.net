using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Guardian.Factors.Sms;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTemplatesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "enrollment_message": "enrollment_message",
              "verification_message": "verification_message"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/guardian/factors/sms/templates")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Guardian.Factors.Sms.GetTemplatesAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
