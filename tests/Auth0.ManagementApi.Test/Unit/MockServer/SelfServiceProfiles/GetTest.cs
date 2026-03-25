using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.SelfServiceProfiles;

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
                    .WithPath("/self-service-profiles/id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.SelfServiceProfiles.GetAsync("id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
