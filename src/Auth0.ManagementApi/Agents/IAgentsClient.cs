using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial interface IAgentsClient
{
    /// <summary>
    /// Get agents
    /// </summary>
    Task<Pager<AgentResponseContent>> ListAsync(
        ListAgentsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create an agent
    /// </summary>
    WithRawResponseTask<AgentResponseContent> CreateAsync(
        CreateAgentRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get an agent
    /// </summary>
    WithRawResponseTask<AgentResponseContent> ReadAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an agent
    /// </summary>
    WithRawResponseTask DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an agent
    /// </summary>
    WithRawResponseTask<AgentResponseContent> UpdateAsync(
        string id,
        PatchAgentRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
