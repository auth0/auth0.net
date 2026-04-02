using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.EventStreams;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "destination": {
                "type": "webhook",
                "configuration": {
                  "webhook_endpoint": "webhook_endpoint",
                  "webhook_authorization": {
                    "method": "basic",
                    "username": "username"
                  }
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "subscriptions": [
                {
                  "event_type": "event_type"
                }
              ],
              "destination": {
                "type": "webhook",
                "configuration": {
                  "webhook_endpoint": "webhook_endpoint",
                  "webhook_authorization": {
                    "method": "basic",
                    "username": "username"
                  }
                }
              },
              "status": "enabled",
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/event-streams")
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

        var response = await Client.EventStreams.CreateAsync(
            new CreateEventStreamWebHookRequestContent
            {
                Destination = new EventStreamWebhookDestination
                {
                    Type = EventStreamWebhookDestinationTypeEnum.Webhook,
                    Configuration = new EventStreamWebhookConfiguration
                    {
                        WebhookEndpoint = "webhook_endpoint",
                        WebhookAuthorization = new EventStreamWebhookBasicAuth
                        {
                            Method = EventStreamWebhookBasicAuthMethodEnum.Basic,
                            Username = "username",
                        },
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
