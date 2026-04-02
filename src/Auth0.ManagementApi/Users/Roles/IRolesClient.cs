using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users;

public partial interface IRolesClient
{
    /// <summary>
    /// Retrieve detailed list of all user roles currently assigned to a user.
    ///
    /// <b>Note</b>: This action retrieves all roles assigned to a user in the context of your whole tenant. To retrieve Organization-specific roles, use the following endpoint: <see href="https://auth0.com/docs/api/management/v2/organizations/get-organization-member-roles">Get user roles assigned to an Organization member</see>.
    /// </summary>
    Task<Pager<Role>> ListAsync(
        string id,
        ListUserRolesRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Assign one or more existing user roles to a user. For more information, review <see href="https://auth0.com/docs/manage-users/access-control/rbac">Role-Based Access Control</see>.
    ///
    /// <b>Note</b>: New roles cannot be created through this action. Additionally, this action is used to assign roles to a user in the context of your whole tenant. To assign roles in the context of a specific Organization, use the following endpoint: <see href="https://auth0.com/docs/api/management/v2/organizations/post-organization-member-roles">Assign user roles to an Organization member</see>.
    /// </summary>
    Task AssignAsync(
        string id,
        AssignUserRolesRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove one or more specified user roles assigned to a user.
    ///
    /// <b>Note</b>: This action removes a role from a user in the context of your whole tenant. If you want to unassign a role from a user in the context of a specific Organization, use the following endpoint: <see href="https://auth0.com/docs/api/management/v2/organizations/delete-organization-member-roles">Delete user roles from an Organization member</see>.
    /// </summary>
    Task DeleteAsync(
        string id,
        DeleteUserRolesRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
