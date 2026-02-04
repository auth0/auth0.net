using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations;

public partial interface IClientGrantsClient
{
    Task<Pager<OrganizationClientGrant>> ListAsync(
        string id,
        ListOrganizationClientGrantsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<AssociateOrganizationClientGrantResponseContent> CreateAsync(
        string id,
        AssociateOrganizationClientGrantRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task DeleteAsync(
        string id,
        string grantId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
