using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations.Roles;

public partial interface IMembersClient
{
    /// <summary>
    /// List the organization members assigned a specific role within the context of an organization.
    /// </summary>
    Task<Pager<RoleMember>> ListAsync(
        string id,
        string roleId,
        ListOrganizationRoleMembersRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
