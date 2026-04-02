using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Flows;

public partial interface IExecutionsClient
{
    Task<Pager<FlowExecutionSummary>> ListAsync(
        string flowId,
        ListFlowExecutionsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<GetFlowExecutionResponseContent> GetAsync(
        string flowId,
        string executionId,
        GetFlowExecutionRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task DeleteAsync(
        string flowId,
        string executionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
