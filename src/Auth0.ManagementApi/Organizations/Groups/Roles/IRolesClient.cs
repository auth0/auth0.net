using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations.Groups;

public partial interface IRolesClient
{
    /// <summary>
    /// Lists the roles assigned to the specified group in the context of an organization.
    /// </summary>
    Task<Pager<Role>> ListAsync(
        string organizationId,
        string groupId,
        ListOrganizationGroupRolesRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Assign one or more roles to a specified group in the context of an organization.
    /// </summary>
    Task CreateAsync(
        string organizationId,
        string groupId,
        CreateOrganizationGroupRolesRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Unassign one or more roles from a specified group in the context of an organization.
    /// </summary>
    Task DeleteAsync(
        string organizationId,
        string groupId,
        DeleteOrganizationGroupRolesRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
