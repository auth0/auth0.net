using Auth0.ManagementApi.Jobs;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Jobs;

[TestFixture]
public class CreateTest_ : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "user_id": "user_id"
            }
            """;

        const string mockResponse = """
            {
              "status": "status",
              "type": "type",
              "created_at": "created_at",
              "id": "id"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/jobs/verification-email")
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

        var response = await Client.Jobs.VerificationEmail.CreateAsync(
            new CreateVerificationEmailRequestContent { UserId = "user_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
