using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.OrganizationTemplates;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "next": "next",
              "organization_templates": [
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
                    "default_value": true
                  },
                  "role_visibility_policy": {
                    "default_value": "write"
                  },
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/organization-templates")
                    .WithParam("from", "from")
                    .WithParam("take", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.OrganizationTemplates.ListAsync(
            new ListOrganizationTemplatesRequestParameters { From = "from", Take = 1 }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
