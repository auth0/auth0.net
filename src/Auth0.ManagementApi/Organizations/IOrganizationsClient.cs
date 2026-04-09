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

    /// <summary>
    /// Retrieve detailed list of all Organizations available in your tenant. For more information, see Auth0 Organizations.
    ///
    /// This endpoint supports two types of pagination:
    /// <list type="bullet">
    /// <item><description>Offset pagination</description></item>
    /// <item><description>Checkpoint pagination</description></item>
    /// </list>
    ///
    /// Checkpoint pagination must be used if you need to retrieve more than 1000 organizations.
    ///
    /// <para>Checkpoint Pagination</para>
    ///
    /// To search by checkpoint, use the following parameters:
    /// <list type="bullet">
    /// <item><description><c>from</c>: Optional id from which to start selection.</description></item>
    /// <item><description><c>take</c>: The total number of entries to retrieve when using the <c>from</c> parameter. Defaults to 50.</description></item>
    /// </list>
    ///
    /// <b>Note</b>: The first time you call this endpoint using checkpoint pagination, omit the <c>from</c> parameter. If there are more results, a <c>next</c> value is included in the response. You can use this for subsequent API calls. When <c>next</c> is no longer included in the response, no pages are remaining.
    /// </summary>
    Task<Pager<Organization>> ListAsync(
        ListOrganizationsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new Organization within your tenant.  To learn more about Organization settings, behavior, and configuration options, review <see href="https://auth0.com/docs/manage-users/organizations/create-first-organization">Create Your First Organization</see>.
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
    /// Update the details of a specific <see href="https://auth0.com/docs/manage-users/organizations/configure-organizations/create-organizations">Organization</see>, such as name and display name, branding options, and metadata.
    /// </summary>
    WithRawResponseTask<UpdateOrganizationResponseContent> UpdateAsync(
        string id,
        UpdateOrganizationRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
