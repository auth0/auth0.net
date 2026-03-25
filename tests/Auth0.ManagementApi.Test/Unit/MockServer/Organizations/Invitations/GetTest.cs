using Auth0.ManagementApi.Organizations;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Organizations.Invitations;

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
              "organization_id": "organization_id",
              "inviter": {
                "name": "name"
              },
              "invitee": {
                "email": "email"
              },
              "invitation_url": "invitation_url",
              "created_at": "2024-01-15T09:30:00.000Z",
              "expires_at": "2024-01-15T09:30:00.000Z",
              "client_id": "client_id",
              "connection_id": "connection_id",
              "app_metadata": {
                "key": "value"
              },
              "user_metadata": {
                "key": "value"
              },
              "roles": [
                "roles"
              ],
              "ticket_id": "ticket_id"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/organizations/id/invitations/invitation_id")
                    .WithParam("fields", "fields")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organizations.Invitations.GetAsync(
            "id",
            "invitation_id",
            new GetOrganizationInvitationRequestParameters
            {
                Fields = "fields",
                IncludeFields = true,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
