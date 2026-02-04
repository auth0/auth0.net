using Auth0.ManagementApi.Core;
using Auth0.ManagementApi.Organizations;

namespace Auth0.ManagementApi;

public partial interface IOrganizationsClient
{
    public Auth0.ManagementApi.Organizations.IClientGrantsClient ClientGrants { get; }
    public IDiscoveryDomainsClient DiscoveryDomains { get; }
    public IEnabledConnectionsClient EnabledConnections { get; }
    public IInvitationsClient Invitations { get; }
    public IMembersClient Members { get; }

    /// <summary>
    /// Retrieve detailed list of all Organizations available in your tenant. For more information, see Auth0 Organizations.
    ///
    /// This endpoint supports two types of pagination:
    /// <ul>
    /// <li>Offset pagination</li>
    /// <li>Checkpoint pagination</li>
    /// </ul>
    ///
    /// Checkpoint pagination must be used if you need to retrieve more than 1000 organizations.
    ///
    /// &lt;h2&gt;Checkpoint Pagination&lt;/h2&gt;
    ///
    /// To search by checkpoint, use the following parameters:
    /// <ul>
    /// <li><code>from</code>: Optional id from which to start selection.</li>
    /// <li><code>take</code>: The total number of entries to retrieve when using the <code>from</code> parameter. Defaults to 50.</li>
    /// </ul>
    ///
    /// <b>Note</b>: The first time you call this endpoint using checkpoint pagination, omit the <code>from</code> parameter. If there are more results, a <code>next</code> value is included in the response. You can use this for subsequent API calls. When <code>next</code> is no longer included in the response, no pages are remaining.
    /// </summary>
    Task<Pager<Organization>> ListAsync(
        ListOrganizationsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new Organization within your tenant.  To learn more about Organization settings, behavior, and configuration options, review <a href="https://auth0.com/docs/manage-users/organizations/create-first-organization">Create Your First Organization</a>.
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
    /// <b>Note</b>: Members are automatically disassociated from an Organization when it is deleted. However, this action does <b>not</b> delete these users from your tenant.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the details of a specific <a href="https://auth0.com/docs/manage-users/organizations/configure-organizations/create-organizations">Organization</a>, such as name and display name, branding options, and metadata.
    /// </summary>
    WithRawResponseTask<UpdateOrganizationResponseContent> UpdateAsync(
        string id,
        UpdateOrganizationRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
