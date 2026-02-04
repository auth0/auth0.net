using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Actions;

public partial interface IExecutionsClient
{
    /// <summary>
    /// Retrieve information about a specific execution of a trigger. Relevant execution IDs will be included in tenant logs generated as part of that authentication flow. Executions will only be stored for 10 days after their creation.
    /// </summary>
    WithRawResponseTask<GetActionExecutionResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
