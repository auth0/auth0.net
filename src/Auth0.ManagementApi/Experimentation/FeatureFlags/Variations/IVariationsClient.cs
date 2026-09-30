using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Experimentation.FeatureFlags;

public partial interface IVariationsClient
{
    /// <summary>
    /// Retrieve all variations defined for a specific feature flag.
    /// </summary>
    WithRawResponseTask<ListVariationsResponseContent> ListAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new variation with parameter overrides for a specific feature flag.
    /// </summary>
    WithRawResponseTask<CreateVariationResponseContent> CreateAsync(
        string id,
        CreateVariationRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a single variation by its ID.
    /// </summary>
    WithRawResponseTask<GetVariationResponseContent> GetAsync(
        string id,
        string vid,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a variation by ID. Returns 204 if the variation does not exist. Returns 404 if the parent feature flag does not exist.
    /// </summary>
    WithRawResponseTask DeleteAsync(
        string id,
        string vid,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Partially update a variation by ID. Only provided fields are updated.
    /// </summary>
    WithRawResponseTask<UpdateVariationResponseContent> UpdateAsync(
        string id,
        string vid,
        UpdateVariationRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
