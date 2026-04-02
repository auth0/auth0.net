using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.DeviceCredentials;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "start": 1.1,
              "limit": 1.1,
              "total": 1.1,
              "device_credentials": [
                {
                  "id": "id",
                  "device_name": "device_name",
                  "device_id": "device_id",
                  "type": "public_key",
                  "user_id": "user_id",
                  "client_id": "client_id"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/device-credentials")
                    .WithParam("page", "1")
                    .WithParam("per_page", "1")
                    .WithParam("fields", "fields")
                    .WithParam("user_id", "user_id")
                    .WithParam("client_id", "client_id")
                    .WithParam("type", "public_key")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.DeviceCredentials.ListAsync(
            new ListDeviceCredentialsRequestParameters
            {
                Page = 1,
                PerPage = 1,
                IncludeTotals = true,
                Fields = "fields",
                IncludeFields = true,
                UserId = "user_id",
                ClientId = "client_id",
                Type = DeviceCredentialTypeEnum.PublicKey,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
