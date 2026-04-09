using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations;

public partial interface IConnectionsClient
{
    Task<Pager<OrganizationAllConnectionPost>> ListAsync(
        string id,
        ListOrganizationAllConnectionsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<CreateOrganizationAllConnectionResponseContent> CreateAsync(
        string id,
        CreateOrganizationAllConnectionRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<GetOrganizationAllConnectionResponseContent> GetAsync(
        string id,
        string connectionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task DeleteAsync(
        string id,
        string connectionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<UpdateOrganizationAllConnectionResponseContent> UpdateAsync(
        string id,
        string connectionId,
        UpdateOrganizationConnectionRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
