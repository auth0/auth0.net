using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users;

public partial interface IOrganizationsClient
{
    /// <summary>
    /// Retrieve list of the specified user's current Organization memberships. User must be specified by user ID. For more information, review [Auth0 Organizations](https://auth0.com/docs/manage-users/organizations).
    /// </summary>
    Task<Pager<Organization>> ListAsync(
        string id,
        ListUserOrganizationsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
