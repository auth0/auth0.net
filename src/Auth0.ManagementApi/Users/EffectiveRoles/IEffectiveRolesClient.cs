using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users;

public partial interface IEffectiveRolesClient
{
    public Auth0.ManagementApi.Users.EffectiveRoles.Sources.ISourcesClient Sources { get; }

    /// <summary>
    /// Retrieve detailed list of effective roles for a user, including roles assigned directly and through group memberships.
    /// </summary>
    Task<Pager<UserEffectiveRole>> ListAsync(
        string id,
        ListUserEffectiveRolesRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
