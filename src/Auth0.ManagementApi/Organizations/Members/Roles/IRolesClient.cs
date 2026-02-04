using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations.Members;

public partial interface IRolesClient
{
    /// <summary>
    /// Retrieve detailed list of roles assigned to a given user within the context of a specific Organization.
    ///
    /// Users can be members of multiple Organizations with unique roles assigned for each membership. This action only returns the roles associated with the specified Organization; any roles assigned to the user within other Organizations are not included.
    /// </summary>
    Task<Pager<Role>> ListAsync(
        string id,
        string userId,
        ListOrganizationMemberRolesRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Assign one or more <a href="https://auth0.com/docs/manage-users/access-control/rbac">roles</a> to a user to determine their access for a specific Organization.
    ///
    /// Users can be members of multiple Organizations with unique roles assigned for each membership. This action assigns roles to a user only for the specified Organization. Roles cannot be assigned to a user across multiple Organizations in the same call.
    /// </summary>
    Task AssignAsync(
        string id,
        string userId,
        AssignOrganizationMemberRolesRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove one or more Organization-specific <a href="https://auth0.com/docs/manage-users/access-control/rbac">roles</a> from a given user.
    ///
    /// Users can be members of multiple Organizations with unique roles assigned for each membership. This action removes roles from a user in relation to the specified Organization. Roles assigned to the user within a different Organization cannot be managed in the same call.
    /// </summary>
    Task DeleteAsync(
        string id,
        string userId,
        DeleteOrganizationMemberRolesRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
