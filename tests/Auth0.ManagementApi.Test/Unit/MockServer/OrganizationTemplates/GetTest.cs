using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.OrganizationTemplates;

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
              "is_default": true,
              "organization_deletion_behavior": "allow",
              "connection_deletion_behavior": "allow",
              "enforce_permission_ceiling": true,
              "enforce_self_assignment_restriction": true,
              "connection_profile_id": "connection_profile_id",
              "user_attribute_profile_id": "user_attribute_profile_id",
              "allowed_strategies": [
                "adfs"
              ],
              "invitation_landing_client_id": "invitation_landing_client_id",
              "admin_roles_assignment": [
                "admin_roles_assignment"
              ],
              "use_for_organization_discovery": {
                "default_value": true,
                "allowed_values": [
                  true
                ]
              },
              "role_visibility_policy": {
                "default_value": "write",
                "overrides": [
                  {
                    "role_id": "role_id",
                    "access": "write"
                  }
                ]
              },
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/organization-templates/id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.OrganizationTemplates.GetAsync("id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
