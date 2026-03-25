using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.SelfServiceProfiles;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "name": "name"
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "description": "description",
              "user_attributes": [
                {
                  "name": "name",
                  "description": "description",
                  "is_optional": true
                }
              ],
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z",
              "branding": {
                "logo_url": "logo_url",
                "colors": {
                  "primary": "primary"
                }
              },
              "allowed_strategies": [
                "oidc"
              ],
              "user_attribute_profile_id": "user_attribute_profile_id"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/self-service-profiles")
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

        var response = await Client.SelfServiceProfiles.CreateAsync(
            new CreateSelfServiceProfileRequestContent { Name = "name" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
