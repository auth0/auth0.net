using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations.Roles;

public partial interface IMembersClient
{
    /// <summary>
    /// List the organization members assigned a specific role within the context of an organization.
    /// <list type="bullet">
    ///   <item><description>
    ///     <b>Note</b>: Returns only members with direct role assignments. For groups assigned to this role within the organization, use <c>GET /api/v2/organizations/{organization_id}/roles/{role_id}/groups</c>.
    ///   </description></item>
    /// </list>
    /// </summary>
    Task<Pager<RoleMember>> ListAsync(
        string id,
        string roleId,
        ListOrganizationRoleMembersRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
