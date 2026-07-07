using Auth0.ManagementApi.Core;
using Auth0.ManagementApi.Organizations;

namespace Auth0.ManagementApi;

public partial interface IOrganizationsClient
{
    public Auth0.ManagementApi.Organizations.IClientGrantsClient ClientGrants { get; }
    public Auth0.ManagementApi.Organizations.IConnectionsClient Connections { get; }
    public IDiscoveryDomainsClient DiscoveryDomains { get; }
    public IEnabledConnectionsClient EnabledConnections { get; }
    public IInvitationsClient Invitations { get; }
    public Auth0.ManagementApi.Organizations.IMembersClient Members { get; }
    public Auth0.ManagementApi.Organizations.IGroupsClient Groups { get; }
    public Auth0.ManagementApi.Organizations.Roles.IRolesClient Roles { get; }

    /// <summary>
    /// Retrieve detailed list of all Organizations available in your tenant. For more information, see Auth0 Organizations.
    ///
    /// This endpoint supports two types of pagination:
    ///
    /// - Offset pagination
    /// - Checkpoint pagination
    ///
    /// Checkpoint pagination must be used if you need to retrieve more than 1000 organizations.
    ///
    /// **Checkpoint Pagination**
    ///
    /// To search by checkpoint, use the following parameters:
    ///
    /// - `from`: Optional id from which to start selection.
    /// - `take`: The total number of entries to retrieve when using the `from` parameter. Defaults to 50.
    ///
    /// **Note**: The first time you call this endpoint using checkpoint pagination, omit the `from` parameter. If there are more results, a `next` value is included in the response. You can use this for subsequent API calls. When `next` is no longer included in the response, no pages are remaining.
    /// </summary>
    Task<Pager<Organization>> ListAsync(
        ListOrganizationsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new Organization within your tenant.  To learn more about Organization settings, behavior, and configuration options, review [Create Your First Organization](https://auth0.com/docs/manage-users/organizations/create-first-organization).
    /// </summary>
    WithRawResponseTask<CreateOrganizationResponseContent> CreateAsync(
        CreateOrganizationRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details about a single Organization specified by name.
    /// </summary>
    WithRawResponseTask<GetOrganizationByNameResponseContent> GetByNameAsync(
        string name,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details about a single Organization specified by ID.
    /// </summary>
    WithRawResponseTask<GetOrganizationResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove an Organization from your tenant.  This action cannot be undone.
    ///
    /// **Note**: Members are automatically disassociated from an Organization when it is deleted. However, this action does **not** delete these users from your tenant.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the details of a specific [Organization](https://auth0.com/docs/manage-users/organizations/configure-organizations/create-organizations), such as name and display name, branding options, and metadata.
    /// </summary>
    WithRawResponseTask<UpdateOrganizationResponseContent> UpdateAsync(
        string id,
        UpdateOrganizationRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
