using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations;

public partial interface IDiscoveryDomainsClient
{
    /// <summary>
    /// Retrieve list of all organization discovery domains associated with the specified organization.
    /// </summary>
    Task<Pager<OrganizationDiscoveryDomain>> ListAsync(
        string id,
        ListOrganizationDiscoveryDomainsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the verification status for an organization discovery domain. The <code>status</code> field must be either <code>pending</code> or <code>verified</code>.
    /// </summary>
    WithRawResponseTask<CreateOrganizationDiscoveryDomainResponseContent> CreateAsync(
        string id,
        CreateOrganizationDiscoveryDomainRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details about a single organization discovery domain specified by ID.
    /// </summary>
    WithRawResponseTask<GetOrganizationDiscoveryDomainResponseContent> GetAsync(
        string id,
        string discoveryDomainId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a discovery domain from an organization. This action cannot be undone.
    /// </summary>
    Task DeleteAsync(
        string id,
        string discoveryDomainId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the verification status for an organization discovery domain. The <code>status</code> field must be either <code>pending</code> or <code>verified</code>.
    /// </summary>
    WithRawResponseTask<UpdateOrganizationDiscoveryDomainResponseContent> UpdateAsync(
        string id,
        string discoveryDomainId,
        UpdateOrganizationDiscoveryDomainRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
