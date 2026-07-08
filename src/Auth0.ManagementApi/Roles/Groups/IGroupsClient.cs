using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Roles;

public partial interface IGroupsClient
{
    /// <summary>
    /// Lists the groups to which the specified role is assigned.
    /// </summary>
    Task<Pager<Group>> GetAsync(
        string id,
        ListRoleGroupsParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Assign one or more groups to a specified role.
    /// </summary>
    WithRawResponseTask CreateAsync(
        string id,
        AssignRoleGroupsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Unassign one or more groups from a specified role.
    /// </summary>
    WithRawResponseTask DeleteAsync(
        string id,
        DeleteRoleGroupsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
