using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations.Roles;

public partial interface IGroupsClient
{
    /// <summary>
    /// Retrieve the list of groups assigned to a role in the context of an organization.
    /// </summary>
    Task<Pager<RoleGroup>> ListAsync(
        string organizationId,
        string roleId,
        ListOrganizationRoleGroupsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
