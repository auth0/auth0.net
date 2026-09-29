using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Experimentation;

public partial interface IExperimentsClient
{
    /// <summary>
    /// Retrieve a paginated list of experiments for the tenant, with optional filters.
    /// </summary>
    Task<Pager<ExperimentListItem>> ListAsync(
        ListExperimentsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new experiment for A/B testing.
    /// </summary>
    WithRawResponseTask<CreateExperimentResponseContent> CreateAsync(
        CreateExperimentRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a single experiment with its allocations by ID.
    /// </summary>
    WithRawResponseTask<GetExperimentResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently delete an experiment and its allocations by ID. Active experiments cannot be deleted; pause or complete first. Idempotent: returns 204 even if the experiment does not exist.
    /// </summary>
    WithRawResponseTask DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Partially update an experiment by ID. Only provided fields are updated. Providing allocations replaces the entire allocations set.
    /// </summary>
    WithRawResponseTask<UpdateExperimentResponseContent> UpdateAsync(
        string id,
        UpdateExperimentRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Increments the current ramp index to the requested target level. Up-only: the target must be the immediate next level in the schedule. Idempotent: calling with the current level returns success without writing anything.
    /// </summary>
    WithRawResponseTask<AdvanceRampResponseContent> AdvanceRampAsync(
        string id,
        AdvanceRampRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Transitions an experiment through its lifecycle: draft → active, active → paused, paused → active, active/paused → completed. Activation runs full readiness validation.
    /// </summary>
    WithRawResponseTask<UpdateExperimentStatusResponseContent> UpdateStatusAsync(
        string id,
        UpdateExperimentStatusRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Checks whether an experiment is ready to be activated. Returns is_valid boolean and an errors array describing any blockers. Read-only; no state is modified.
    /// </summary>
    WithRawResponseTask<ValidateExperimentResponseContent> ValidateAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
