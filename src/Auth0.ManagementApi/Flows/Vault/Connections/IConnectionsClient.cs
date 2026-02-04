using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Flows.Vault;

public partial interface IConnectionsClient
{
    Task<Pager<FlowsVaultConnectionSummary>> ListAsync(
        ListFlowsVaultConnectionsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<CreateFlowsVaultConnectionResponseContent> CreateAsync(
        CreateFlowsVaultConnectionRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<GetFlowsVaultConnectionResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<UpdateFlowsVaultConnectionResponseContent> UpdateAsync(
        string id,
        UpdateFlowsVaultConnectionRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
