using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Sessions;

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
              "user_id": "user_id",
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z",
              "authenticated_at": "2024-01-15T09:30:00.000Z",
              "idle_expires_at": "2024-01-15T09:30:00.000Z",
              "expires_at": "2024-01-15T09:30:00.000Z",
              "last_interacted_at": "2024-01-15T09:30:00.000Z",
              "device": {
                "initial_user_agent": "initial_user_agent",
                "initial_ip": "initial_ip",
                "initial_asn": "initial_asn",
                "last_user_agent": "last_user_agent",
                "last_ip": "last_ip",
                "last_asn": "last_asn"
              },
              "clients": [
                {
                  "client_id": "client_id"
                }
              ],
              "authentication": {
                "methods": [
                  {}
                ]
              },
              "cookie": {
                "mode": "non-persistent"
              },
              "session_metadata": {
                "key": "value"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/sessions/id")
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

        var response = await Client.Sessions.UpdateAsync("id", new UpdateSessionRequestContent());
        JsonAssert.AreEqual(response, mockResponse);
    }
}
