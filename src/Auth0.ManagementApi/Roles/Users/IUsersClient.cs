using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Roles;

public partial interface IUsersClient
{
    /// <summary>
    /// Retrieve list of users associated with a specific role. For Dashboard instructions, review <see href="https://auth0.com/docs/manage-users/access-control/configure-core-rbac/roles/view-users-assigned-to-roles">View Users Assigned to Roles</see>.
    ///
    /// This endpoint supports two types of pagination:
    /// <list type="bullet">
    /// <item><description>Offset pagination</description></item>
    /// <item><description>Checkpoint pagination</description></item>
    /// </list>
    ///
    /// Checkpoint pagination must be used if you need to retrieve more than 1000 organization members.
    ///
    /// <para>Checkpoint Pagination</para>
    ///
    /// To search by checkpoint, use the following parameters:
    /// <list type="bullet">
    /// <item><description><c>from</c>: Optional id from which to start selection.</description></item>
    /// <item><description><c>take</c>: The total amount of entries to retrieve when using the from parameter. Defaults to 50.</description></item>
    /// </list>
    ///
    /// <b>Note</b>: The first time you call this endpoint using checkpoint pagination, omit the <c>from</c> parameter. If there are more results, a <c>next</c> value is included in the response. You can use this for subsequent API calls. When <c>next</c> is no longer included in the response, no pages are remaining.
    /// </summary>
    Task<Pager<RoleUser>> ListAsync(
        string id,
        ListRoleUsersRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Assign one or more users to an existing user role. To learn more, review <see href="https://auth0.com/docs/manage-users/access-control/rbac">Role-Based Access Control</see>.
    ///
    /// <b>Note</b>: New roles cannot be created through this action.
    /// </summary>
    Task AssignAsync(
        string id,
        AssignRoleUsersRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
