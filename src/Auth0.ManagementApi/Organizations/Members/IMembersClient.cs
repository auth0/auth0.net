using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations;

public partial interface IMembersClient
{
    public Auth0.ManagementApi.Organizations.Members.IRolesClient Roles { get; }

    /// <summary>
    /// List organization members.
    /// This endpoint is subject to eventual consistency. New users may not be immediately included in the response and deleted users may not be immediately removed from it.
    ///
    /// <ul>
    ///   <li>
    ///     Use the <code>fields</code> parameter to optionally define the specific member details retrieved. If <code>fields</code> is left blank, all fields (except roles) are returned.
    ///   </li>
    ///   <li>
    ///     Member roles are not sent by default. Use <code>fields=roles</code> to retrieve the roles assigned to each listed member. To use this parameter, you must include the <code>read:organization_member_roles</code> scope in the token.
    ///   </li>
    /// </ul>
    ///
    /// This endpoint supports two types of pagination:
    ///
    /// - Offset pagination
    /// - Checkpoint pagination
    ///
    /// Checkpoint pagination must be used if you need to retrieve more than 1000 organization members.
    ///
    /// &lt;h2&gt;Checkpoint Pagination&lt;/h2&gt;
    ///
    /// To search by checkpoint, use the following parameters: - from: Optional id from which to start selection. - take: The total amount of entries to retrieve when using the from parameter. Defaults to 50. Note: The first time you call this endpoint using Checkpoint Pagination, you should omit the <code>from</code> parameter. If there are more results, a <code>next</code> value will be included in the response. You can use this for subsequent API calls. When <code>next</code> is no longer included in the response, this indicates there are no more pages remaining.
    /// </summary>
    Task<Pager<OrganizationMember>> ListAsync(
        string id,
        ListOrganizationMembersRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Set one or more existing users as members of a specific <a href="https://auth0.com/docs/manage-users/organizations">Organization</a>.
    ///
    /// To add a user to an Organization through this action, the user must already exist in your tenant. If a user does not yet exist, you can <a href="https://auth0.com/docs/manage-users/organizations/configure-organizations/invite-members">invite them to create an account</a>, manually create them through the Auth0 Dashboard, or use the Management API.
    /// </summary>
    Task CreateAsync(
        string id,
        CreateOrganizationMemberRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task DeleteAsync(
        string id,
        DeleteOrganizationMembersRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
