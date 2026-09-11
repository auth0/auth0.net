using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Experimentation;

public partial interface IExperimentsClient
{
    /// <summary>
    /// Increments the current ramp index to the requested target level. Up-only: the target must be the immediate next level in the schedule. Idempotent: calling with the current level returns success without writing anything.
    /// </summary>
    WithRawResponseTask<AdvanceRampResponseContent> AdvanceRampAsync(
        string id,
        AdvanceRampRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
