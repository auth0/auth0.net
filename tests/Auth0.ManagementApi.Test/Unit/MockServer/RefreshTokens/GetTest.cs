using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.RefreshTokens;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "id": "id",
              "user_id": "user_id",
              "created_at": "2024-01-15T09:30:00.000Z",
              "idle_expires_at": "2024-01-15T09:30:00.000Z",
              "expires_at": "2024-01-15T09:30:00.000Z",
              "device": {
                "initial_ip": "initial_ip",
                "initial_asn": "initial_asn",
                "initial_user_agent": "initial_user_agent",
                "last_ip": "last_ip",
                "last_asn": "last_asn",
                "last_user_agent": "last_user_agent"
              },
              "client_id": "client_id",
              "session_id": "session_id",
              "rotating": true,
              "resource_servers": [
                {
                  "audience": "audience",
                  "scopes": "scopes"
                }
              ],
              "refresh_token_metadata": {
                "key": "value"
              },
              "last_exchanged_at": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/refresh-tokens/id").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.RefreshTokens.GetAsync("id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
