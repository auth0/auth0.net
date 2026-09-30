using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using Auth0.ManagementApi.Experimentation.FeatureFlags;

namespace Auth0.ManagementApi.Experimentation;

public partial interface IFeatureFlagsClient
{
    public IVariationsClient Variations { get; }

    /// <summary>
    /// Retrieve a paginated list of feature flags for the tenant.
    /// </summary>
    Task<Pager<FeatureFlag>> ListAsync(
        ListFeatureFlagsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new feature flag with parameters for use in experiments.
    /// </summary>
    WithRawResponseTask<CreateFeatureFlagResponseContent> CreateAsync(
        CreateFeatureFlagRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a single feature flag by its ID.
    /// </summary>
    WithRawResponseTask<GetFeatureFlagResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a feature flag by ID. Idempotent: returns 204 even if flag does not exist.
    /// </summary>
    WithRawResponseTask DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Partially update a feature flag by ID. Only provided fields are updated.
    /// </summary>
    WithRawResponseTask<UpdateFeatureFlagResponseContent> UpdateAsync(
        string id,
        UpdateFeatureFlagRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Transitions a feature flag through its lifecycle states: draft → active, draft → archived, active → archived.
    /// </summary>
    WithRawResponseTask<UpdateFeatureFlagStatusResponseContent> UpdateStatusAsync(
        string id,
        UpdateFeatureFlagStatusRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
