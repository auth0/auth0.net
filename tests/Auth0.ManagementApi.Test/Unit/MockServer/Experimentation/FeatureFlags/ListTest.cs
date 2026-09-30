using Auth0.ManagementApi;
using Auth0.ManagementApi.Experimentation;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Experimentation.FeatureFlags;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "feature_flags": [
                {
                  "id": "id",
                  "name": "name",
                  "description": "description",
                  "type": "auth0",
                  "status": "draft",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z"
                }
              ],
              "next": "next"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/experimentation/feature-flags")
                    .WithParam("from", "from")
                    .WithParam("take", "1")
                    .WithParam("type", "auth0")
                    .WithParam("status", "draft")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Experimentation.FeatureFlags.ListAsync(
            new ListFeatureFlagsRequestParameters
            {
                From = "from",
                Take = 1,
                Type = FeatureFlagTypeEnum.Auth0,
                Status = FeatureFlagStatusEnum.Draft,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
