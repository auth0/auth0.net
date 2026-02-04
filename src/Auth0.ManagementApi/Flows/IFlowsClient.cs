using Auth0.ManagementApi.Core;
using Auth0.ManagementApi.Flows.Vault;

namespace Auth0.ManagementApi;

public partial interface IFlowsClient
{
    public Auth0.ManagementApi.Flows.IExecutionsClient Executions { get; }
    public IVaultClient Vault { get; }
    Task<Pager<FlowSummary>> ListAsync(
        FlowsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<CreateFlowResponseContent> CreateAsync(
        CreateFlowRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<GetFlowResponseContent> GetAsync(
        string id,
        GetFlowRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<UpdateFlowResponseContent> UpdateAsync(
        string id,
        UpdateFlowRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
