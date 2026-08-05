using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations;

public partial interface IClientsClient
{
    /// <summary>
    /// List all clients associated with an organization, using checkpoint pagination.
    /// <list type="bullet">
    ///   <item><description>
    ///     <b>Note</b>: The first time you call this endpoint, omit the <c>from</c> parameter. If there are more results, a <c>next</c> value is included in the response. You can use this for subsequent API calls. When <c>next</c> is no longer included in the response, no further results are remaining.
    ///   </description></item>
    /// </list>
    /// </summary>
    Task<Pager<OrganizationClient>> ListAsync(
        string id,
        ListOrganizationClientsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Associate one or more clients with an organization.
    /// </summary>
    WithRawResponseTask<IEnumerable<OrganizationClient>> CreateAsync(
        string id,
        CreateOrganizationClientsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove one or more client associations from an organization.
    /// </summary>
    WithRawResponseTask DeleteAsync(
        string id,
        DeleteOrganizationClientsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a specific client association for an organization.
    /// </summary>
    WithRawResponseTask<GetOrganizationClientResponseContent> GetAsync(
        string id,
        string clientId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an organization client association.
    /// </summary>
    WithRawResponseTask<UpdateOrganizationClientResponseContent> UpdateAsync(
        string id,
        string clientId,
        UpdateOrganizationClientRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
