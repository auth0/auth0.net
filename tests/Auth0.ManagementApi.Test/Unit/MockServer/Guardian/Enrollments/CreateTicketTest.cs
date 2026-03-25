using Auth0.ManagementApi.Guardian;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Guardian.Enrollments;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTicketTest : BaseMockServerTest
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
              "ticket_id": "ticket_id",
              "ticket_url": "ticket_url"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/guardian/enrollments/ticket")
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

        var response = await Client.Guardian.Enrollments.CreateTicketAsync(
            new CreateGuardianEnrollmentTicketRequestContent { UserId = "user_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
