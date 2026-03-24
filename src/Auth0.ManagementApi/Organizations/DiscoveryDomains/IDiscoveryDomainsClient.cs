using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations;

public partial interface IDiscoveryDomainsClient
{
    /// <summary>
    /// Retrieve list of all organization discovery domains associated with the specified organization.
    /// This endpoint is subject to eventual consistency; newly created, updated, or deleted discovery domains may not immediately appear in the response.
    /// </summary>
    Task<Pager<OrganizationDiscoveryDomain>> ListAsync(
        string id,
        ListOrganizationDiscoveryDomainsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new discovery domain for an organization.
    /// </summary>
    WithRawResponseTask<CreateOrganizationDiscoveryDomainResponseContent> CreateAsync(
        string id,
        CreateOrganizationDiscoveryDomainRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details about a single organization discovery domain specified by domain name.
    /// This endpoint is subject to eventual consistency; newly created, updated, or deleted discovery domains may not immediately appear in the response.
    /// </summary>
    WithRawResponseTask<GetOrganizationDiscoveryDomainByNameResponseContent> GetByNameAsync(
        string id,
        string discoveryDomain,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details about a single organization discovery domain specified by ID.
    /// This endpoint is subject to eventual consistency; newly created, updated, or deleted discovery domains may not immediately appear in the response.
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
    /// Update the verification status and/or use_for_organization_discovery for an organization discovery domain. The <c>status</c> field must be either <c>pending</c> or <c>verified</c>. The <c>use_for_organization_discovery</c> field can be <c>true</c> or <c>false</c> (default: <c>true</c>).
    /// </summary>
    WithRawResponseTask<UpdateOrganizationDiscoveryDomainResponseContent> UpdateAsync(
        string id,
        string discoveryDomainId,
        UpdateOrganizationDiscoveryDomainRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
