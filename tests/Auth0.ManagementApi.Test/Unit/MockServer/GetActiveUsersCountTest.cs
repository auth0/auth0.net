using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer;

[TestFixture]
public class GetActiveUsersCountTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            1.1
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/stats/active-users").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Stats.GetActiveUsersCountAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
