using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations.Members.EffectiveRoles.Sources;

public partial interface IGroupsClient
{
    /// <summary>
    /// Lists the groups which grant the org member a given role.
    /// </summary>
    Task<Pager<Group>> ListAsync(
        string id,
        string userId,
        ListOrganizationMemberRoleSourceGroupsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
