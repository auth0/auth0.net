using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations.Members;

public partial interface IEffectiveRolesClient
{
    public Auth0.ManagementApi.Organizations.Members.EffectiveRoles.Sources.ISourcesClient Sources { get; }

    /// <summary>
    /// Lists the roles assigned to an organization member directly or through group membership.
    /// </summary>
    Task<Pager<OrganizationMemberEffectiveRole>> ListAsync(
        string id,
        string userId,
        ListOrganizationMemberEffectiveRolesRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
