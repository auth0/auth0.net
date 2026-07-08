using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Roles;

public partial interface IUsersClient
{
    /// <summary>
    /// Retrieve list of users associated with a specific role. For Dashboard instructions, review [View Users Assigned to Roles](https://auth0.com/docs/manage-users/access-control/configure-core-rbac/roles/view-users-assigned-to-roles).
    ///
    /// This endpoint supports two types of pagination:
    ///
    /// - Offset pagination
    /// - Checkpoint pagination
    ///
    /// Checkpoint pagination must be used if you need to retrieve more than 1000 organization members.
    ///
    /// **Checkpoint Pagination**
    ///
    /// To search by checkpoint, use the following parameters:
    ///
    /// - `from`: Optional id from which to start selection.
    /// - `take`: The total amount of entries to retrieve when using the from parameter. Defaults to 50.
    ///
    /// **Note**: The first time you call this endpoint using checkpoint pagination, omit the `from` parameter. If there are more results, a `next` value is included in the response. You can use this for subsequent API calls. When `next` is no longer included in the response, no pages are remaining.
    /// </summary>
    Task<Pager<RoleUser>> ListAsync(
        string id,
        ListRoleUsersRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Assign one or more users to an existing user role. To learn more, review [Role-Based Access Control](https://auth0.com/docs/manage-users/access-control/rbac).
    ///
    /// **Note**: New roles cannot be created through this action.
    /// </summary>
    WithRawResponseTask AssignAsync(
        string id,
        AssignRoleUsersRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
