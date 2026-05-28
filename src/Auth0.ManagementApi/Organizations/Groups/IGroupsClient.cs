using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations;

public partial interface IGroupsClient
{
    public Auth0.ManagementApi.Organizations.Groups.IRolesClient Roles { get; }

    /// <summary>
    /// Lists the groups that are assigned to the specified organization.
    /// </summary>
    Task<Pager<Group>> ListAsync(
        string organizationId,
        ListOrganizationGroupsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
