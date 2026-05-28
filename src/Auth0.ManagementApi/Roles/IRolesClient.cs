using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial interface IRolesClient
{
    public Auth0.ManagementApi.Roles.IGroupsClient Groups { get; }
    public Auth0.ManagementApi.Roles.IPermissionsClient Permissions { get; }
    public Auth0.ManagementApi.Roles.IUsersClient Users { get; }

    /// <summary>
    /// Retrieve detailed list of user roles created in your tenant.
    ///
    /// **Note**: The returned list does not include standard roles available for tenant members, such as Admin or Support Access.
    /// </summary>
    Task<Pager<Role>> ListAsync(
        ListRolesRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a user role for [Role-Based Access Control](https://auth0.com/docs/manage-users/access-control/rbac).
    ///
    /// **Note**: New roles are not associated with any permissions by default. To assign existing permissions to your role, review Associate Permissions with a Role. To create new permissions, review Add API Permissions.
    /// </summary>
    WithRawResponseTask<CreateRoleResponseContent> CreateAsync(
        CreateRoleRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details about a specific [user role](https://auth0.com/docs/manage-users/access-control/rbac) specified by ID.
    /// </summary>
    WithRawResponseTask<GetRoleResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a specific [user role](https://auth0.com/docs/manage-users/access-control/rbac) from your tenant. Once deleted, it is removed from any user who was previously assigned that role. This action cannot be undone.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Modify the details of a specific [user role](https://auth0.com/docs/manage-users/access-control/rbac) specified by ID.
    /// </summary>
    WithRawResponseTask<UpdateRoleResponseContent> UpdateAsync(
        string id,
        UpdateRoleRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
