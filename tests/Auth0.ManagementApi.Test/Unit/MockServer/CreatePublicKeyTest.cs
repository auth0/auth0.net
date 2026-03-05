using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer;

[TestFixture]
public class CreatePublicKeyTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "device_name": "device_name",
              "type": "public_key",
              "value": "value",
              "device_id": "device_id"
            }
            """;

        const string mockResponse = """
            {
              "id": "id"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/device-credentials")
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

        var response = await Client.DeviceCredentials.CreatePublicKeyAsync(
            new CreatePublicKeyDeviceCredentialRequestContent
            {
                DeviceName = "device_name",
                Type = DeviceCredentialPublicKeyTypeEnum.PublicKey,
                Value = "value",
                DeviceId = "device_id",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
